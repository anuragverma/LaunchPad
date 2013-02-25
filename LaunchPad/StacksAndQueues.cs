using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad
{
    class StacksAndQueues
    {
        #region Describe how you could use a single array to implement three stacks
        #endregion
    }

    class Stack
    {
        Node top;
        public int Pop()
        {
            if (top != null)
            {
                int item = top.data;
                top = top.next;
                return item;
            }
            return -1;
        }

        public void Push(int item)
        {
            Node t = new Node(item);
            t.next = top;
            top = t;
        }
    }

    class Queue
    {
        Node front, back;
        void Enqueue(int item)
        {
            if (front == null)
            {
                back = new Node(item);
                front = back;
            }
            else
            {
                back.next = new Node(item);
                back = back.next;
            }
        }

        int Dequeue()
        {
            if (front != null)
            {
                int item = front.data;
                front = front.next;
                return item;
            }
            return -1;
        }
    }
}
