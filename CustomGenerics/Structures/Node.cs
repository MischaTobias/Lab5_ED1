using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Structures
{
    public class Node
    {
        public Node Father;
        public Node RightSon;
        public Node LeftSon;
        public string Task;
        public int Priority;

        public Node(string key)
        {
            Task = key;
        }
    }
}
