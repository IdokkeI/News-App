using Microsoft.EntityFrameworkCore;
using news_server.Data;
using CProfile = news_server.Data.dbModels.Profile;
using news_server.Features.News;
using news_server.Features.Profile.Models;
using news_server.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using MimeKit;
using MailKit.Net.Smtp;

namespace news_server.Features.Profile
{
    public class ProfileService : IProfileService
    {
        private readonly NewsDbContext context;
        private readonly INewsService newsService;
        private readonly IWebHostEnvironment env;

        public ProfileService(
            NewsDbContext context, 
            INewsService newsService,
            IWebHostEnvironment env
            )
        {
            this.context = context;
            this.newsService = newsService;
            this.env = env;
        }

        public async Task<List<GetUserPmodel>> GetProfilesExceptName(string username, int page)
        {
            var result = await context
                .Profiles
                .Include(p => p.User)
                .Where(p => !p.isBaned && p.User.UserName != username)
                .Select(p => new GetUserPmodel
                {
                    ProfileID = p.Id,
                    UserName = p.User.UserName
                })
                .OrderBy(p => p.UserName)
                .Skip(page * 20 - 20)
                .Take(20)
                .ToListAsync();

            return result;
        }

        public async Task<CProfile> GetSimpleProfileById(int profileId)
        {
            var result = await context
                .Profiles
                .FirstOrDefaultAsync(p => p.Id == profileId);

            return result;
        }

        public string GetUserNameByProfileId(int profileIdSub)
        {
            var username = context
                .Profiles
                .Include(p => p.User)
                .FirstOrDefault(p => p.Id == profileIdSub).User.UserName;

            return username;
        }

        public async Task<GetProfileById> GetProfileNewsByUserName(string myUserName, string username, int page)
        {
            var result = await context
              .Subscriptions
              .Include(s => s.Profile)
              .Include(s => s.Profile.User)
              .Where(s => s.Profile.User.UserName == username)
              .Select(s => new GetProfileById
              {
                  ProfileId = s.ProfileId,
                  UserName = s.Profile.User.UserName                  
              })              
              .FirstOrDefaultAsync();

            if (result != null)
            {
                result.UserNews = await newsService.GetProfileNews(myUserName, result.ProfileId, page);
            }            

            return result;
        }
        
        public async Task<GetProfileById> GetProfileNewsByUserName(string myUserName, string username)
        {
            var result = await context
              .Subscriptions
              .Include(s => s.Profile)
              .Include(s => s.Profile.User)
              .Where(s => s.Profile.User.UserName == username)
              .Select(s => new GetProfileById
              {
                  ProfileId = s.ProfileId,
                  UserName = s.Profile.User.UserName                  
              })
              .FirstOrDefaultAsync();

            result.UserNews = await newsService.GetProfileNews(myUserName, result.ProfileId);

            return result;
        }

        public async Task<GetProfileById> GetProfileNewsById(string myUserName, int profileId, int page)
        {
            var result = await context
                .Subscriptions
                .Include(s => s.Profile)
                .Include(s => s.Profile.User)
                .Where(s => s.ProfileId == profileId)
                .Select(s => new GetProfileById 
                { 
                    ProfileId = s.ProfileId,
                    UserName = s.Profile.User.UserName
                    
                })
                .FirstOrDefaultAsync();

            if (result != null)
            {
                result.UserNews = await newsService.GetProfileNews(myUserName, result.ProfileId, page);

            }

            return result;
        }

        public async Task<string> UploadProfileImage(string username, IFormFile image)
        {
            var dirPath = Path.Combine(env.WebRootPath, username, "profile");
            Directory.CreateDirectory(dirPath);
            var filePath = Path.Combine(dirPath, image.FileName.Replace(' ', '_'));

            var files = new DirectoryInfo(dirPath).GetFiles();

            if (files.Length != 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    files[i].Delete();
                }
            }

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            var user = await context
                .Users
                .FirstOrDefaultAsync(u => u.UserName == username);

            user.Photo = filePath;
            context.Users.Update(user);

            await context.SaveChangesAsync();

            return filePath;
        }

        public async Task SendEmail(string email, string link)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("", "eybrev9@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = "Смена пароля";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"Для смены пароля перейдите по ссылке <a href={link}>{link}</a>"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 25, false);
                await client.AuthenticateAsync("eybrev9@mail.ru", "529440qwe");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
