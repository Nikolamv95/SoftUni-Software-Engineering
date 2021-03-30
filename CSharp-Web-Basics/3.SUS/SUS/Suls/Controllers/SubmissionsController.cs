using System;
using System.Collections.Generic;
using System.Text;
using Suls.Services;
using Suls.ViewModels.Submissions;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {

        private IProblemsService problemsService;
        private ISubmissionsService submissionsService { get; }

        public SubmissionsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.submissionsService = submissionsService;
            this.problemsService = problemsService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            var viewModel = new CreateViewModel()
            {
                ProblemId = id,
                Name = problemsService.GetNameById(id),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            if (string.IsNullOrEmpty(code) || code.Length < 30 || code.Length > 800)
            {
                this.Error("Code should be between 30 and 800 length!");
            }

            var userId = this.GetUserId();
            this.submissionsService.Create(problemId, userId, code);

            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            this.submissionsService.Delete(id);
            return this.Redirect("/");
        }
    }
}
