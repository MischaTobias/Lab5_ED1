using CustomGenerics.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Structures
{
    public class Hash<T> where T : IComparable
    {
        HashNode<T>[] TablaHash = new HashNode<T>[50];

        public void Insert(T InsertV, string key)
        {
            HashNode<T> T1 = new HashNode<T>();
            T1.Value = InsertV;

            T1.Key = key;
            int code = GetCode(T1.Key);
            if(TablaHash[code] != null)
            {
                HashNode<T> Aux = TablaHash[code];
                while(Aux.Next != null)
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

        public HashNode<T> Search(string searchedKey)
        {
            int code = GetCode(searchedKey);

            if (TablaHash[code] != null)
            {

                if (TablaHash[code].Key != searchedKey)
                {
                    HashNode<T> Aux = TablaHash[code];
                    while (Aux.Key != searchedKey && Aux.Next != null)
                    {
                        Aux = Aux.Next;
                    }
                    if (Aux.Key == searchedKey)
                    {
                        return Aux;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return TablaHash[code];
                }
            }
            else
            {
                return null;
            }
        }


        public void Remove(string searchedKey)
        {
            HashNode<T> TaskTR = Search(searchedKey);

            if (TaskTR.Next != null)
            {
                TaskTR.Next.Previous = TaskTR.Previous;
            }
            if (TaskTR.Previous != null)
            {
                TaskTR.Previous.Next = TaskTR.Next;
            }
        }

        private int GetCode(string Key)
        {
            return Key.Length * 11 % 50;
        }
    }
}
