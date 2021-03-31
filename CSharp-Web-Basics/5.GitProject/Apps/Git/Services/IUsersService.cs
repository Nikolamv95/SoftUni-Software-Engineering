using Git.ViewModels;

namespace Git.Services
{
    public interface IUsersService
    {
        string CreateUser(UserInputModel input);

        bool IsEmailAvailable(string email);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);
    }
}
