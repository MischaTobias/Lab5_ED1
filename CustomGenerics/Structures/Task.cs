using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Structures
{
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Proyect { get; set; }
        public DateTime Date { get; set;}
        public int Priority { get; set; }
        public Task Before { get; set; }
        public Task Next { get; set; }
        
    }
}
