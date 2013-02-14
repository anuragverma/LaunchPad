using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad
{
    public class Sort
    {
        #region BubbleSort
            public static void BubbleSort(double[] inputArray)
            {
                for (int i = 0; i < inputArray.Length - 2; i++)
                {
                    for (int j = inputArray.Length - 1; j > i; j--)
                    {
                        if (inputArray[j] < inputArray[j - 1])
                        {
                            double temp = inputArray[j];
                            inputArray[j] = inputArray[j - 1];
                            inputArray[j - 1] = temp;
                        }
                    }
                }
            }
        #endregion

        #region Insertion Sort
            public static void InsertionSort(double[] inputArray)
            {
                double key;
                for (int j = 1; j <= inputArray.Length - 1; j++)
                {
                    key = inputArray[j];
                    // insert inputArray[j] into the sorted sequence inputArray[0 .. j-1].
                    int i = j - 1;
                    while (i >= 0 && inputArray[i] > key)
                    {
                        inputArray[i + 1] = inputArray[i];
                        i--;
                    }
                    inputArray[i + 1] = key;
                }
            }
        #endregion

        #region Merge Sort
            private static void Merge(double[] inputArray, int startIndex, int midIndex, int endIndex)
            {
                int n1 = midIndex - startIndex + 1;
                int n2 = endIndex - midIndex;
                double[] tempArray1 = new double[n1 + 1];
                double[] tempArray2 = new double[n2 + 1];
                int i, j;
                for (i = 0; i < n1; i++)
                {
                    tempArray1[i] = inputArray[startIndex + i];
                }

                for (j = 0; j < n2; j++)
                {
                    tempArray2[j] = inputArray[midIndex + j + 1];
                }

                tempArray1[n1] = Double.MaxValue;
                tempArray2[n2] = Double.MaxValue;
                i = 0;
                j = 0;

                for (int k = startIndex; k <= endIndex; k++)
                {
                    if (tempArray1[i] <= tempArray2[j])
                    {
                        inputArray[k] = tempArray1[i];
                        i++;
                    }
                    else
                    {
                        inputArray[k] = tempArray2[j];
                        j++;
                    }
                }
            }

            public static void MergeSort(double[] inputArray, int startIndex, int endIndex)
            {
                if (startIndex < endIndex)
                {
                    int midIndex = (startIndex + endIndex) / 2;
                    MergeSort(inputArray, startIndex, midIndex);
                    MergeSort(inputArray, midIndex + 1, endIndex);
                    Merge(inputArray, startIndex, midIndex, endIndex);
                }
            }
        #endregion
            

        public void HeapSort()
        {

        }

        public void QuickSort()
        {

        }

        public void CountingSort()
        {

        }
    }
}
