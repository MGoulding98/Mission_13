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

        private BowlersDbContext tContext { get; set; }
        private Bowler bowler { get; set; }
        public HomeController(IBowlersRepository temp, BowlersDbContext context)
        {
            tContext = context;
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
            ViewBag.Teams = tContext.Teams.ToList();
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


        // EDIT TASK
        [HttpGet]
        public IActionResult EditBowler(int bowlerid)
        {
            var bowler = _repo.GetBowler(bowlerid);
            ViewBag.Teams = tContext.Teams.ToList();

            return View("BowlerForm", bowler);
        }

        [HttpPost]
        public IActionResult EditBowler(Bowler b)
        {
            _repo.EditBowler(b);

            return RedirectToAction("Index");
        }


        // Delete Bowler
        public IActionResult DeleteBowler(int bowlerid)
        {
            _repo.DeleteBowler(bowlerid);

            return RedirectToAction("Index");
        }
    }
}
