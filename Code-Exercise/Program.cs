using System;

namespace CodeExercise
{
    class Program
    {
        static void Main(string[] args)
        {

            var text = "This English letters , punctuation marks,and spaces.";
            Console.WriteLine(TextUtility.GetPunctuationMistakesFixed(text));

            Console.ReadKey();
        }
    }
}
