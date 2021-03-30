using System;
using System.Collections.Generic;
using System.Text;
using Suls.ViewModels.Problems;

namespace Suls.Services
{
    public interface IProblemsService
    {
        void Create(string name, ushort points);
        string GetNameById(string id);
        ProblemViewModel GetById(string id);
        IEnumerable<HomePageProblemViewModel> GetAll();
    }
}
