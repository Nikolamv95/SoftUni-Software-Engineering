using System;
using System.Collections.Generic;
using System.Text;
using Git.Commons;
using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private ICommitsService commitsService;
        private IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        //Commits All
        public HttpResponse All()
        {
            if (IsUserSignedIn())
            {
                var userId = this.GetUserId();
                var commitsAll = this.commitsService.GetAllUserCommits(userId);
                return this.View(commitsAll);
            }
            else
            {
                var commitsAll = this.commitsService.GetAlCommits();
                return this.View(commitsAll);
            }
        }

        //CreateCommit
        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var commitToRepositoryViewModel = this.repositoriesService.GetRepositoryById(id);
            return this.View(commitToRepositoryViewModel);
        }

        [HttpPost]
        public HttpResponse Create(string id, string description)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (description.Length <= GlobalConstants.DescriptionMinLength)
            {
                return this.Error("Description should be at least 5 characters!");
            }

            var userId = this.GetUserId();

            this.commitsService.CreateCommit(id, userId, description);
            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.commitsService.DeleteCommit(id);
            return this.Redirect("/Commits/All");
        }

    }
}
