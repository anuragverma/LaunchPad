﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LaunchPadTest
{
    [TestClass]
    public class PuzzleTest
    {
        [TestMethod]
        public void IsUniqueCharsTest()
        {
            Assert.AreEqual(true, LaunchPad.Puzzles.IsUniqueChars("fdghre"));
        }

        [TestMethod]
        public void ReverseStringTest1()
        {
            Assert.AreEqual("london", LaunchPad.Puzzles.ReverseString("nodnol"));
        }

        [TestMethod]
        public void ReverseStringTest2()
        {
            Assert.AreEqual("1245fd", LaunchPad.Puzzles.ReverseString("df5421"));
        }

        [TestMethod]
        public void RemoveDuplicateCharsTest1()
        {
            char[] inArray = {'d', 'g', 'f', 'd', 'g', 'h'};
            LaunchPad.Puzzles.RemoveDuplicateChars(inArray);
            char[] outArray = { 'd', 'g', 'f', 'h', '\0', '\0'};
            bool flag = Enumerable.SequenceEqual(inArray, outArray);
            Assert.AreEqual(true, flag);
        }

        [TestMethod]
        public void AnagramCheckTest1()
        {
            Assert.AreEqual(true, LaunchPad.Puzzles.AnagramCheck("asdf", "dfas"));
        }

        [TestMethod]
        public void ReplaceSpaceWithTest()
        {
            char[] str = { 'a', ' ', 'n', 'u', 'r', ' ', 'a', 'g'};
            char[] outstr = { 'a', '%', '2', '0', 'n', 'u', 'r', '%', '2', '0', 'a', 'g' };
            char[] result = LaunchPad.Puzzles.ReplaceSpaceWith(str, 8);
            bool flag = Enumerable.SequenceEqual(result, outstr);
            Assert.AreEqual(true, flag);
        }

        [TestMethod]
        public void Rotate2DMatrixTest()
        {
            int[,] input = new int[5,5] { {1,2,3,4,9}, {5,6,198,7,8}, {9,111, 10,11,12}, {13,14,222, 15,16}, {23, 56, 34, 67, 87}};
            //int[,] output = new int[5, 5] { {13,9,5,1},{14,10,6,2},{15,11,7,3},{16,12,8,4}};
            LaunchPad.Puzzles.Rotate2DMatrix(input, 5);
            //bool flag = Enumerable.SequenceEqual(input, output);
        }
    }
}