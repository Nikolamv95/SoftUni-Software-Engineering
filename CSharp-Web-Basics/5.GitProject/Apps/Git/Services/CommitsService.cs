using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Git.Data;
using Git.ViewModels;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CommitsViewModel> GetAllUserCommits(string userId)
        {
            return this.db.Commits
                .Where(x => x.Creator.Id == userId)
                .Select(SelectCommitsViewModel())
                .ToList();
        }

        public IEnumerable<CommitsViewModel> GetAlCommits()
        {
            return this.db.Commits
                .Select(SelectCommitsViewModel())
                .ToList();
        }

        public void CreateCommit(string repositoryId, string creatorId, string description)
        {
            try
            {
                var commit = new Commit()
                {
                    Description = description,
                    CreatedOn = DateTime.UtcNow,
                    CreatorId = creatorId,
                    RepositoryId = repositoryId,
                };

                this.db.Commits.Add(commit);
                this.db.SaveChanges();
            }
            catch (ArgumentException ar)
            {
                throw ar;
            }
        }

        public void DeleteCommit(string commitId)
        {
            var commit = this.db.Commits.FirstOrDefault(x => x.Id == commitId);
            this.db.Commits.Remove(commit);
            this.db.SaveChanges();

        }

        private static Expression<Func<Commit, CommitsViewModel>> SelectCommitsViewModel()
        {
            return x => new CommitsViewModel()
            {
                Id = x.Id,
                Repository = x.Repository.Name,
                Description = x.Description,
                CreatedOn = x.CreatedOn
            };
        }
    }
}
