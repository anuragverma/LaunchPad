using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad
{
    class LinkedList
    {
        #region delete node from a singly linked list
        //return head of the new list
        Node deleteNode(Node head, int d)
        {
            Node n = head;
            if (n.data == d)
            {
                return head.next; //head moved by one position
            }
            while (n.next != null)
            {
                if (n.next.data == d)
                {
                    n.next = n.next.next;
                    return head;//head remains unchanged
                }
                n = n.next;
            }
            return head;
        }
        #endregion

        #region Write code to remove duplicates from an unsorted linked list. How would you solve this problem if a temporary buffer is not allowed?
        //use hashtable as a buffer to keep track of unique elements
        public static void DeleteDuplicates(Node n)
        {
            HashSet<int> uniqueElements = new HashSet<int>();
            Node previous = null;
            while (n != null)
            {
                if (uniqueElements.Contains(n.data))
                {
                    //previous node of n should point to next node of n
                    previous.next = n.next;
                }
                else
                {
                    //add unique key in hashtable
                    uniqueElements.Add(n.data);
                    previous = n;
                }
                n = n.next;
            }
        }

        //Without use of a buffer
        public static void DeleteDuplicates2(Node head)
        {
            if (head == null)
            { 
                return; 
            }
            Node previous = head;
            Node current = previous.next;
            while(current != null)
            {
                Node runner = head;
                while (runner != current)
                {
                    //runner will only see one duplicate
                    if(runner.data == current.data)
                    {
                        //remove current
                        Node tmp = current.next;
                        previous.next = tmp;
                        current = tmp;
                        break;
                    }
                    runner = runner.next;
                }
                if (runner == current)
                {
                    //no duplicate found
                    //current not updated -- update now
                    previous = current;
                    current = current.next;
                }
            }
        }
        #endregion

        #region Implement an algorithm to find the nth to last element of a singly linked list.
        public static Node FindNthLast(Node head, int n)
        {
            if (head == null || n < 1)
            {
                return null;
            }
            Node runner1 = head;
            Node runner2 = head;
            for (int j = 0; j < n - 1; j++)
            {
                if (runner1 == null)
                {
                    return null; // element not found since size of list is less than n
                }
                runner1 = runner1.next;
            }
            while(runner1.next != null)
            {
                runner2 = runner2.next;
            }
            return runner2;
        }
        #endregion

        #region Implement an algorithm to delete a node in the middle of a single linked list, given only access to that node.
        /*
         * The solution to this is to simply copy the data from the next node into this node
         * and then delete the next node.
         * NOTE: This problem can not be solved if the node to be deleted is the last node in the linked list.
         */
        public static bool DeleteNode(Node n)
        {
            if (n == null || n.next == null)
            {
                return false; // failure
            }
            Node next = n.next;
            n.data = next.data;
            n.next = next.next;
            return true;
        }
        #endregion

        #region Write a function that adds the two numbers(represented by linked lists) and returns the sum as a linked list.
        /*
         * You have two numbers represented by a linked list, where each node contains a single digit. 
         * The digits are stored in reverse order, such that the 1’s digit is at the head of the list. 
         * Write a function that adds the two numbers and returns the sum as a linked list.
         * EXAMPLE
         * Input: (3 -> 1 -> 5) + (5 -> 9 -> 2)
         * Output: 8 -> 0 -> 8
         */
        public static Node AddLists(Node n1, Node n2, int carry)
        {
            if (n1 == null && n2 == null)
            {
                return null;
            }
            Node result = new Node(carry);
            int value = carry;
            if (n1 != null)
            { 
                value += n1.data;
            }
            if (n2 != null)
            {
                value += n2.data;
            }
            result.data = value % 10;
            Node more = AddLists(n1 == null? null : n1.next, n2 == null? null : n2.next, value > 10? 1 : 0);
            result.next = more;
            return result;
        }
        #endregion

        #region Given a circular linked list, implement an algorithm which returns node at the beginning of the loop.
        /*
         * DEFINITION
         * Circular linked list: A (corrupt) linked list in which a node’s next pointer 
         * points to an earlier node, so as to make a loop in the linked list.
         * EXAMPLE
         * Input: A -> B -> C -> D -> E -> C [the same C as earlier]
         * Output: C
         * 
         * SOLUTION
         * If we move two pointers, one with speed 1 and another with speed 2, 
         * they will end up meeting if the linked list has a loop. Why? 
         * Think about two cars driving on a track—the faster car will always pass the slower one!
         * The tricky part here is finding the start of the loop. Imagine, as an analogy, 
         * two people racing around a track, one running twice as fast as the other. 
         * If they start off at the same place, when will they next meet? 
         * They will next meet at the start of the next lap.
         * Now, let’s suppose Fast Runner had a head start of k meters on an n step lap. 
         * When will they next meet? They will meet k meters before the start of the next lap. 
         * (Why? Fast Runner would have made k + 2(n - k) steps, including its head start, 
         * and Slow Runner would have made n - k steps. Both will be k steps before the start of the loop.)
         * Now, going back to the problem, when Fast Runner (n2) and Slow Runner (n1) 
         * are moving around our circular linked list, n2 will have a head start on the loop when n1 enters. 
         * Specifically, it will have a head start of k, where k is the number of nodes before the loop. 
         * Since n2 has a head start of k nodes, n1 and n2 will meet k nodes before the start of the loop.
         * So, we now know the following:
         * 1. Head is k nodes from LoopStart (by definition).
         * 2. MeetingPoint for n1 and n2 is k nodes from LoopStart (as shown above).
         * Thus, if we move n1 back to Head and keep n2 at MeetingPoint, 
         * and move them both at the same pace, they will meet at LoopStart.
         */
        public static Node FindBeginningOfLoop(Node head)
        {
            Node n1 = head;
            Node n2 = head;

            //find meeting point
            while (n2.next != null)
            {
                n1 = n1.next;
                n2 = n2.next.next;
                if (n1 == n2)
                {
                    break;
                }
            }
            
            //if no meeting point found -- no loop exists
            if (n2.next == null)
            {
                return null;
            }

            //move n1 to head, keep n2 at earlier found meeting point .. move them at same pace
            //they will meet at loop start
            n1 = head;
            while (n1 != n2)
            {
                n1 = n1.next;
                n2 = n2.next;
            }
            //on loop exit, n2 and n1 point to start of the loop
            return n2;
        }
        #endregion
    }

    #region Definition of a node of a linked list
    class Node
    {
        public Node next = null;
        public int data;
        public Node(int d)
        {
            data = d;
        }
        void AppendToTail(int d)
        {
            Node end = new Node(d);
            Node n = this;
            while (n.next != null)
            {
                n = n.next;
            }
            n.next = end;
        }
    }
    #endregion
}
