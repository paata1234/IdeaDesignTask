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
     public class UserRepository : RepositoryBase<Physicalusers>, IUserRepository
    {

        public UserRepository(Appdbcontext db) : base(db)
        {

        }

        public Physicalusers GetUser(int id)
        {
            Physicalusers user = _db.Physicalusers.Where(u => u.id == id).FirstOrDefault();

            return user;
        }






    }
}
