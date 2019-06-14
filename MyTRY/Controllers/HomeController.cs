using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MvcSql.Domain;
using MyTRY.Domain;
using MyTRY.Models;



namespace MyTRY.Controllers
{
    public class HomeController : Controller
    {
        private readonly PeoplesRepository peoplesRepository;
        private object peopelsSite;

        public HomeController(PeoplesRepository peoplesRepository)
        {
            this.peoplesRepository = peoplesRepository;
        }



        public IActionResult Index(string searching)
        {
            var model = peoplesRepository.GetPeopels();
            return View(model);
        }

        public IActionResult PeopelsEdit(Guid id)
        {
            People model = id == default ? new People() : peoplesRepository.GetPeopleById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult PeopelsEdit(People model)
        {
            if (ModelState.IsValid)
            {
                peoplesRepository.SavePeople(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult PeopelsDelete(Guid id)
        {
            peoplesRepository.DeletePeople(new People { Id = id });
            return RedirectToAction("Index");
        }

        //public JsonResult GetSearchingData(string SearchBy, string SearchValue)
        //{
        //    List<People> peopList = new List<People>();           
        //   peopList = db.Peoples.Where(x => x.FIO.StartsWith(SearchValue) || SearchValue == null).ToList();
        //    return Json(peopList, JsonRequestBehavior.AllowGet);
        //    
        //
        //}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
