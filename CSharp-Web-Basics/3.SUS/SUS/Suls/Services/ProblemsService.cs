using Suls.Data;
using Suls.ViewModels.Problems;
using System.Collections.Generic;
using System.Linq;

namespace Suls.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext db;

        public ProblemsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, ushort points)
        {
            var problem = new Problem()
            {
                Name = name,
                Points = points,
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public string GetNameById(string id)
        {
            return this.db.Problems.Where(x => x.Id == id).Select(x => x.Name).FirstOrDefault();
        }

        public ProblemViewModel GetById(string problemId)
        {
            return this.db.Problems
                .Where(x => x.Id == problemId)
                .Select(x => new ProblemViewModel()
                {
                    Name = x.Name,
                    Submissions = x.Submissions.Select(s => new SubmissionViewModel()
                    {
                        Username = s.User.Username,
                        SubmissionId = s.Id,
                        AchievedResult = s.AchievedResult,
                        MaxPoints = x.Points,
                        CreatedOn = s.CreatedOn,
                    }).ToList()
                })
                .FirstOrDefault();
        }

        public IEnumerable<HomePageProblemViewModel> GetAll()
        {
            var problems = this.db.Problems
                .Select(x => new HomePageProblemViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = x.Submissions.Count(),
                })
                .ToList();

            return problems;
        }
    }
}
