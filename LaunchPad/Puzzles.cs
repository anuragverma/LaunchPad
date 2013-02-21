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
            //newStr[newLength] = '\0';
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
    }
}
