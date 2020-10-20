﻿using news_server.Features.News.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace news_server.Features.News
{
    public interface INewsService
    {
        Task<bool> CreateNews(CreateNewsModel model, string userName);
        Task<bool> EditNews(EditNewsModel model, string userName);
        Task<IEnumerable<GetNewsModel>> GetNews(int page = 1);
        Task<IEnumerable<GetNewsModel>> GetInterestingNews(string username, int page = 1);
        Task<GetNewsByIdModel> GetNewsById(int newsId);
        Task<List<GetNewsModel>> GetMyNews(string username, int page = 1);
        List<GetNewsModel> GetProfileNews (int profileId, int page = 1);
        List<GetNewsModel> GetProfileNews (int profileId);
        Task<List<GetNewsModel>> FindNews(string text, int page = 1);

    }
}
