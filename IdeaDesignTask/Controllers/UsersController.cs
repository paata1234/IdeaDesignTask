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
    public class UsersController : Controller
    {
        public readonly Appdbcontext _db;

        public UsersController(Appdbcontext db)
        {
            _db = db;
        }


        public IActionResult Index(int pagenumber = 1 , int pagesize = 5)
        {
            int ExcludeRecords = (pagesize * pagenumber) - pagesize;

            var Users = _db.Physicalusers.Skip(ExcludeRecords).Take(pagesize).ToList();

            var Result = new PagedResult<Physicalusers>
            {
                Data = Users.ToList(),
                TotalItems = _db.Physicalusers.Count(),
                PageNumber = pagenumber,
                PageSize = pagesize
            };

            return View(Result) ;
        }

        [HttpPost]
        public IActionResult Index(string SearchResult , int pagenumber = 1, int pagesize = 5)
        {
            if(SearchResult == null)
            {
                return RedirectToAction("Index");
            }

            int ExcludeRecords = (pagesize * pagenumber) - pagesize;

            var Searchresult = _db.Physicalusers.Where(e => e.name.Contains(SearchResult) || e.surname.Contains(SearchResult)).Skip(ExcludeRecords).Take(pagesize).ToList();

            var Result = new PagedResult<Physicalusers>
            {
                Data = Searchresult.ToList(),
                TotalItems = Searchresult.Count(),
                PageNumber = pagenumber,
                PageSize = pagesize
            };


            return View(Result);
        }

        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNew(Physicalusers obj)
        {
            if(ModelState.IsValid)
            {
                _db.Physicalusers.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

       public IActionResult AllInfo(int? id)
        {
            if(id == 0 && id == null)
            {
                return NotFound();
            }
            var obj = _db.Physicalusers.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var obj = _db.Physicalusers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Physicalusers obj)
        {
            _db.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id == null && id == 0)
            {
                return NotFound();
            }
            var obj = _db.Physicalusers.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            else
            {
                _db.Remove(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult CompanyInfo(int? id , int pagenumber = 1, int pagesize = 10)
        {
            int ExcludeRecords = (pagesize * pagenumber) - pagesize;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Physicalusers.Where(e => e.id == id).Include(c => c.Company).Skip(ExcludeRecords).Take(pagesize).ToList();

            var Result = new PagedResult<Physicalusers>
            {
                Data = obj.ToList(),
                TotalItems = obj.Count(),
                PageNumber = pagenumber,
                PageSize = pagesize
            };

            return View(Result);

        }


        public IActionResult DeleteUser(int? userid, int? companyid)
        {
            if(userid == null || userid == 0 || companyid == null || companyid == 0)
            {
                return RedirectToAction("Index", "Company");
            }

            var user = _db.Physicalusers.Find(userid);
            var com = _db.Company.Where(c => c.id == companyid).Include(u => u.Users).ToList();
            com[0].Users.Remove(user);
            

            _db.SaveChanges();

            return RedirectToAction("Index", "Company");
        }

    }
}
