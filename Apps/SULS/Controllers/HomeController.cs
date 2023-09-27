using SULS.Services;
using SULS.ViewModels.Problems;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace SULS.Controllers
{
    
    public class HomeController: Controller
    {
        private readonly IProblemService problemsService;
        public HomeController(IProblemService problemsService)
        {
            this.problemsService = problemsService;
        }

        public IProblemService ProblemService { get; }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                var viewModel = this.problemsService.GetAll();
                return this.View(viewModel, "IndexLoggedIn");
            }
            else
            {
                return this.View();
            }
            
        }
    }
}
