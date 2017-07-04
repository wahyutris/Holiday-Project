using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ProjectExam.Models
{
    public class LeaderBoards
    {
        //[Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public int? ExamID { get; set; }
        public int Score { get; set; }
        public DateTime Time { get; set; }
    }

    public class LeaderBoardsDbContext : DbContext
    {
        public DbSet<LeaderBoards> LeaderBoardsDatabase { get; set; }
    }
}