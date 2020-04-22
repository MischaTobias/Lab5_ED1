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
        HashNode<T>[] TablaHash = new HashNode<T>[12];

        public void Insert(T InsertV, string key)
        {
            HashNode<T> T1 = new HashNode<T>();
            T1.value = InsertV;

            T1.Key = key;
            int code = T1.Key.GetHashCode()%12;
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
            int code = searchedKey.GetHashCode() % 12;
            if (TablaHash[code].Key != searchedKey)
            {
                HashNode<T> Aux = TablaHash[code];
                while (Aux.Key != searchedKey && Aux.Next != null)
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
    }
}
