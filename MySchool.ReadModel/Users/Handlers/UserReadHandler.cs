using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySchool.ReadModel.Users.Response;
using System.Security.Claims;

namespace MySchool.ReadModel.Users.Handlers
{
    public class UserReadHandler
    {
        public static async Task<IResult> ActionGetAll(IConfiguration configuration)
        {
            var query = @"SELECT
                          u.Id, u.Email, u.UserName
                          FROM [AspNetUsers] u
                          ORDER BY u.UserName ASC";

            var db = new SqlConnection(configuration["Database:Connection"]);

            var users = await db.QueryAsync<UserResponse>(query);

            return Results.Ok(users);
       }
    }
}
