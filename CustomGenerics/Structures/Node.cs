﻿using System;
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

        public int GetTreeHeight()
        {
            if (this.LeftSon == null && this.RightSon == null)
            {
                return 1;
            }
            else if (this.LeftSon == null || this.RightSon == null)
            {
                if (this.LeftSon == null)
                {
                    return this.RightSon.GetTreeHeight() + 1;
                }
                else
                {
                    return this.LeftSon.GetTreeHeight() + 1;
                }
            }
            else
            {
                if (this.LeftSon.GetTreeHeight() > this.RightSon.GetTreeHeight())
                {
                    return this.LeftSon.GetTreeHeight() + 1;
                }
                else
                {
                    return this.RightSon.GetTreeHeight() + 1;
                }
            }
        }
    }
}