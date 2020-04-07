using CustomGenerics.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics
{
    public class PriorityQueue
    {
        public Node Root;
        private int TasksQuantity;
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
            var newNode = new Node(key);
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

        public void Insert(Node currentNode, Node newNode)
        {
            if (currentNode.LeftSon == null)
            {
                newNode.Father = currentNode;
                currentNode.LeftSon = newNode;
                Order(currentNode.LeftSon);
            }
            else if (currentNode.RightSon == null)
            {
                newNode.Father = currentNode;
                currentNode.RightSon = newNode;
                Order(currentNode.RightSon);
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

        private void Order(Node current)
        {
            if (current.Priority < current.Father.Priority)
            {
                ChangeNodes(current);
            }
            else if (current.Father != null)
            {
                Order(current.Father);
            }
        }

        private void ChangeNodes(Node node)
        {
            var Priority1 = node.Priority;
            var Task1 = node.Task;
            node.Priority = node.Father.Priority;
            node.Task = node.Father.Task;
            node.Father.Priority = Priority1;
            node.Father.Task = Task1;
        }
    }
}
