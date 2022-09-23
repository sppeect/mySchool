using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MySchool.Command.Security.Request;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Command.Security.Handlers
{
    public class SecurityHandler
    {
        [AllowAnonymous]
        public static IResult Action(LoginRequest loginRequest, IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            var user = userManager.FindByEmailAsync(loginRequest.Email).Result;
            if (user == null)
                Results.BadRequest();
            if (!userManager.CheckPasswordAsync(user, loginRequest.Password).Result)
                Results.BadRequest();

            var claims = userManager.GetClaimsAsync(user).Result;

            var claimName = claims.ToList().FindAll(x => x.Type == "Name").Select(c => c.Value);
            var claimCompanyId = claims.ToList().FindAll(x => x.Type == "CompanyId").Select(c => c.Value);


            var subject = new ClaimsIdentity(new Claim[]
              {
            new Claim(ClaimTypes.Email, loginRequest.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
              });
            subject.AddClaims(claims);

            var key = Encoding.ASCII.GetBytes(configuration["JwtBearerTokenSettings:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = configuration["JwtBearerTokenSettings:Audience"],
                Issuer = configuration["JwtBearerTokenSettings:Issuer"],
                Expires = DateTime.UtcNow.AddSeconds(86400)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Results.Ok(new { token = tokenHandler.WriteToken(token), name = claimName, companyId = claimCompanyId });
        }
    }
}
