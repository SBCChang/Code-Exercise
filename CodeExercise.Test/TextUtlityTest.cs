using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeExercise.Test
{
    [TestClass]
    public class TextUtlityTest
    {
        [TestMethod]
        public void BasicPunctuationFixedTest()
        {
            var text = "This English letters , punctuation marks,and spaces.";
            var expected = "This English letters, punctuation marks, and spaces.";
            var actual = TextUtility.GetPunctuationMistakesFixed(text);

            Assert.AreEqual(expected, actual);
        }
    }
}
