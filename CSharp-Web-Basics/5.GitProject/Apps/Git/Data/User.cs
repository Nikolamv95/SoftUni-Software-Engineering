﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Git.Commons;

namespace Git.Data
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Repositories = new HashSet<Repository>();
            this.Commits = new HashSet<Commit>();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Repository> Repositories { get; set; }
        public virtual ICollection<Commit> Commits { get; set; }

    }
}
