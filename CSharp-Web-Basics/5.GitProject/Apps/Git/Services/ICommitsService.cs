using System;
using System.Collections.Generic;
using System.Text;
using Git.ViewModels;

namespace Git.Services
{
    public interface ICommitsService
    {
        public IEnumerable<CommitsViewModel> GetAllUserCommits(string userId);
        public IEnumerable<CommitsViewModel> GetAlCommits();
        public void CreateCommit(string repositoryId, string creatorId, string description);
        public void DeleteCommit(string commitId);
    }
}
