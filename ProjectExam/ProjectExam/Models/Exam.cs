﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjectExam.Models
{
    public class Exam
    {
        //link to question database will be via ID. using scheme "test ID" + "question ID" equals question id.
        //and the going up linearly on the question side.
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //new
        public string Status { get; set; } //private or public
        public string Genre { get; set; } //test genre
        public string DateModified { get; set; } //sort by date
        //public int GroupingId { get; set; } // to identify who the test belongs to
        public int TimesTaken { get; set; } // sort by popularity

        //second round
        public string Owner { get; set; } //User ID to more easily identify an owner
    }

    public class ExamDbContext : DbContext
    {
        public DbSet<Exam> ExamDataBase { get; set; }
    }
}