﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectExam.Models
{
    public class Grade
    {
        public string UserName { get; set; }
        public double Score { get; set; }
        public Quiz quiz { get; set; }
    }
}