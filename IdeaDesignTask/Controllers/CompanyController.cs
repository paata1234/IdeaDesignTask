using App.Users;
using cloudscribe.Pagination.Models;
using IdeaDesignTask.Data;
using IdeaDesignTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;



namespace IdeaDesignTask.Controllers
{
    public class CompanyController : Controller
    {
        public readonly IRepositoryWrapper repositoryWrapper;

        public CompanyController(IRepositoryWrapper repositoryWrapper
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        public IActionResult Index(int pagenumber = 1, int pagesize = 5)
        {
            int ExcludeRecords = (pagesize * pagenumber) - pagesize;

            IEnumerable<Company> company = repositoryWrapper..Skip(ExcludeRecords).Take(pagesize);

            var Result = new PagedResult<Company>
            {
                Data = company.ToList(),
                TotalItems = _db.Company.Count(),
                PageNumber = pagenumber,
                PageSize = pagesize
            };

            return View(Result);
        }

        [HttpPost]
        public IActionResult Index(string SearchResult, int pagenumber = 1, int pagesize = 5)
        {
            if (SearchResult == null)
            {
                return RedirectToAction("Index");
            }

            int ExcludeRecords = (pagesize * pagenumber) - pagesize;

            var Searchresult = _db.Company.Where(e => e.name.Contains(SearchResult) || e.address.Contains(SearchResult) || e.business.Contains(SearchResult)).Skip(ExcludeRecords).Take(pagesize).ToList();

            var Result = new PagedResult<Company>
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
        public IActionResult AddNew(Company obj)
        {
            if (ModelState.IsValid)
            {
                _db.Company.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult AllInfo(int? id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var obj = _db.Company.Find(id);

            if (obj == null)
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
            var obj = _db.Company.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Company obj)
        {
            _db.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            var obj = _db.Company.Find(id);
            if (obj == null)
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

        public IActionResult UsersInfo(int? id, int pagenumber = 1, int pagesize = 10)
        {
            int ExcludeRecords = (pagesize * pagenumber) - pagesize;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Company.Where(e => e.id == id).Include(c=> c.Users).Skip(ExcludeRecords).Take(pagesize).ToList();

            var Result = new PagedResult<Company>
            {
                Data = obj.ToList(),
                TotalItems = obj.Count(),
                PageNumber = pagenumber,
                PageSize = pagesize
            };

            return View(Result);
        }


    }
}

