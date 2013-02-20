using System;
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
    }
}
