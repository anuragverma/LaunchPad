using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad
{
    class TreesAndGraphs
    {
        #region Implement a function to check if a tree is balanced. 
        /*
         * For the purposes of this question, a balanced tree is defined to be a tree 
         * such that no two leaf nodes differ in distance from the root by more than one.
         */
        public static int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }

        public static int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));
        }

        public static bool IsBalanced(TreeNode root)
        {
            return (MaxDepth(root) - MinDepth(root) <= 1);
        }
        #endregion

        #region Given a directed graph, design an algorithm to find out whether there is a route between two nodes.
        //Not implemented
        #endregion

        #region Given a sorted (increasing order) array, write an algorithm to create a binary tree with minimal height.
        public static TreeNode AddToTree(int[] array, int start, int end)
        {
            if (end < start)
            {
                return null;
            }
            int mid = (start + end) / 2;
            TreeNode n = new TreeNode(array[mid]);
            n.left = AddToTree(array, start, mid - 1);
            n.right = AddToTree(array, mid + 1, end);
            return n;
        }

        public static TreeNode CreateMinimalBST(int[] array)
        {
            return AddToTree(array, 0, array.Length - 1);
        }
        #endregion
    }

    #region Definition of a Tree
    class TreeNode
    {
        public int data;
        public TreeNode left, right;
        public TreeNode(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }
    #endregion

    public enum State
    {
        Unvisited, Visited, Visiting
    }

    //class Graph : IEnumerable<GraphNode>
    //{
    //    public IEnumerator<GraphNode> GetEnumerator()
    //    {
    //        throw new NotImplementedException("need to collect more info");
    //    }
    //}

    class GraphNode
    {
        public int data;
        public GraphNode adjacent;
        public GraphNode(int data)
        {
            this.data = data;
            adjacent = null;
        }
    }
}
