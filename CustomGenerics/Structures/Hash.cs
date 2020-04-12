using CustomGenerics.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Structures
{
    public class Hash
    {
        Task[] TablaHash = new Task[12];

        public void Insert(Task T1)
        {
           int code = T1.Name.GetHashCode()%12;
            if(TablaHash[code] != null)
            {
                Task Aux = TablaHash[12];
                while(TablaHash[code].Next != null)
                {
                    Aux = Aux.Next;
                }
                Aux.Next = T1;
                T1.Before = Aux;
            }
            else
            {
                TablaHash[code] = T1;
            }
        }
        public Task Search(string Searchedname)
        {
            int code = Searchedname.GetHashCode() % 12;
            if(TablaHash[code].Name != Searchedname)
            {
                Task Aux = TablaHash[code];
                while(Aux.Name != Searchedname || Aux.Next !=null)
                {
                    Aux = Aux.Next;
                }
                if(Aux.Next == null)
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
            Task TaskTR = Search(searchedName);
            if (TaskTR.Next != null)
            {
                TaskTR.Next.Before = TaskTR.Before;
            }
            if(TaskTR.Before != null)
            {
                TaskTR.Before.Next = TaskTR.Next;
            }
       }   
    }
}
