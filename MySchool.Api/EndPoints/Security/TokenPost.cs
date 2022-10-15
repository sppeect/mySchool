using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MySchool.Command.Security;
using MySchool.Command.Security.Handlers;
using MySchool.Command.Security.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MySchool.Api.EndPoints.Security;

public class TokenPost
{
    public static string Template => "v1/token";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => SecurityHandler.Action;

}
