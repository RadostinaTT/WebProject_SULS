using SULS.Data;
using SULS.ViewModels.Problems;
using System.Collections.Generic;
using System.Linq;

namespace SULS.Services
{
    public class ProblemService : IProblemService
    {
        private readonly ApplicationDbContext db;

        public ProblemService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public IEnumerable<HomePageProblemViewModel> GetAll()
        {
            var problems = this.db.Problems.Select(x => new HomePageProblemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count(),
            }).ToList();

            return problems;
        }

        public ProblemViewModel GetById(string Id)
        {
            var problem = this.db.Problems.Where(x => x.Id == Id).Select(x => new ProblemViewModel 
            {
                 Name = x.Name,
                 Submissions = x.Submissions.Select(s => new SubmissionViewModel
                 {
                      SubmissionId = s.Id,
                      CreatedOn = s.CreatedOn,
                      AchievedResult = s.AchievedResult,
                      MaxPoints = x.Points,
                      Username = s.User.Username,
                 }),
            }).FirstOrDefault();
            return problem;
        }

        public string GetNameById(string Id)
        {
            var name = this.db.Problems.Where(x => x.Id == Id).Select(x => x.Name).FirstOrDefault();

            return name;
        }
    }
}
