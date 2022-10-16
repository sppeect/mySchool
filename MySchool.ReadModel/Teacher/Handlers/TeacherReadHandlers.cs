using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySchool.ReadModel.Teacher.Response;

namespace MySchool.ReadModel.Teacher.Handlers
{
    public class TeacherReadHandlers
    {
        public static async Task<IResult> ActionGetAll(IConfiguration configuration)
        {
            var query = @"SELECT [Id]
                                  ,[Name]
                                  ,[Document]
                                  ,[DocumentType]
                                  ,[Email]
                                  ,[CreatedOn]
                                  ,[DeletedOn]
                                  ,[UpdatedOn]
	                              FROM [Teachers] t
	                              WHERE DeletedOn IS NULL
	                              ORDER BY [NAME] ASC";

            var db = new SqlConnection(configuration["Database:Connection"]);

            var schools = await db.QueryAsync<TeacherResponse>(query);

            return Results.Ok(schools);
        }
        public static async Task<IResult> ActionGetById([FromRoute] int Id, IConfiguration configuration)
        {
            var query = @"SELECT [Id]
                                  ,[Name]
                                  ,[Document]
                                  ,[DocumentType]
                                  ,[Email]
                                  ,[CreatedOn]
                                  ,[DeletedOn]
                                  ,[UpdatedOn]
	                              FROM [Teachers] t
	                              WHERE DeletedOn IS NULL and Id = @Id
	                              ORDER BY [NAME] ASC";

            var db = new SqlConnection(configuration["Database:Connection"]);

            var schools = await db.QueryAsync<TeacherResponse>(query, new { Id });

            return Results.Ok(schools);
        }
    }
}
