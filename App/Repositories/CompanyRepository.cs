using App.Users;
using IdeaDesignTask.Data;
using IdeaDesignTask.Models;
using Microsoft.EntityFrameworkCore;
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


        public Company GetCompanyWithUsers(int id)
        {
            var c = _db.Company.Where(x=>x.id == id).Include(x=>x.Users).FirstOrDefault();

            return c;
        }

        public IEnumerable<Company> GetCompanyListByFilter(string searchResult, int skip, int take)
        {
            var c = _db.Company
                .Where(e => e.name.Contains(searchResult) || e.address.Contains(searchResult) || e.business.Contains(searchResult))
                .Skip(skip).Take(take).AsEnumerable();

            return c;
        }

        
    }
}
