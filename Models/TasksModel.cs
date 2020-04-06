using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_ED1.Models
{
    public class TasksModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Proyect { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
    }
}