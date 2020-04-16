﻿using CustomGenerics.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Structures
{
    public class Hash<T> where T : IComparable
    {
        HashNode<T>[] TablaHash = new HashNode<T>[12];

        public void Insert(T InsertV)
        {
            HashNode<T> T1 = new HashNode<T>();
            T1.value = InsertV;
            int code = T1.GetHashCode()%12;
            if(TablaHash[code] != null)
            {
                HashNode<T> Aux = TablaHash[12];
                while(TablaHash[code].Next != null)
                {
                    Aux = Aux.Next;
                }
                Aux.Next = T1;
                T1.Previous = Aux;
            }
            else
            {
                TablaHash[code] = T1;
            }
        }
        public HashNode<T> Search(T Searchedname)
        {
            var SearchedNode = new HashNode<T> { value = Searchedname };
            int code = SearchedNode.GetHashCode() % 12;
            if (TablaHash[code].value.CompareTo(Searchedname) != 0)
            {
                HashNode<T> Aux = TablaHash[code];
                while (Aux.value.CompareTo(Searchedname) != 0 && Aux.Next != null)
                {
                    Aux = Aux.Next;
                }
                if (Aux.Next == null)
                {
                    return null;
                }
                else
                {
                    return Aux;
                }
            }
            else
            {
                return TablaHash[code];
            }
        }
        public void Remove(string searchedName)
        {
            HashNode<T> TaskTR = Search(searchedName);
            if (TaskTR.Next != null)
            {
                TaskTR.Next.Previous = TaskTR.Previous;
            }
            if (TaskTR.Previous != null)
            {
                TaskTR.Previous.Next = TaskTR.Next;
            }
        }
    }
}
