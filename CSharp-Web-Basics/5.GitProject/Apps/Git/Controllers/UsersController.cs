using Git.Commons;
using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        //Login
        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.usersService.GetUserId(username, password);
            if (userId == null)
            {
                return this.Error("The username or password is invalid!");
            }

            this.SignIn(userId);
            return this.Redirect("/Repositories/All");
        }

        //Register
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserInputModel input)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Repositories/All");
            }


            if (input.Username == null
                || input.Username.Length < GlobalConstants.UsernameMinLength
                || input.Username.Length > GlobalConstants.UsernameMaxLength)
            {
                return this.Error("Invalid username. Username should be between 5 and 20 symbols");
            }

            if (!Regex.IsMatch(input.Username, @"^[a-zA-Z0-9\.]+$"))
            {
                return this.Error("Invalid username. Only alphanumeric characters are allowed");
            }

            if (!this.usersService.IsUsernameAvailable(input.Username))
            {
                return this.Error("Username already exist");
            }


            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Passwords should be similar!");
            }

            if (input.Password == null
                || input.Password.Length < GlobalConstants.PasswordMinLength
                || input.Password.Length > GlobalConstants.PasswordMaxLength)
            {
                return this.Error("Invalid password. The password should be between 6 and 20 symbols");
            }


            if (!this.usersService.IsEmailAvailable(input.Email))
            {
                return this.Error("The email is already taken!");
            }

            if (string.IsNullOrWhiteSpace(input.Email) || !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid email!");
            }

            this.usersService.CreateUser(input);
            return this.Redirect("Login");
        }

        //Logout
        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Only logged-in users can logout!");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
