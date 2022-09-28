using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySchool.ReadModel.School.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.ReadModel.School.Handlers
{
    public class SchoolReadHandlers
    {
        [AllowAnonymous]
        public static async Task<IResult> ActionGetAll(IConfiguration configuration)
        {
            var query = @"SELECT 
                        s.[Id]
                        ,s.[Name]
                        ,s.[AddressStreet]
                        ,s.[AddressNumber]
                        ,s.[AddressNeighborhood]
                        ,s.[AddressCity]
                        ,s.[AddressState]
                        ,s.[AddressCountry]
                        ,s.[AddressZipCode]
                        ,s.[Email]
                        ,s.[Phone]
                        ,s.[Document]
                        ,s.[DocumentType]
                        ,s.[CreatedOn]
                        ,s.[UpdatedOn]
                        ,s.[DeletedOn]
                        FROM [Schools] s
                        WHERE s.DeletedOn IS NULL
                        ORDER BY s.[Name] ASC";

            var db = new SqlConnection(configuration["Database:Connection"]);

            var schools = await db.QueryAsync<SchoolResponse>(query);

            return Results.Ok(schools);
        }

        [AllowAnonymous]
        public static async Task<IResult> ActionGetById([FromRoute] int Id, IConfiguration configuration)
        {
            var query = @"SELECT 
                        s.[Id]
                        ,s.[Name]
                        ,s.[AddressStreet]
                        ,s.[AddressNumber]
                        ,s.[AddressNeighborhood]
                        ,s.[AddressCity]
                        ,s.[AddressState]
                        ,s.[AddressCountry]
                        ,s.[AddressZipCode]
                        ,s.[Email]
                        ,s.[Phone]
                        ,s.[Document]
                        ,s.[DocumentType]
                        ,s.[CreatedOn]
                        ,s.[UpdatedOn]
                        ,s.[DeletedOn]
                        FROM [Schools] s
                        WHERE s.DeletedOn IS NULL AND s.[Id] = @Id
                        ORDER BY s.[Name] ASC";

            var db = new SqlConnection(configuration["Database:Connection"]);

            var schools = await db.QueryAsync<SchoolResponse>(query, new {Id});

            return Results.Ok(schools);
        }
    }
}
