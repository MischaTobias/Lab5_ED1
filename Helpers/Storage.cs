using CustomGenerics.Structures;
using Lab5_ED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_ED1.Helpers
{
    public class Storage
    {
        public static Storage _instance = null;
        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }

        public Hash<TasksModel> Hash = new Hash<TasksModel>();
        public List<Developer> Developers = new List<Developer>();
        public string CurrentUser;
    }
}