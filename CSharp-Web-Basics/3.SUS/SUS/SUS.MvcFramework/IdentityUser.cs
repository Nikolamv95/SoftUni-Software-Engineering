using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SUS.MvcFramework
{
    //If the data type of the Id for this UserIdentity<T> class is string, the classes which inherited this
    //base class should use the same data type. Example User : UserIdentity<string> (because the id is string, if it was int)
    //the example should be User : UserIdentity<int>
    public class IdentityUser<T>
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public IdentityRole Role { get; set; }
    }
}
