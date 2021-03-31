using System;
using System.Collections.Generic;
using System.Text;
using Git.ViewModels;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        public void CreateRepository(RepositoryInputModel input);
        public IEnumerable<RepositoryViewModel> GetAll();

        public CommitToRepositoryViewModel GetRepositoryById(string repositoryId);
    }
}
