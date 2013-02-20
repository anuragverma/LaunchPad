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
    }
}
