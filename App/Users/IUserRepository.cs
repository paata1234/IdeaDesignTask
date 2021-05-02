using IdeaDesignTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Users
{
     public interface IUserRepository : IRepositoryBase<Physicalusers>
    {

        Physicalusers GetUser (int id);


    }
}
