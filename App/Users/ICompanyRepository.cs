using IdeaDesignTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Users
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {

        Company GetCompany(int id);

        IEnumerable<Company> GetAllCompany();

        Company GetCompanyWithUsers(int id);

        IEnumerable<Company> GetCompanyListByFilter(string searchResult, int skip, int take);

    }
}
