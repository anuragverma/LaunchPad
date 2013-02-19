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
        /*
         * Procedure for bubble sort.
         * Takes an array to be sorted as argument.
         * Sorts in place.
         * */
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

        #region Selection Sort
        /*
         * The algorithm divides the input list into two parts: 
         * the sublist of items already sorted, which is built up from left to right
         * at the front (left) of the list, and the sublist of items remaining to be sorted
         * that occupy the rest of the list. 
         * Initially, the sorted sublist is empty and the unsorted sublist is the entire input list. 
         * The algorithm proceeds by finding the smallest
         * element in the unsorted sublist, exchanging it with the leftmost unsorted element
         * (putting it in sorted order), and moving the sublist boundaries one element to the right.
         */
        public static void SelectionSort(double[] inputArray)
        {
            int min;
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[j] < inputArray[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    double temp = inputArray[min];
                    inputArray[min] = inputArray[i];
                    inputArray[i] = temp;
                }
            }
        }
        #endregion

        #region Insertion Sort
        /*
         * Procedure for insertion sort
         * Takes an inputarray to be sorted as argument.
         * Sorts in place.
         */
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

        #region Shell Sort

        #endregion

        #region Merge Sort
        /*
         * Merges two already sorted arrays into a single sorted array.
         * Subarrays([startIndex .. midIndex] and [midIndex+1 .. endIndex]) of inputArray are already sorted.
         * Takes four arguments viz. inputArray, startIndex, midIndex, endIndex
         */
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

        /*
         * Recursively sorts a given inputArray by calling itself on subArrays and then
         * merging the subarrays
         */
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

        #region Quick Sort
        /*
         * Designates an index as pivot.
         * Finds its correct position by putting all elements less than pivot
         * on the left of pivot and all elements greater than pivot
         * to the right of pivot.
         */
        private static int Partition(double[] inputArray, int start, int end)
        {
            double pivot = inputArray[end];
            int i = start - 1;
            for (int j = start; j < end; j++)
            {
                if (inputArray[j] <= pivot)
                {
                    i++;
                    double temp = inputArray[i];
                    inputArray[i] = inputArray[j];
                    inputArray[j] = temp;
                }
            }
            double temp1 = inputArray[i + 1];
            inputArray[i + 1] = inputArray[end];
            inputArray[end] = temp1;
            return i + 1;
        }

        /*
         * Sorts an input array recursively by finding correct position for a pivot element
         * and applying QuickSort on left and right subarrays.
         */
        public static void QuickSort(double[] inputArray, int start, int end)
        {
            if (start < end)
            {
                int pivotIndex = Partition(inputArray, start, end);
                QuickSort(inputArray, start, pivotIndex - 1);
                QuickSort(inputArray, pivotIndex + 1, end);
            }
        }
        #endregion

        #region Counting Sort
        /*
         * This procedure assumes that each element of the input array lies in the range [0 .. range]
         * where range is an integer
         */
        public static int[] CountingSort(int[] inputArray, int range)
        {
            int[] tempStorage = new int[range+1];
            int[] outputArray = new int[inputArray.Length];

            for (int j = 0; j < inputArray.Length; j++)
            {
                tempStorage[inputArray[j]] = tempStorage[inputArray[j]] + 1;
            }
            //tempStorage[x] now contains the number of elements equal to x.
            
            for (int i = 1; i <= range; i++)
            {
                tempStorage[i] = tempStorage[i] + tempStorage[i - 1];
            }
            //tempStorage[x] now contains the number of elements less than or equal to x.
            
            for (int j = inputArray.Length - 1; j >= 0; j-- )
            {
                outputArray[tempStorage[inputArray[j]] - 1] = inputArray[j];
                tempStorage[inputArray[j]] = tempStorage[inputArray[j]] - 1;
            }
            return outputArray;
        }
        #endregion

        #region Helper Functions

        #endregion
    }
}
