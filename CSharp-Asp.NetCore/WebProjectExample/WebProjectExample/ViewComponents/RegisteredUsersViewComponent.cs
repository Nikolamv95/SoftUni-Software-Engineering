using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProjectExample.Data;
using WebProjectExample.Services;
using WebProjectExample.ViewModels.ViewComponents;

namespace WebProjectExample.ViewComponents
{
    public class RegisteredUsersViewComponent : ViewComponent
    {
        private readonly IInstanceCounter instanceCounter;
        public ApplicationDbContext dbContext { get; }

        public RegisteredUsersViewComponent(ApplicationDbContext dbContext, IInstanceCounter instanceCounter)
        {
            this.instanceCounter = instanceCounter;
            this.dbContext = dbContext;
        }

        public IViewComponentResult Invoke(string title)
        {
            var users = this.dbContext.Users.Count();
            var viewModel = new RegisteredUsersViewModel()
            {
                Title = title,
                UsersCount = users,
            };

            return this.View(viewModel);
        }
    }
}
