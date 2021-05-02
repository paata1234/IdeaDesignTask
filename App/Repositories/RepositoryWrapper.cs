using App.Users;
using IdeaDesignTask.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories
{
   public class RepositoryWrapper : IRepositoryWrapper
    {

        private Appdbcontext _db;
        private IUserRepository userRepository;
        private ICompanyRepository companyRepository;

        public RepositoryWrapper(Appdbcontext db)
        {
            _db = db;
        }

        public IUserRepository GetUser { 
            get
            {
                if(userRepository == null)               
                    userRepository = new UserRepository(_db);
                 return userRepository;
                
            }
        }

        public ICompanyRepository GetCompany
        {
            get
            {
                if (companyRepository == null)
                    companyRepository = new CompanyRepository(_db);
                return companyRepository;
            }
        }


        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
