using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using news_server.Data.dbModels;
using news_server.Infrastructure;
using news_server.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace news_server.Features.Identity
{
    public class IdentityService: IIdentityService
    {
        private readonly IConfiguration configuration;

        public IdentityService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public async Task<string> Authenticate(User user, string roleName)
        {
            var result = await Task.Run(() =>
                {
                    var claims = new List<Claim>()
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, roleName)
                };
                    var identity = new ClaimsIdentity(claims, "jwt", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                    var now = DateTime.Now;
                    var expire = now.AddDays(int.Parse(configuration.GetLifeTime()));

                    var jwt = new JwtSecurityToken(
                        issuer: configuration.GetIssuer(),
                        audience: configuration.GetAudience(),
                        claims: identity.Claims,
                        notBefore: now,
                        expires: expire,
                        signingCredentials: new SigningCredentials(AuthConfiguration.GetSecurityKey(configuration.GetSecurityKey()), SecurityAlgorithms.HmacSha256)
                        );
                    var token = new JwtSecurityTokenHandler().WriteToken(jwt);
                    return token;
                });
            return result;
        }
    }
}
