using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad
{
    public class Puzzles
    {
        #region Implement an algorithm to determine if a string has all unique characters. What if you can not use additional data structures?
        public static bool IsUniqueChars(String inputString)
        {
            bool[] charset = new bool[256];
            for (int i = 0; i < inputString.Length; i++)
            {
                int char_value = inputString.ElementAt(i);
                if (charset[char_value])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Write code to reverse a String.
        public static string ReverseString(String inputString)
        {
            if (inputString.Length > 0)
            {
                StringBuilder sb = new StringBuilder(inputString.Length);
                for (int i = inputString.Length - 1; i >= 0; i--)
                {
                    sb.Append(inputString.ElementAt(i));
                }
                return sb.ToString();
            }
            else
            {
                return "";
            }
            
        }
        #endregion

        #region Design an algorithm and write code to remove the duplicate characters in a string without using any additional buffer. NOTE: One or two additional variables are fine. An extra copy of the array is not.
        public static void RemoveDuplicateChars(char[] inputString)
        {            
            if (inputString == null)
            {
                return;
            }
            int length = inputString.Length;
            if (length < 2)
            {
                return;
            }
            int tail = 1;
            for (int i = 1; i < inputString.Length; i++)
            {
                int j;
                for ( j = 0; j < tail; j++)
                {
                    if (inputString[i] == inputString[j])
                    {
                        break;
                    }
                }
                if (j == tail)
                {
                    inputString[tail] = inputString[i];
                    tail++;
                }
            }
            for (int k = tail; k < inputString.Length; k++)
            {
                inputString[k] = '\0';
            }
        }
        #endregion

        #region Write a method to decide if two strings are anagrams or not.
        public static bool AnagramCheck(String s, String t)
        {
            if (s.Length != t.Length) return false;
            int[] letters = new int[256];
            int num_unique_chars = 0;
            int num_completed_t = 0;
            char[] s_array = s.ToCharArray();
            foreach(char c in s_array)
            {
                //count number of each char in s
                if (letters[c] == 0)
                {
                    num_unique_chars++;
                }
                letters[c]++;
            }
            for (int i = 0; i < t.Length; i++)
            {
                int c = (int)t.ElementAt(i);
                if (letters[c] == 0)
                {
                    //found more of char c in t than in s
                    return false;
                }
                letters[c]--;
                if (letters[c] == 0)
                {
                    num_completed_t++;
                    if(num_completed_t == num_unique_chars)
                    {
                        //strings are anagrams if t has been processed completely by this point
                        return (i == t.Length - 1);
                    }
                }
            }
            return false;
        }
        #endregion

        #region Write a method to replace all spaces in a string with ‘%20’.
        public static char[] ReplaceSpaceWith(char[] str, int length)
        {
            int spaceCount = 0, newLength, i = 0;
            for (i = 0; i < length; i++)
            {
                if (str[i] == ' ')
                {
                    spaceCount++;
                }
            }
            newLength = length + spaceCount * 2;
            char[] newStr = new char[newLength];
            for (i = length - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    newStr[newLength - 1] = '0';
                    newStr[newLength - 2] = '2';
                    newStr[newLength - 3] = '%';
                    newLength = newLength - 3;
                }
                else 
                {
                    newStr[newLength - 1] = str[i];
                    newLength = newLength - 1;
                }
            }
            return newStr;
        }
        #endregion

        #region Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes, write a method to rotate the image by 90 degrees. Can you do this in place?
        /*
         * The rotation can be performed in layers, 
         * where you perform a cyclic swap on the edges on each layer. 
         * In the first for loop, we rotate the first layer (outermost edges). 
         * We rotate the edges by doing a four-way swap first on the corners, 
         * then on the element clockwise from the edges, then on the element three steps away.
         */
        public static void Rotate2DMatrix(int[,] matrix, int n)
        {
            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    //save top
                    int top = matrix[first,i];
                    //left goes to top
                    matrix[first,i] = matrix[last - offset,first];
                    //bottom goes to left
                    matrix[last - offset,first] = matrix[last,last - offset];
                    //right goes to bottom
                    matrix[last,last - offset] = matrix[i,last];
                    //top goes to right
                    matrix[i,last] = top;
                }
            }
        }
        #endregion

        #region Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column is set to 0.
        /*
         * At first glance, this problem seems easy: 
         * just iterate through the matrix and every time we see a 0, set that row and column to 0. 
         * There’s one problem with that solution though: 
         * we will “recognize” those 0s later on in our iteration and then set their row and column to zero. 
         * Pretty soon, our entire matrix is 0s!
         * One way around this is to keep a second matrix which flags the 0 locations. 
         * We would then do a second pass through the matrix to set the zeros. This would take O(MN) space.
         * Do we really need O(MN) space? No. 
         * Since we’re going to set the entire row and column to zero, 
         * do we really need to track which cell in a row is zero? No. 
         * We only need to know that row 2, for example, has a zero.
         * The code below implement this algorithm. 
         * We keep track in two arrays all the rows with zeros and all the columns with zeros. 
         * We then make a second pass of the matrix and set a cell to zero if its row or column is zero.
         */
        public static void SetZeros(int[,] matrix)
        {
            int[] row = new int[matrix.GetLength(0)];
            int[] column = new int[matrix.GetLength(1)];
            //store the row and column index with value 0
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row[i] = 1;
                        column[j] = 1;
                    }
                }
            }

            //Set matrix[i,j] to 0 if either row i or column j has a 0
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((row[i] == 1) || (column[j] == 1))
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
        }
        #endregion
    }
}
