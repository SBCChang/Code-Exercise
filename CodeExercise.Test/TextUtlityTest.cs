using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CodeExercise.Test
{
    [TestClass]
    public class TextUtlityTest
    {

        [TestMethod]
        public void GetPunctuationMistakesFixed_Basic_ReturnFixed()
        {
            var text = "This English letters , punctuation marks,and spaces.";
            var expected = "This English letters, punctuation marks, and spaces.";
            var actual = TextUtility.GetPunctuationMistakesFixed(text);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "illegal length")]
        public void GetPunctuationMistakesFixed_NoText_ThrowException()
        {
            var text = "";
            var actual = TextUtility.GetPunctuationMistakesFixed(text);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "illegal length")]
        public void GetPunctuationMistakesFixed_TextLengthOver500_ThrowException()
        {
            var textSegments = Enumerable.Repeat("text", 101).ToArray();
            var text = string.Join(",", textSegments);
            var actual = TextUtility.GetPunctuationMistakesFixed(text);
        }

        [TestMethod]
        public void GetReverse_NoText_ReturnEmpty()
        {
            var text = "";
            var expected = "";
            var actual = TextUtility.GetReverse(text);
            
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetReverse_Basic_ReturnReversed()
        {
            var text = "abc";
            var expected = "cba";
            var actual = TextUtility.GetReverse(text);

            Assert.AreEqual(actual, expected);
        }

    }
}
