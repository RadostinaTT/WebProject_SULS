using SULS.Data;
using System;
using System.Linq;

namespace SULS.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }
        
        public void Create(string problemId, string userId, string code)
        {
            var problemMaxPoints = this.db.Problems.Where(x => x.Id == problemId).Select(x => x.Points).FirstOrDefault();
            var submission = new Submission
            {
                Code = code,
                ProblemId = problemId,
                UserId = userId,
                AchievedResult = this.random.Next(0, problemMaxPoints + 1),
                CreatedOn = DateTime.UtcNow,
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string Id)
        {
            var submission = this.db.Submissions.Where(x => x.Id == Id).FirstOrDefault();
            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
