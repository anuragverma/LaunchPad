using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad
{
    class StacksAndQueues
    {
        
    }

    #region Describe how you could use a single array to implement three stacks
    class ThreeStacksFromOneArray
    {
        /*
         * Divide the array in three equal parts and allow the individual stack to grow in that limited space
         * (note: “[“ means inclusive, while “(“ means exclusive of the end point).
         * for stack 1, we will use [0, n/3)
         * for stack 2, we will use [n/3, 2n/3)
         * for stack 3, we will use [2n/3, n)
         * This solution is based on the assumption that we do not have any extra information 
         * about the usage of space by individual stacks and that we can’t either modify or use any extra space. 
         * With these constraints, we are left with no other choice but to divide equally.
         */
        static int stackSize = 300;
        int[] buffer = new int[stackSize * 3];
        int[] stackPointer = { 0, 0, 0}; //stack pointers to track top elements

        //stackNum is the stack in which value needs to be inserted
        void Push(int stackNum, int value)
        {
            //find index at which the insertion should be made
            int index = stackNum * stackSize + stackPointer[stackNum] + 1;
            stackPointer[stackNum]++;
            buffer[index] = value;
        }

        int Pop(int stackNum)
        {
            int index = stackNum * stackSize + stackPointer[stackNum];
            stackPointer[stackNum]--;
            int value = buffer[index];
            //set the value of the popped index as 0
            buffer[index] = 0;
            return value;
        }

        int Peek(int stackNum)
        {
            int index = stackNum * stackSize + stackPointer[stackNum];
            return buffer[index];
        }

        bool IsEmpty(int stackNum)
        {
            return (stackPointer[stackNum] == 0);
        }
    }

    class ThreeStacksFromOneArray1
    {
        static int stackSize = 300;
        int indexUsed = 0;
        int[] stackPointer = { -1, -1, -1};
        StackNode[] buffer = new StackNode[stackSize * 3];

        void Push(int stackNum, int value)
        {
            int lastIndex = stackPointer[stackNum]; 
            stackPointer[stackNum] = indexUsed;
            indexUsed++;
            buffer[stackPointer[stackNum]] = new StackNode(lastIndex, value);
        }

        int Pop(int stackNum)
        {
            int value = buffer[stackPointer[stackNum]].value;
            int lastIndex = stackPointer[stackNum];
            stackPointer[stackNum] = buffer[stackPointer[stackNum]].previous;
            buffer[lastIndex] = null;
            indexUsed--;
            return value;
        }

        int Peek(int stackNum)
        {
            return buffer[stackPointer[stackNum]].value;
        }

        bool IsEmpty(int stackNum)
        {
            return stackPointer[stackNum] == -1;
        }

        class StackNode
        {
            public int previous;
            public int value;
            public StackNode(int p, int v)
            {
                value = v;
                previous = p;
            }
        }
    }
    #endregion

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
