using ProjectExam.Data;
using ProjectExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectExam.Controllers
{
    public class QuizController : Controller
    {
        private QuizRepository _quizRepo;

        public QuizController()
        {
            _quizRepo = new QuizRepository();
        }

        public ActionResult Publish()
        {
            var quiz = _quizRepo.GetQuiz();
            return View(quiz);
        }

        public ActionResult Grade(Quiz quiz)
        {
            var grade = _quizRepo.Grade(quiz);
            return View(grade);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AnotherPublish()
        {
            var exam = _quizRepo.GetQuiz();
            return View(exam);
        }

        public ActionResult PublishQuiz()
        {
            var question = _quizRepo.GetQuiz().Questions[0];
            return View(question);
        }

        public ActionResult GradeQuiz(Question question)
        {
            question = _quizRepo.GetQuiz().Questions[0];
            return View(question);
        }

        public ActionResult GradeAnother(Quiz quiz)
        {
            return View();
        }
    }
}