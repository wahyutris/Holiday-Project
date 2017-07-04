using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjectExam.Models
{
    public class Question
    {
        public int ID { get; set; }
        public int GroupingId { get; set; }
        public string QuestionDescription { get; set; }
        public string MultipleChoiceCorrect { get; set; }
        public string MultipleChoiceB { get; set; }
        public string MultipleChoiceC { get; set; }
        public string MultipleChoiceD { get; set; }
        public string Answerexplanation { get; set; }
    }

    public class QuestionDbContext : DbContext
    {
        public DbSet<Question> QuestionDataBase { get; set; }
    }
}