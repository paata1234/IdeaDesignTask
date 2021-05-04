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

        public CompanyController(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        public IActionResult Index(int pagenumber = 1, int pagesize = 5)
        {
            int ExcludeRecords = (pagesize * pagenumber) - pagesize;

            IEnumerable<Company> company = repositoryWrapper.GetCompany.GetAllCompany().Skip(ExcludeRecords).Take(pagesize);

            var Result = new PagedResult<Company>
            {
                Data = company.ToList(),
                TotalItems = repositoryWrapper.GetCompany.GetAllCompany().Count(),
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

            var Searchresult = repositoryWrapper.GetCompany.GetCompanyListByFilter(SearchResult, ExcludeRecords, pagesize);

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
                repositoryWrapper.GetCompany.Create(obj);
                repositoryWrapper.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult AllInfo(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var obj = repositoryWrapper.GetCompany.GetCompany(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var obj = repositoryWrapper.GetCompany.GetCompany(id);
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
            repositoryWrapper.GetCompany.Update(obj);
            repositoryWrapper.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var obj = repositoryWrapper.GetCompany.GetCompany(id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                var comp = repositoryWrapper.GetCompany.GetCompany(id);
                repositoryWrapper.GetCompany.Delete(comp);
                repositoryWrapper.Save();
            }
            return RedirectToAction("Index");
        }

        public IActionResult UsersInfo(int id, int pagenumber = 1, int pagesize = 10)
        {
            //int ExcludeRecords = (pagesize * pagenumber) - pagesize;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var obj = repositoryWrapper.GetCompany.Get(id);

            var c = repositoryWrapper.GetCompany.GetCompanyWithUsers(id);

            //var Result = new PagedResult<Company>
            //{
            //    Data = users.ToList(),
            //    TotalItems = users.Count(),
            //    PageNumber = pagenumber,
            //    PageSize = pagesize
            //};

            return View(c);
        }


    }
}

