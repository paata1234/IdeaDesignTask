using App.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Users
{
   public interface IRepositoryWrapper
    {
        IUserRepository GetUser { get; }
        ICompanyRepository GetCompany { get; }
        void Save();
    }
}
