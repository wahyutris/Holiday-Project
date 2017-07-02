using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectExam.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private IList<Question> _questions = new List<Question>();
        public IList<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }

        public void AddQuestion(IList<Question> questions)
        {
            foreach (var question in questions)
            {
                AddQuestion(question);
            }
        }

        public void AddQuestion(Question question)
        {
            _questions.Add(question);
        }       
    }
}