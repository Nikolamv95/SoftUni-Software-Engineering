using System;
using System.Collections.Generic;
using System.Text;
using Git.Commons;
using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        //TODO: when public private repositories
        public HttpResponse All()
        {
            var repositoriesAll = this.repositoriesService.GetAll();
            return this.View(repositoriesAll);
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
        public HttpResponse Create(string name, string repositoryType)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var repositoryInputModel = new RepositoryInputModel();

            if (string.IsNullOrWhiteSpace(name))
            {
                return this.Error("Repository name could not be empty!");
            }

            if (name.Length < GlobalConstants.RepositoryNameMinLength || name.Length > GlobalConstants.RepositoryNameMaxLength)
            {
                return this.Error("Repository name should be between 2 and 6 characters!");
            }

            if (repositoryType == null)
            {
                return this.Error("Repository type could not be empty!");
            }

            if (repositoryType == "Public")
            {
                repositoryInputModel.IsPublic = true;
            }
            else
            {
                repositoryInputModel.IsPublic = false;
            }

            repositoryInputModel.Name = name;
            repositoryInputModel.CreatedOn = DateTime.UtcNow;
            repositoryInputModel.OwnerId = this.GetUserId();

            this.repositoriesService.CreateRepository(repositoryInputModel);

            return this.Redirect("/Repositories/All");
        }
    }
}
