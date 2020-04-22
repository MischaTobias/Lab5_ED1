using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Structures
{
    public class Node<T>
    {
        public Node<T> Father;
        public Node<T> RightSon;
        public Node<T> LeftSon;
        public string Key;
        public int Priority;

        public Node(string key)
        {
            Key = key;
        }
    }
}
