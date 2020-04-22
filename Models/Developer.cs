using CustomGenerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_ED1.Models
{
    public class Developer 
    {
        public string User { get; set; }
        public PriorityQueue<string> Tasks { get; set; }
        public TasksModel CurrentTask { get; set; }
    }
}