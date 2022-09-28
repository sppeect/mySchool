using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySchool.Command.Users.Request;
using System.Security.Claims;

namespace MySchool.Command.Users.Handlers
{
    public class UserHandlers
    {
        [AllowAnonymous]
        public static async Task<IResult> ActionPost(UserManager<IdentityUser> userManager, UserRequest userRequest )
        {
            var user = new IdentityUser { UserName = userRequest.UserName, Email = userRequest.Email };
            var result = await userManager.CreateAsync(user, userRequest.Password);

            if (userRequest.Email == null)
                return Results.NotFound();

            if (!result.Succeeded)
                return Results.NotFound();

            var userClaims = new List<Claim>
            {
                new Claim("Identifier", userRequest.Email),
                new Claim("Nome", userRequest.UserName)
            };
            
           var claimResult = await userManager.AddClaimsAsync(user, userClaims);

            if (!claimResult.Succeeded)
                return Results.NotFound();


            return Results.Created($"/users/{user.Id}", "Id:" + user.Id);
        }

        //[AllowAnonymous]
        //public static async Task<IResult> ActionPut([FromRoute] string Id, UserManager<IdentityUser> userManager, UserRequest userRequest)
        //{
        //    var userExist = await userManager.FindByIdAsync(Id);
        //    if (userExist == null)
        //        return Results.NotFound();
            
        //   var updateUser = await userManager.UpdateAsync(userExist)
        //    if (!updateUser.Succeeded)
        //        return Results.BadRequest("Algo deu errado");
            
        //   var updatePw = await userManager.ChangePasswordAsync(userExist, userExist.PasswordHash, userRequest.Password);

        //    if (!updatePw.Succeeded)
        //        return Results.BadRequest(updatePw.Errors.FirstOrDefault());

        //    return Results.Ok("Usuario atualizado com sucesso" + userExist.Id);
        //}
    }
}
