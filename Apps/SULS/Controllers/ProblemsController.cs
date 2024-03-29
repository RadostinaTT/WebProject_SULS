﻿using SULS.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SULS.Controllers
{
    public class ProblemsController: Controller
    {
        private readonly IProblemService problemService;

        public ProblemsController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, int points)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 5 || name.Length > 20)
            {
                return this.Error("Name should be between 5 and 20 characters.");
            }
            if (points < 50 || points > 300)
            {
                return this.Error("Points should be between 50 and 300.");
            }

            this.problemService.Create(name, points);
            return this.Redirect("/");
        }

        public HttpResponse Details(string Id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.problemService.GetById(Id);
            return this.View(viewModel);
        }

    }
}
