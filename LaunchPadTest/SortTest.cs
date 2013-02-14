using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LaunchPadTest
{
    [TestClass]
    public class UnitTest1
    {
        #region Tests for Insertion Sort
            [TestMethod]
            public void InsertionSortTest1()
            {
                double[] array = { 54, 543, -54, 0 };
                LaunchPad.Sort.InsertionSort(array);
                bool flag = Enumerable.SequenceEqual(array, new double[] { -54, 0, 54, 543 });
                Assert.AreEqual(flag, true);
            }

            [TestMethod]
            // empty array as input
            public void InsertionSortTest2()
            {
                double[] array = { };
                LaunchPad.Sort.InsertionSort(array);
                bool flag = Enumerable.SequenceEqual(array, new double[] { });
                Assert.AreEqual(flag, true);
            }

            [TestMethod]
            // array having all -ve elements
            public void InsertionSortTest3()
            {
                double[] array = { -45, -565, -545454, -5 };
                LaunchPad.Sort.InsertionSort(array);
                bool flag = Enumerable.SequenceEqual(array, new double[] { -545454, -565, -45, -5 });
                Assert.AreEqual(flag, true);
            }

            [TestMethod]
            // array having all elements equal
            public void InsertionSortTest4()
            {
                double[] array = { 45, 45, 45, 45 };
                LaunchPad.Sort.InsertionSort(array);
                bool flag = Enumerable.SequenceEqual(array, new double[] { 45, 45, 45, 45 });
                Assert.AreEqual(flag, true);
            }
        #endregion

        #region Tests for Merge Sort
            [TestMethod]
            public void MergeSortTest1()
            {
                double[] array = { 54, 543, -54, 0 };
                LaunchPad.Sort.MergeSort(array, 0, 3);
                bool flag = Enumerable.SequenceEqual(array, new double[] { -54, 0, 54, 543 });
                Assert.AreEqual(flag, true);
            }

            [TestMethod]
            public void MergeSortTest2()
            {
                double[] array = { };
                LaunchPad.Sort.MergeSort(array, 0, 0);
                bool flag = Enumerable.SequenceEqual(array, new double[] { });
                Assert.AreEqual(flag, true);
            }

            [TestMethod]
            // array having all -ve elements
            public void MergeSortTest3()
            {
                double[] array = { -45, -565, -545454, -5 };
                LaunchPad.Sort.MergeSort(array, 0, 3);
                bool flag = Enumerable.SequenceEqual(array, new double[] { -545454, -565, -45, -5 });
                Assert.AreEqual(flag, true);
            }

            [TestMethod]
            // array having all elements same
            public void MergeSortTest4()
            {
                double[] array = { 45, 45, 45, 45 };
                LaunchPad.Sort.MergeSort(array, 0, 3);
                bool flag = Enumerable.SequenceEqual(array, new double[] { 45, 45, 45, 45 });
                Assert.AreEqual(flag, true);
            }
        #endregion

        #region Test for Bubble Sort
            [TestMethod]
            public void BubbleSortTest1()
            {
                double[] array = { 54, 543, -54, 0 };
                LaunchPad.Sort.BubbleSort(array);
                bool flag = Enumerable.SequenceEqual(array, new double[] { -54, 0, 54, 543 });
                Assert.AreEqual(flag, true);
            }

            [TestMethod]
            // empty array as input
            public void BubbleSortTest2()
            {
                double[] array = { };
                LaunchPad.Sort.BubbleSort(array);
                bool flag = Enumerable.SequenceEqual(array, new double[] { });
                Assert.AreEqual(flag, true);
            }

            [TestMethod]
            // array having all -ve elements
            public void BubbleSortTest3()
            {
                double[] array = { -45, -565, -545454, -5 };
                LaunchPad.Sort.BubbleSort(array);
                bool flag = Enumerable.SequenceEqual(array, new double[] { -545454, -565, -45, -5 });
                Assert.AreEqual(flag, true);
            }

            [TestMethod]
            // array having all elements equal
            public void BubbleSortTest4()
            {
                double[] array = { 45, 45, 45, 45 };
                LaunchPad.Sort.BubbleSort(array);
                bool flag = Enumerable.SequenceEqual(array, new double[] { 45, 45, 45, 45 });
                Assert.AreEqual(flag, true);
            }
        #endregion
    }
}
