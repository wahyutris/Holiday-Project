using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectExam.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public double Point { get; set; }
        public int OrderNumber { get; set; }

        private IList<Choice> _choices = new List<Choice>();
        public IList<Choice> Choices
        {
            get { return _choices; }
            set { _choices = value; }
        }
        public void AddChoice(Choice choice)
        {
            _choices.Add(choice);
        }
    }
}