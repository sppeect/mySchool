using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySchool.Api.EndPoints.School;
using MySchool.Api.EndPoints.Security;
using MySchool.Api.EndPoints.Teacher;
using MySchool.Api.EndPoints.Users;
using MySchool.Infraestruture.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["Database:Connection"], b => b.MigrationsAssembly("MySchool.Api"));   // Banco de dados
builder.Services.AddIdentity<IdentityUser, IdentityRole>() // Permissionamento
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddCors(option => option.AddPolicy("MySchoolAppPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .SetIsOriginAllowed((host) => true)
           .AllowAnyHeader();

}));

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
      .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
      .RequireAuthenticatedUser()
      .Build();
});
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JwtBearerTokenSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtBearerTokenSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JwtBearerTokenSettings:SecretKey"]))
    };
});


builder.Services.AddEndpointsApiExplorer(); // Swagger Map
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
}); //Swagger Service


builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json",
    "Api Documentation for MySchoolApp");
});
app.UseHsts();
app.UseHttpsRedirection();
app.UseCors("MySchoolAppPolicy");
app.UseForwardedHeaders();

app.Use(async (context, next) =>
{
    if (context.Request.IsHttps || context.Request.Headers["X-Forwarded-Proto"] == Uri.UriSchemeHttps)
    {
        await next();
    }
    else
    {
        string queryString = context.Request.QueryString.HasValue ? context.Request.QueryString.Value : string.Empty;
        var https = "https://" + context.Request.Host + context.Request.Path + queryString;
        context.Response.Redirect(https);
    }
});

app.UseAuthentication();
app.UseAuthorization();

#region Token
app.MapMethods(TokenPost.Template, TokenPost.Methods, TokenPost.Handle).AllowAnonymous().WithTags("Token API");
#endregion

#region Users
app.MapMethods(UsersPost.Template, UsersPost.Methods, UsersPost.Handle).AllowAnonymous().WithTags("Users");
app.MapMethods(UsersGetAll.Template, UsersGetAll.Methods, UsersGetAll.Handle).RequireAuthorization().WithTags("Users");
//app.MapMethods(UsersPut.Template, UsersPut.Methods, UsersPut.Handle).WithTags("Users");
#endregion

#region School
app.MapMethods(SchoolPost.Template, SchoolPost.Methods, SchoolPost.Handle).RequireAuthorization().WithTags("Schools");
app.MapMethods(SchoolGetAll.Template, SchoolGetAll.Methods, SchoolGetAll.Handle).RequireAuthorization().WithTags("Schools");
app.MapMethods(SchoolGetById.Template, SchoolGetById.Methods, SchoolGetById.Handle).RequireAuthorization().WithTags("Schools");
app.MapMethods(SchoolPut.Template, SchoolPut.Methods, SchoolPut.Handle).RequireAuthorization().WithTags("Schools");
app.MapMethods(SchoolDelete.Template, SchoolDelete.Methods, SchoolDelete.Handle).RequireAuthorization().WithTags("Schools");
#endregion

#region Teacher
app.MapMethods(TeacherPost.Template, TeacherPost.Methods, TeacherPost.Handle).RequireAuthorization().WithTags("Teacher");
app.MapMethods(TeacherGetAll.Template, TeacherGetAll.Methods, TeacherGetAll.Handle).RequireAuthorization().WithTags("Teacher");
app.MapMethods(TeacherGetById.Template, TeacherGetById.Methods, TeacherGetById.Handle).RequireAuthorization().WithTags("Teacher");
app.MapMethods(TeacherPut.Template, TeacherPut.Methods, TeacherPut.Handle).RequireAuthorization().WithTags("Teacher");
app.MapMethods(TeacherDelete.Template, TeacherDelete.Methods, TeacherDelete.Handle).RequireAuthorization().WithTags("Teacher");
#endregion



app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext http) =>
{
    var error = http.Features?.Get<IExceptionHandlerFeature>()?.Error;
    if (error != null)
    {
        if (error is SqlException)
            return Results.Problem(title: "Database Out", statusCode: 500);
    }
    return Results.Problem(title: " An error occurred", statusCode: 500);
});



app.Run();

