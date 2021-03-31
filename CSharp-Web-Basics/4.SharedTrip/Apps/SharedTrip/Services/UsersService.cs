using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using SharedTrip.Data;
using SharedTrip.ViewModels.Users;

namespace SharedTrip.Services
{
    public class UsersService : IUsersService
    {
        private ApplicationDbContext db;


        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }


        public void CreateUser(UsersInputModel input)
        {
            try
            {
                var user = new User()
                {
                    Username = input.Username,
                    Password = ComputeHash(input.Password),
                    Email = input.Email,
                };

                this.db.Users.Add(user);
                this.db.SaveChanges();
            }
            catch (ArgumentException ar)
            {
                throw ar;
            }
        }
        public string GetUserId(string username, string password)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Username == username);
            if (user?.Password != ComputeHash(password))
            {
                return null;
            }

            return user.Id;
        }
        public bool IsUsernameAvailable(string username)
        {
            return !this.db.Users.Any(x => x.Username == username);
        }
        public bool IsEmailAvailable(string email)
        {
            return !this.db.Users.Any(x => x.Email == email);
        }

        private static string ComputeHash(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);

            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);

            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new StringBuilder(128);

            foreach (var b in hashedInputBytes)
            {
                hashedInputStringBuilder.Append(b.ToString("X2"));
            }

            return hashedInputStringBuilder.ToString();
        }
    }
}
