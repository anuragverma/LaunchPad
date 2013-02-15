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

        #region Heap Sort
        //Maintaining the heap property
        //MaxHeapify procedure maintains the max heap property.
        //Its inputs are an Array and an index into the array.
        //When it is called, MaxHeapify assumes that the binary trees rooted at Left(index)
        //and Right(index) are max heaps but that inputArray[index] might be smaller than
        //its children, thus violating the max-heap property.
        //MaxHeapify lets the value inputArray[index] float down in the max heap so that the subtree
        //rooted at index obeys the max heap property
        private static void MaxHeapify(double[] inputArray, int heapSize, int index)
        {
            int largest;
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            if (left < heapSize && inputArray[left] > inputArray[index])
            {
                largest = left;
            }
            else
            {
                largest = index;
            }
            if (right < heapSize && inputArray[right] > inputArray[largest])
            {
                largest = right;
            }
            if (largest != index)
            {
                double temp = inputArray[index];
                inputArray[index] = inputArray[largest];
                inputArray[largest] = temp;

                //test whether this works, else use above code that is commented
                //Swap(inputArray[index], inputArray[largest]);
                MaxHeapify(inputArray, heapSize, largest);
            }
        }

        //Use MaxHeapify in a bottom-up manner to convert an array A[1..n], where n = array length, into a maxheap.
        //The elements in the sub-array A[(lower(n/2) + 1) .. n] are all leaves of the tree, so each is a 1-element
        //heap to begin with. The procedure BuildmaxHeap goes through remaining nodes of the tree and runs
        //MaxHeapify on each one.
        private static void BuildMaxHeap(double[] inputArray, int heapSize)
        {
            //need to check the correctness of the below for loop
            for (int i = ((inputArray.Length - 1) / 2); i >= 0; i--)
            {
                MaxHeapify(inputArray, heapSize, i);
            }
        }
            
        public static void HeapSort(double[] inputArray)
        {
            int heapSize = inputArray.Length;
            BuildMaxHeap(inputArray, heapSize);
            for (int i = inputArray.Length - 1; i > 0; i-- )
            {
                double temp = inputArray[0];
                inputArray[0] = inputArray[heapSize - 1];
                inputArray[heapSize - 1] = temp;
                heapSize--;
                MaxHeapify(inputArray, heapSize, 0);
            }
        }
        #endregion

        public void QuickSort()
        {

        }

        public void CountingSort()
        {

        }

        #region Helper Functions
        
        #endregion
    }
}
