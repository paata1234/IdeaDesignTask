using cloudscribe.Pagination.Models;
using IdeaDesignTask.Data;
using IdeaDesignTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeaDesignTask.Controllers
{
    public class DependenceController : Controller
    {
        public readonly Appdbcontext _db;

        public DependenceController(Appdbcontext db)
        {
            _db = db;
        }


        public IActionResult Index(int? id)

        {
            var user = _db.Physicalusers.Find(id);

            user.Company = _db.Company.ToList();

           

            return View(user);
        }


        
        public IActionResult AddCompany(int? companyid , int? userid)
        {
            if(companyid == null || companyid == 0 || userid == null || userid == 0)
            {
                return NotFound();
            }

            var company = _db.Company.Where(c => c.id == companyid).Include(u => u.Users).ToList();

            var user = _db.Physicalusers.Find(userid);


            if(company[0].Users.Contains(user))
            {
                return RedirectToAction("ErroMsg");      
            }

            company[0].Users.Add(user);
      
            _db.SaveChanges();



            return RedirectToAction("Index", "Users");
        }


        public IActionResult ErroMsg()
        {
            return View();
        }


    }
}
