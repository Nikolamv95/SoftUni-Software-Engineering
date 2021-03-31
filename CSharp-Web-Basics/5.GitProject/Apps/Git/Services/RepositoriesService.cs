using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Git.Data;
using Git.ViewModels;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateRepository(RepositoryInputModel input)
        {
            try
            {
                var repository = new Repository()
                {
                    Name = input.Name,
                    CreatedOn = input.CreatedOn,
                    IsPublic = input.IsPublic,
                    OwnerId = input.OwnerId,
                };

                this.db.Repositories.Add(repository);
                this.db.SaveChanges();
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }

        }

        public IEnumerable<RepositoryViewModel> GetAll()
        {
            return this.db.Repositories
                .Where(x => x.IsPublic == true)
                .Select(x => new RepositoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    OwnerName = x.Owner.Username,
                    CreatedOn = x.CreatedOn,
                    CommitsCount = x.Commits.Count(),
                })
                .ToList();
        }

        public CommitToRepositoryViewModel GetRepositoryById(string repositoryId)
        {
            return this.db.Repositories
                .Where(x => x.Id == repositoryId)
                .Select(x => new CommitToRepositoryViewModel()
                {
                    RepositoryId = x.Id,
                    RepositoryName = x.Name,
                })
                .FirstOrDefault();
        }
    }
}
