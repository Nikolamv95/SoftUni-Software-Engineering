using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Suls.Data;

namespace Suls.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;
        private Random random;

        public SubmissionsService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = new Random();
        }

        public void Create(string problemId, string userId, string code)
        {
            var problemPoints = this.db.Problems
                .Where(x => x.Id == problemId)
                .Select(x => x.Points)
                .FirstOrDefault();

            var submission = new Submission()
            {
                Code = code,
                AchievedResult = (ushort)this.random.Next(0, problemPoints+1),
                CreatedOn = DateTime.UtcNow,
                ProblemId = problemId,
                UserId = userId,
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = this.db.Submissions.FirstOrDefault(x => x.Id == id);
            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
