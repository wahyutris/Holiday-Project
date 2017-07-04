using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectExam.Models;
using System.Net;
using System.Data.Entity;
using System.Web.Routing;

namespace ProjectExam.Controllers
{
    public class LeaderBoardsController : Controller
    {
        private LeaderBoardsDbContext db = new LeaderBoardsDbContext();

        // GET: LeaderBoards
        public ActionResult Index()
        {
            List<LeaderBoards> leaderBoardsList = new List<LeaderBoards>();
            var query = db.LeaderBoardsDatabase.ToList().OrderBy(t=>t.Time).GroupBy(u=>u.UserName).Last();
            //var parts = query.ToList();
            foreach(var a in query)
            {
                if (!leaderBoardsList.Contains(new LeaderBoards()
                 {
                     UserName = a.UserName
                 }))
                {
                    leaderBoardsList.Add(new LeaderBoards()
                    {
                        UserName = a.UserName,
                        ID = a.ID,
                        Score = a.Score,
                        Time = a.Time
                    });
                }                
            }
            //return View(db.LeaderBoardsDatabase.OrderBy(t=>t.Time).GroupBy(u=>u.UserName).Last());

            var q = from e in db.LeaderBoardsDatabase
                    group e by e.UserName into g
                    select new
                    {
                        Key = g.Key,
                        Value = g.OrderBy(v => v.Time).Last()
                    };
            //return View(q.ToList());    

            //var distinctLeaderBoards = db.LeaderBoardsDatabase.GroupBy(l => l.UserName).Last().ToList();
            return View(db.LeaderBoardsDatabase.ToList());
        }

        // GET: LeaderBoards/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaderBoards leaderBoards)
        {
            var totalCorrect = (int)TempData["totalCorrect"];

            leaderBoards.UserName = System.Web.HttpContext.Current.User.Identity.Name;
            leaderBoards.Score = totalCorrect * 10;
            leaderBoards.Time = DateTime.Now;

            db.LeaderBoardsDatabase.Add(leaderBoards);
            db.SaveChanges();

            return RedirectToAction("Index");            
        }
    }
}