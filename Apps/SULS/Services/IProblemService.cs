using SULS.ViewModels.Problems;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface IProblemService
    {
        void Create(string name, int points);

        IEnumerable<HomePageProblemViewModel> GetAll();

        string GetNameById(string Id);

        ProblemViewModel GetById(string Id);
    }
}
