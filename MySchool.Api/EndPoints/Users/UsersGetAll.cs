using MySchool.ReadModel.Users.Handlers;

namespace MySchool.Api.EndPoints.Users
{
    public class UsersGetAll
    {
        public static string Template => "v1/users";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => UserReadHandler.ActionGetAll;
    }
}
