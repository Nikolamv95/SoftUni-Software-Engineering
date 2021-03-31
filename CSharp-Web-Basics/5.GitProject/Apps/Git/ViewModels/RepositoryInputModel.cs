using System;
using System.Collections.Generic;
using System.Text;

namespace Git.ViewModels
{
    public class RepositoryInputModel
    {
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsPublic { get; set; }
        public string OwnerId { get; set; }
    }
}
