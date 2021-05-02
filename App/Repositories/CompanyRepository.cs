using App.Users;
using IdeaDesignTask.Data;
using IdeaDesignTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {

        public CompanyRepository(Appdbcontext _db) : base (_db)
        {

        }


        public Company GetCompany(int id)
        {
           Company company = _db.Company.Where(c => c.id == id).FirstOrDefault();

           return company;
        }

        public IEnumerable<Company> GetAllCompany()
        {
            IEnumerable<Company> company = _db.Company.ToList();
            return company;
        }

    }
}
