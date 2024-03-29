﻿using System;
using System.Collections.Generic;
using System.Text;
using Suls.Services;
using Suls.ViewModels.Problems;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class HomeController : Controller
    {

        private IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

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
