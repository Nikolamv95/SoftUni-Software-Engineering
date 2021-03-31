using System;
using System.Collections.Generic;
using System.Text;
using SharedTrip.ViewModels.Users;

namespace SharedTrip.Services
{
    public interface IUsersService
    {
        public void CreateUser(UsersInputModel input);
        public string GetUserId(string username, string password);
        public bool IsUsernameAvailable(string username);
        public bool IsEmailAvailable(string email);
    }
}
