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
         */
        #endregion
    }

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
}
