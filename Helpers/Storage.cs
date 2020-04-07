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
    }
}