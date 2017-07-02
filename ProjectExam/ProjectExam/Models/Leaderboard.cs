using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectExam.Models
{
    public class Leaderboard
    {
        public string UserName { get; set; }

        private IList<Question> _questions = new List<Question>();
        public double TotalScore
        {
            get
            {
                return (from q in _questions select q.Point).Sum();
            }
        }
    }
}