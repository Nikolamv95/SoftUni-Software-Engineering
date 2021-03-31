using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Commons
{
    public class GlobalConstants
    {
        //User
        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;
        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 20;

        //Repository
        public const int RepositoryNameMinLength = 3;
        public const int RepositoryNameMaxLength = 10;

        //Commits
        public const int DescriptionMinLength = 5;

    }
}
