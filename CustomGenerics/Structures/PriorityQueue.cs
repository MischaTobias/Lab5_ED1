using CustomGenerics.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics
{
    public class PriorityQueue<T>
    {
        public Node<T> Root;
        public int TasksQuantity;
        private int Leaves;
        private int HeapHeight;
        private int MaxLeaves;
        private int flag1;
        private int flag2;

        public PriorityQueue()
        {
            TasksQuantity = 0;
            Leaves = 0;
        }
        
        public bool IsEmpty()
        {
            return Root == null ? true : false;
        }

        public bool IsFull()
        {
            return TasksQuantity == 10 ? true : false;
        }

        public void AddTask(string key)
        {
            var newNode = new Node<T>(key);
            if (IsEmpty())
            {
                Root = newNode;
                TasksQuantity = 1;
                HeapHeight = 2;
            }
            else
            {
                flag2 = MaxLeaves;
                flag1 = 1;
                Insert(Root, newNode);
                TasksQuantity++;
                Leaves++;
                if (Leaves == MaxLeaves)
                {
                    Leaves = 0;
                    HeapHeight++;
                    MaxLeaves = Convert.ToInt32(Math.Pow(2, HeapHeight - 1));
                }
            }
        }

        public void Insert(Node<T> currentNode, Node<T> newNode)
        {
            if (currentNode.LeftSon == null)
            {
                newNode.Father = currentNode;
                currentNode.LeftSon = newNode;
                OrderDowntoUp(currentNode.LeftSon);
                
            }
            else if (currentNode.RightSon == null)
            {
                newNode.Father = currentNode;
                currentNode.RightSon = newNode;
                OrderDowntoUp(currentNode.RightSon);
            }
            else
            {
                if (Leaves > (flag1 + flag2)/2)
                {
                    Insert(currentNode.RightSon, newNode);
                    flag1 = (flag1 + flag2) / 2;
                }
                else
                {
                    Insert(currentNode.LeftSon, newNode);
                    flag2 = (flag1 + flag2) / 2;
                }
            }
        }

        private void OrderDowntoUp(Node<T> current)
        {
            if (current.Priority < current.Father.Priority)
            {
                ChangeNodes(current);
            }
            else if (current.Father != null)
            {
                OrderDowntoUp(current.Father);
            }
        }
        
        private void OrderUptoDown(Node<T> current)
        {
            if(current.RightSon != null && current.LeftSon != null)
            {
                if (current.LeftSon.Priority > current.RightSon.Priority)
                {
                    if (current.Priority > current.RightSon.Priority)
                    {
                        ChangeNodes(current.RightSon);
                        OrderDowntoUp(current.RightSon);
                    }
                    else if (current.Priority == current.RightSon.Priority)
                    {
                        //Realizar la evaluación dependiendo de la fecha
                    }
                }
                else if (current.LeftSon.Priority < current.RightSon.Priority)
                {
                    if (current.Priority > current.LeftSon.Priority)
                    {
                        ChangeNodes(current.LeftSon);
                        OrderDowntoUp(current.LeftSon);
                    }
                    else if (current.Priority == current.LeftSon.Priority)
                    {
                        //Realizar la evaluación dependiendo de la fecha
                    }
                }
                else
                {
                    //Realizar la evaluación dependiendo de la fecha
                }
            }
            else if(current.RightSon != null)
            {
                if (current.Priority > current.RightSon.Priority)
                {
                    ChangeNodes(current.RightSon);
                    OrderDowntoUp(current.RightSon);
                }
                else if (current.Priority == current.RightSon.Priority)
                {
                    //Realizar la evaluación dependiendo de la fecha
                }
            }
            else if(current.LeftSon != null)
            {
                if (current.Priority > current.LeftSon.Priority)
                {
                    ChangeNodes(current.LeftSon);
                    OrderDowntoUp(current.LeftSon);
                }
                else if (current.Priority == current.LeftSon.Priority)
                {
                    //Realizar la evaluación dependiendo de la fecha
                }
            }
        }

        private void ChangeNodes(Node<T> node)
        {
            var Priority1 = node.Priority;
            var Key1 = node.Key;
            node.Priority = node.Father.Priority;
            node.Key = node.Father.Key;
            node.Father.Priority = Priority1;
            node.Father.Key = Key1;
        }
        
        private Node<T> Delete(Node<T> current, int number)
        {
            Node<T> LastNode = SearchLastNode(Root, 1);
            Node<T> FirstNode = Root;
            Root.Key = LastNode.Key;
            Root.Priority = LastNode.Priority;
            if(LastNode.Father.LeftSon == LastNode)
            {
                LastNode.Father.LeftSon = null;
            }
            else
            {
                LastNode.Father.RightSon = null;
            }
            OrderUptoDown(Root);
            TasksQuantity--;
            return FirstNode;
        }
        private Node<T> SearchLastNode(Node<T> current, int number)
        {
            int previousn = TasksQuantity;
            if(previousn == number)
            {
                return current;
            }
            else
            {
                while (previousn / 2 != number)
                {
                    previousn = previousn / 2;
                }
                if (previousn % 2 == 0)
                {
                    return SearchLastNode(current.LeftSon, previousn);
                }
                else
                {
                    return SearchLastNode(current.RightSon, previousn);
                }
            }
        }
    }
}
