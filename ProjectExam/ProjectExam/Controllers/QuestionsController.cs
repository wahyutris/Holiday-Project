using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectExam.Models;

namespace ProjectExam.Controllers
{
    public class QuestionsController : Controller
    {
        private QuestionDbContext db = new QuestionDbContext();

        // GET: Questions
        public ActionResult Index()
        {
            return View(db.QuestionDataBase.ToList());
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.QuestionDataBase.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GroupingId,QuestionDescription,MultipleChoiceCorrect,MultipleChoiceB,MultipleChoiceC,MultipleChoiceD,Answerexplanation")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.QuestionDataBase.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.QuestionDataBase.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GroupingId,QuestionDescription,MultipleChoiceCorrect,MultipleChoiceB,MultipleChoiceC,MultipleChoiceD,Answerexplanation")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.QuestionDataBase.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.QuestionDataBase.Find(id);
            db.QuestionDataBase.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AddNewQuestionAction(string id, string question, string answer, string optionb, string optionc, string optiond)
        {
            Question newQuestion = new Question();

            int newID = 0;
            Int32.TryParse(id, out newID);

            newQuestion.GroupingId = newID;
            newQuestion.QuestionDescription = question; //+ " :  ID = " + newID;
            newQuestion.MultipleChoiceCorrect = answer;
            newQuestion.MultipleChoiceB = optionb;
            newQuestion.MultipleChoiceC = optionc;
            newQuestion.MultipleChoiceD = optiond;

            db.QuestionDataBase.Add(newQuestion);
            db.SaveChanges();

            //pass id to add another question view
            TempData["id"] = id;

            return RedirectToAction("AddAnotherQuestion");
        }

        public ActionResult AddAnotherQuestion()
        {

            ViewBag.id = (string)TempData["id"];

            return View();
        }

        // pass countQuestion to details in exams controller using TempData
        public ActionResult CountQuestionsInTest(int? id)
        {
            var questions = from m in db.QuestionDataBase
                            select m;
            if (id != null)
            {
                questions = questions.Where(s => s.GroupingId == id);
            }

            int countquestions = questions.Count<Question>();
            TempData["countquestions"] = countquestions;

            return RedirectToAction("Details/" + id, "Exams");
        }

        public ActionResult StartExamPreFormatting(int? searchid)
        {
            /*steps
             * 1. get test id
             * 2. use test id to get all related questions from the database
             * 3. save related questions to globals list //will be using tempdata now.
             * 4. redirect
             * */

            var questions = from m in db.QuestionDataBase
                            select m;
            if (searchid != null)
            {
                questions = questions.Where(s => s.GroupingId == searchid);
            }

            var tempQuestionlist = new List<Question>();
            tempQuestionlist = questions.ToList<Question>();

            TempData["tempQuestionlist"] = tempQuestionlist;

            //create a tempdata list to show answers in the final results page
            var reviewlist = new List<Question>();
            TempData["reviewlist"] = reviewlist;
            //create a tempdata list to track correct or incorrect answers.
            var CorrectorIncorrect = new List<string>();
            TempData["CorrectorIncorrect"] = CorrectorIncorrect;

            //debugging on this methods view
            ViewBag.globals = Globals.GlobalQuestionList;
            ViewBag.count = Globals.GlobalQuestionList.Count();

            //attempt to swith question authetication over to temp data
            double questionscorrect = 0;
            double questionswrong = 0;
            int questioncount = 1;
            TempData["questionscorrect"] = questionscorrect;
            TempData["questionswrong"] = questionswrong;
            TempData["questioncount"] = questioncount;

            return RedirectToAction("RandomTest", "BeginExam");
        }
    }
}
