﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Structures
{
    public class HashNode<T>
    {
        public HashNode<T> Previous { get; set; }
        public HashNode<T> Next { get; set; }
        public T value { get; set; }
    }
}