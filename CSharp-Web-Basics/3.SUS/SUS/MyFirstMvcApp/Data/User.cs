using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SUS.MvcFramework;

namespace BattleCards.Data
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Role = IdentityRole.User;
            this.UserCards = new HashSet<UserCard>();
        }

        public virtual ICollection<UserCard> UserCards { get; set; }
    }
}
