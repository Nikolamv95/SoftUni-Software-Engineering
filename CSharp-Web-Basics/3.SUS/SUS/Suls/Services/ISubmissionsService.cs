using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Services
{
    public interface ISubmissionsService
    {
        public void Create(string problemId, string userId, string code);

        public void Delete(string id); 
    }
}
