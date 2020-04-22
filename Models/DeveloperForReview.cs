using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_ED1.Models
{
    public class DeveloperForReview
    {
        public string User { get; set; }
        public List<TasksModel> Tasks { get; set; }
    }
}