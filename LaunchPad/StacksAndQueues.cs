using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad
{
    class StacksAndQueues
    {
        
    }

    #region Implement a set of stacks
    /*
     * Imagine a (literal) stack of plates. If the stack gets too high, it might topple. 
     * Therefore, in real life, we would likely start a new stack when the previous stack exceeds some threshold. 
     * Implement a data structure SetOfStacks that mimics this. SetOf-Stacks should be composed of several stacks, 
     * and should create a new stack once the previous one exceeds capacity. 
     * SetOfStacks.push() and SetOfStacks.pop() should behave identically to a single stack 
     * (that is, pop() should return the same values as it would if there were just a single stack).
     * FOLLOW UP
     * Implement a function popAt(int index) which performs a pop operation on a specific sub-stack.
     */
    class SetOfStacks
    {
        //ArrayList<Stack> Stacks = new ArrayList<Stack>(); -- ArrayList is a non-generic type & can't be used with type args
        List<Stack1> Stacks = new List<Stack1>();
        public int capacity;

        public SetOfStacks(int capacity)
        {
            this.capacity = capacity;
        }

        public Stack1 GetLastStack()
        {
            if (Stacks.Count == 0)
            {
                return null;
            }
            return Stacks[Stacks.Count - 1];
        }

        public void Push(int value)
        {
            Stack1 last = Stacks[Stacks.Count - 1];
            if (last != null && !last.IsAtCapacity())
            {
                //add to last stack 
                last.Push(value);
            }
            else
            {
                //create new stack
                Stack1 s1 = new Stack1(capacity); //need capacity of the new stack at creation time, so passed it in SetOfStacks ctor
                s1.Push(value);
                //add new stack to list of stacks
                Stacks.Add(s1);
            }
        }

        public int Pop()
        {
            Stack1 last = Stacks[Stacks.Count - 1];
            int value = last.Pop();
            if (last.size == 0) //need to check if stack is empty now -- so need a size attribute in the custom stack class
            {
                //since the last stack is empty .. remove it.
                Stacks.RemoveAt(Stacks.Count - 1);
            }
            return value;
        }
    }

    class Stack1
    {
        private int capacity;
        public Node top, bottom;
        public int size = 0;

        public Stack1(int capacity)
        {
            this.capacity = capacity;
        }

        public bool IsAtCapacity()
        {
            return (capacity == size);
        }

        public bool Push(int value)
        {
            if (size >= capacity)
            {
                return false;
            }
            size++;
            Node n = new Node(value);
            n.next = top;
            top = n;
            return true;
        }

        public int Pop()
        {
            Node temp = top;
            top.next = top;
            size--;
            return temp.data;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }
    }
    #endregion

    #region Design a stack which has a min function that returns minimum element in O(1) time
    /*
     * You can implement this by having each node in the stack keep track of the minimum beneath itself. 
     * Then, to find the min, you just look at what the top element thinks is the min.
     * When you push an element onto the stack, the element is given the current minimum. 
     * It sets its “local min” to be the min.
     */
    class StackWithMin : Stack<NodeWithMin>
    {
        public void Push(int value)
        {
            int newMin = Math.Min(value, Min());
            base.Push(new NodeWithMin(value, newMin));
        }

        public int Min()
        {
            if(this.Count == 0)
            {
                return Int32.MaxValue;
            }
            else
            {
               return Peek().min;
            }
        }
    }

    class NodeWithMin
    {
        public int value;
        public int min;
        public NodeWithMin(int value, int min)
        {
            this.value = value;
            this.min = min;
        }
    }
    #endregion

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
