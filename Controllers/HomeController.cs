using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission_13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }
        private Bowler bowler { get; set; }
        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            //var bowlers = _context.Bowlers
            //    //.Include(x => ) USED FOR LINKING TO THE TEAMS TABLE
            //    .FromSqlRaw("SELECT * FROM BowlingLeagueExample") // Maybe for only displaying certain teams
            //    .ToList();

            var bowlers = _repo.Bowlers
                .ToList();

            return View(bowlers);
        }

        // ADD Bowler
        [HttpGet]
        public IActionResult BowlerForm()
        {
            //ViewBag.Categories = tContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult BowlerForm(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateBowler(b);

                return RedirectToAction("Index");
            }
            else
            {
                //ViewBag.Categories = tContext.Categories.ToList();
                return View(b);
            }
        }


        //// EDIT TASK
        //[HttpGet]
        //public IActionResult EditTask(int taskid)
        //{
        //    ViewBag.Categories = tContext.Categories.ToList();

        //    var task = tContext.Tasks.Single(x => x.TaskId == taskid);
        //    return View("TaskForm", task);
        //}

        //[HttpPost]
        //public IActionResult EditTask(TaskModel t)
        //{
        //    tContext.Update(t);
        //    tContext.SaveChanges();

        //    return RedirectToAction("TaskQuadrants");
        //}


        //// Delete task
        //[HttpGet]
        //public IActionResult DeleteTask(int taskid)
        //{
        //    var task = tContext.Tasks.Single(x => x.TaskId == taskid);
        //    return View(task);
        //}

        //[HttpPost]
        //public IActionResult DeleteTask(TaskModel t)
        //{
        //    tContext.Tasks.Remove(t);
        //    tContext.SaveChanges();

        //    return RedirectToAction("TaskQuadrants");
        //}
    }
}
