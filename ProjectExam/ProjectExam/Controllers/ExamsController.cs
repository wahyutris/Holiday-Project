using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectExam.Models;
using System.Net;
using System.Data.Entity;

namespace ProjectExam.Controllers
{
    public class ExamsController : Controller
    {
        private ExamDbContext db = new ExamDbContext();

        // GET: Exams
        public ActionResult Index()
        {
            return View(db.ExamDataBase.ToList());
        }

        public ActionResult Manage()
        {
            return View(db.ExamDataBase.ToList());
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Public,[Bind(Include = "Name,Description,Genre")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                exam.Owner = System.Web.HttpContext.Current.User.Identity.Name;
                exam.DateModified = DateTime.Now.ToString();
                exam.Status = Public;

                db.ExamDataBase.Add(exam);
                db.SaveChanges();

                return RedirectToAction("Manage");
            }

            return View(exam);            
        }       

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.ExamDataBase.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }

            //count questions
            ViewBag.countquestions = null;
            if (TempData["countquestions"] != null)
            {
                ViewBag.countquestions = (int)TempData["countquestions"];
            }

            return View(exam);
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.ExamDataBase.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Status,Genre,DateModified,TimesTaken,Owner")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Manage");
            }
            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.ExamDataBase.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.ExamDataBase.Find(id);
            db.ExamDataBase.Remove(exam);
            db.SaveChanges();
            return RedirectToAction("Manage");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AddNewQuestion(int? id)
        {
            ViewBag.ID = id;
            return View();
        }        
    }
}