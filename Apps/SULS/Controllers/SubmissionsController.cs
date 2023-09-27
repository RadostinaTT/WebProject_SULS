using SULS.Services;
using SULS.ViewModels.Submissions;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SULS.Controllers
{
    public class SubmissionsController: Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        public SubmissionsController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }
        public HttpResponse Create(string Id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new CreateViewModel
            {
                ProblemId = Id,
                Name = this.problemService.GetNameById(Id),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            var userId = this.GetUserId();

            if (string.IsNullOrEmpty(code) || code.Length < 30 || code.Length > 800)
            {
                return this.Error("Code should be between 30 and 800 characters.");
            }

            this.submissionService.Create(problemId, userId, code);
            return this.Redirect("/");
        }

        public HttpResponse Delete(string Id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.submissionService.Delete(Id);
            return this.Redirect("/");
        }
    }
}
