using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectExam.Models
{
    public class Globals
    {
        public static double answerscorrect = 0;
        public static double answerswrong = 0;
        public static double delayedanswerscorrect = 0;
        public static double delayedanswerswrong = 0;
        public static int count = 1;
        public static List<Question> GlobalQuestionList = new List<Question>();
        public static List<Exam> GlobalTestList = new List<Exam>();
    }
}