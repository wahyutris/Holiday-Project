using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectExam.Models;

namespace ProjectExam.Data
{
    public class QuestionRepository
    {
        public Question getQuestion()
        {
            return null;
        }

        private IList<Question> _questions()
        {
            var questions = new List<Question>()
            {
                new Question() { Text = "What is 2+2", Point = 10, Id = 1, OrderNumber = 0},
                new Question() { Text = "What is 5+2", Point = 10, Id = 2, OrderNumber = 1},
                new Question() { Text = "What is 10+2", Point = 5, Id = 3, OrderNumber = 2}
            };

            questions[0].AddChoice(new Choice() { IsAnswer = false, Text = "2"});
            questions[0].AddChoice(new Choice() { IsAnswer = true, Text = "4"});

            questions[1].AddChoice(new Choice() { IsAnswer = false, Text = "12"});
            questions[1].AddChoice(new Choice() { IsAnswer = true, Text = "7"});

            questions[2].AddChoice(new Choice() { IsAnswer = true, Text = "12"});
            questions[2].AddChoice(new Choice() { IsAnswer = false, Text = "15"});

            return questions;
        }

        public Question getQuestion(int id)
        {
            Question questionSelected = new Question();

            foreach(var question in _questions())
            {
                if(question.Id == id)
                {
                    questionSelected = question;
                }
            }
            return questionSelected;
        }

        public int totalQuestion()
        {
            return _questions().Count;
        }

        public Grade Grade(IList<Question> questions)
        {
            foreach(var question in questions)
            {

            }
            return null;
        }
    }
}