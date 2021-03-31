using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using SharedTrip.Commons;
using SharedTrip.Services;
using SharedTrip.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
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
                return this.Redirect("/");
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

            return this.Redirect("/trips/all");
        }


        ////Register
        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UsersInputModel input)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Passwords should be similar!");
            }

            if (!this.usersService.IsUsernameAvailable(input.Username))
            {
                return this.Error("Username already exist");
            }

            if (!this.usersService.IsEmailAvailable(input.Email))
            {
                return this.Error("The email is already taken!");
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

            if (string.IsNullOrWhiteSpace(input.Email) || !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid email!");
            }

            if (input.Password == null 
                || input.Password.Length < GlobalConstants.PasswordMinLength 
                || input.Password.Length > GlobalConstants.PasswordMaxLength)
            {
                return this.Error("Invalid password. The password should be between 6 and 20 symbols");
            }

            this.usersService.CreateUser(input);
            return this.Redirect("login");
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
