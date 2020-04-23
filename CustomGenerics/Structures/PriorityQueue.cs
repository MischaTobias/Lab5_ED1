using CustomGenerics.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics
{
    public class PriorityQueue<T> : ICloneable
    {
        public Node<T> Root;
        public int TasksQuantity;

        public PriorityQueue()
        {
            TasksQuantity = 0;
        }
        
        public bool IsEmpty()
        {
            return Root == null ? true : false;
        }

        public bool IsFull()
        {
            return TasksQuantity == 10 ? true : false;
        }

        public void AddTask(string key, DateTime date, int priority)
        {
            var newNode = new Node<T>(key, date, priority);
            if (IsEmpty())
            {
                Root = newNode;
                TasksQuantity = 1;
            }
            else
            {
                TasksQuantity++;
                var NewNodeFather = SearchLastNode(Root, 1);
                if(NewNodeFather.LeftSon != null)
                {
                    NewNodeFather.RightSon = newNode;
                    newNode.Father = NewNodeFather;
                    OrderDowntoUp(newNode);
                }
                else
                {
                    NewNodeFather.LeftSon = newNode;
                    newNode.Father = NewNodeFather;
                    OrderDowntoUp(newNode);
                }
                
            }
        }

        //public void Insert(Node<T> currentNode, Node<T> newNode)
        //{
        //    if (currentNode.LeftSon == null)
        //    {
        //        newNode.Father = currentNode;
        //        currentNode.LeftSon = newNode;
        //        OrderDowntoUp(currentNode.LeftSon);
                
        //    }
        //    else if (currentNode.RightSon == null)
        //    {
        //        newNode.Father = currentNode;
        //        currentNode.RightSon = newNode;
        //        OrderDowntoUp(currentNode.RightSon);
        //    }
        //    else
        //    {
        //        if (Leaves > (flag1 + flag2)/2)
        //        {
        //            Insert(currentNode.RightSon, newNode);
        //            flag1 = (flag1 + flag2) / 2;
        //        }
        //        else
        //        {
        //            Insert(currentNode.LeftSon, newNode);
        //            flag2 = (flag1 + flag2) / 2;
        //        }
        //    }
        //}

        private void OrderDowntoUp(Node<T> current)
        {
            if(current.Father != null)
            {
                if (current.Priority < current.Father.Priority)
                {
                    ChangeNodes(current);
                }
                else if (current.Priority == current.Father.Priority)
                {
                    if (current.DatePriority < current.Father.DatePriority)
                    {
                        ChangeNodes(current);
                    }
                }
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
                        if(current.DatePriority > current.RightSon.DatePriority)
                        {
                            ChangeNodes(current.RightSon);
                            OrderDowntoUp(current.RightSon);
                        }
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
                        if(current.DatePriority > current.LeftSon.DatePriority)
                        {
                            ChangeNodes(current.LeftSon);
                            OrderDowntoUp(current.LeftSon);
                        }
                    }
                }
                else
                {
                   if(current.LeftSon.DatePriority > current.RightSon.DatePriority)
                   {
                        if (current.Priority > current.RightSon.Priority)
                        {
                            ChangeNodes(current.RightSon);
                            OrderDowntoUp(current.RightSon);
                        }
                        else if (current.Priority == current.RightSon.Priority)
                        {
                            if (current.DatePriority > current.RightSon.DatePriority)
                            {
                                ChangeNodes(current.RightSon);
                                OrderDowntoUp(current.RightSon);
                            }
                        }
                   }
                   else
                   {
                        if (current.Priority > current.LeftSon.Priority)
                        {
                            ChangeNodes(current.LeftSon);
                            OrderDowntoUp(current.LeftSon);
                        }
                        else if (current.Priority == current.LeftSon.Priority)
                        {
                            if (current.DatePriority > current.LeftSon.DatePriority)
                            {
                                ChangeNodes(current.LeftSon);
                                OrderDowntoUp(current.LeftSon);
                            }
                        }
                   }
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
                    if (current.DatePriority > current.RightSon.DatePriority)
                    {
                        ChangeNodes(current.RightSon);
                        OrderDowntoUp(current.RightSon);
                    }
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
                    if (current.DatePriority > current.LeftSon.DatePriority)
                    {
                        ChangeNodes(current.LeftSon);
                        OrderDowntoUp(current.LeftSon);
                    }
                }
            }
        }

        private void ChangeNodes(Node<T> node)
        {
            var Priority1 = node.Priority;
            var Key1 = node.Key;
            var Date1 = node.DatePriority;
            node.Priority = node.Father.Priority;
            node.Key = node.Father.Key;
            node.DatePriority = node.Father.DatePriority;
            node.Father.Priority = Priority1;
            node.Father.Key = Key1;
            node.Father.DatePriority = Date1;
            
        }
        
        public  Node<T> Delete()
        {
            Node<T> LastNode = SearchLastNode(Root, 1);
            Node<T> FirstNode = Root;
            Root.Key = LastNode.Key;
            Root.Priority = LastNode.Priority;
            if (LastNode.Father == null)
            {
                Root = null;
                TasksQuantity--;
                return LastNode;
            }
            else
            {
                if (LastNode.Father.LeftSon == LastNode)
                {
                    LastNode.Father.LeftSon = null;
                }
                else
                {
                    LastNode.Father.RightSon = null;
                }
            }
            OrderUptoDown(Root);
            TasksQuantity--;
            return FirstNode;
        }
        private Node<T> SearchLastNode(Node<T> current, int number)
        {
            try
            {
                int previousn = TasksQuantity;
                if (previousn == number)
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
                        if (current.LeftSon != null)
                        {
                            return SearchLastNode(current.LeftSon, previousn);
                        }
                        else
                        {
                            return current;
                        }
                    }
                    else
                    {
                        if (current.RightSon != null)
                        {
                            return SearchLastNode(current.RightSon, previousn);
                        }
                        else
                        {
                            return current;
                        }
                    }
                }
            }
            catch
            {
                return current;
            }
            
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
