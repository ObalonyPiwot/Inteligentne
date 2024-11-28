using Domain.Authorization;
using Domain.Entities;
using Infrastructure.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyProject.Application.Features.Common;
using MyProject.Persistance.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Application.Features.Authorise
{
    public class GetTokenCommandHandler : IRequestHandler<GetTokenCommand, BaseResponse<TokenViewModel>>
    {
        private const string SecretKey = "NK9SNCB5SFSB23ZKX233GJVSXFOYQGMPHDGM8PD0HN2K2XJ9O8AGSVVX8KV6DX69D33FLQQKFDWHONEGW34U" +
            "T36ONDFC47IMJX0PIU9PZXZGZOYB5PABFMFA"; // Klucz do szyfrowania i deszyfrowania
        private const string JwtSecretKey = "78CNq33q2Hq7SvnA3vyXTlUAdxbiFAyIk5K3fLuzSj3lOyeDcYBJX6m6vGgxT22iqucEGv4FLKrkbQkQG" +
            "Aq9QDwz0EVgGDMrj02vOSgM26XFi0wfjVBBRXwnV6rhGSxsyfhnvKfssSzxJyWUGuYEbR9QLF4CWOIMIYw2rtquizvhL7UJjBIH"; // Klucz JWT 
        private string Issuer;
        private string Audience;
        private IMyProjectDbContext DbContext;
        public GetTokenCommandHandler(IOptions<AuthoriseConfiguration> authoriseConfiguration, IMyProjectDbContext dbContext)
        {
            Issuer = authoriseConfiguration.Value.Url;
            Audience = authoriseConfiguration.Value.Audience;
            DbContext = dbContext;
        }
        public async Task<BaseResponse<TokenViewModel>> Handle(GetTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                UserEntity? user = await CheckUser(request.Login, request.Password);

                if (user != null)
                {
                    var token = GenerateJwtToken();
                    return new BaseResponse<TokenViewModel>(statusCode: HttpStatusCode.Created, 
                        content: new TokenViewModel() { Token = token, UserName=user.UserName, ExpirationTime="900" });
                }

                return new BaseResponse<TokenViewModel>(statusCode: HttpStatusCode.BadRequest, content: null,
                    error: $"Bad credentials");
            }
            catch (Exception ex)
            {
                return new BaseResponse<TokenViewModel>(statusCode: HttpStatusCode.BadRequest, content: null,
                    error: $"Error: {ex.Message}.");
            }
        }

        private async Task<UserEntity?> CheckUser(string login, string password)
        {
                return await DbContext.Users.Where(x=>x.Login==login && x.Password==password).FirstOrDefaultAsync();
        }

        private string GenerateJwtToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
