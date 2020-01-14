using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeExercise
{
    public class TextUtility
    {

        private static List<string> _punctuations = new List<string>() { ",", ".", "?", "!" };

        public static string GetPunctuationMistakesFixed(string text)
        {
            if (CheckPunctuationText(text))
            {
                var texts = new List<string>();
                var segments = text.Split(' ');

                for (int index = 0; index < segments.Length; index++)
                {
                    if (_punctuations.Contains(segments[index]))
                    {
                        if (texts.Last().Contains(" "))
                        {
                            texts[texts.Count - 1] = $"{texts.Last().TrimEnd()}{segments[index]} ";
                        }
                    }
                    else
                    {
                        HandleNonPunctuations(texts, segments, index);
                    }
                }
                return string.Join("", texts);
            }
            throw new Exception("illegal length");
        }

        public static string GetReverse(string text)
        {
            var result = "";
            if (!string.IsNullOrEmpty(text))
            {
                var reverses = new StringBuilder(text.Length);
                try
                {
                    var chars = text.ToCharArray();
                    for (int i = chars.Length - 1; i >= 0; i--)
                    {
                        reverses.Append(chars[i]);
                    }
                    return reverses.ToString();
                }
                catch { }
            }
            return result;
        }

        public static string GetReverseInRecursive(string text)
        {
            var result = "";
            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    var chars = text.ToCharArray();
                    result = GetCharsInRecursive(chars, chars.Length - 1);
                }
            }
            catch { }
            return result;
        }

        private static string GetCharsInRecursive(char[] chars, int i)
        {
            if (i == 0)
            {
                return chars[i].ToString();
            }
            else
            {
                return string.Concat(chars[i], GetCharsInRecursive(chars, i - 1));
            }
        }

        private static void HandleNonPunctuations(List<string> texts, string[] segments, int index)
        {
            if (index < segments.Length - 1)
            {
                var hit = false;
                for (int j = 0; j < _punctuations.Count; j++)
                {
                    if (segments[index].Contains(_punctuations[j]))
                    {
                        var separator = new string[] { _punctuations[j] };
                        var metaSegments = segments[index].Split(separator, StringSplitOptions.RemoveEmptyEntries);

                        for (int k = 0; k < metaSegments.Length; k++)
                        {
                            var segment = k < metaSegments.Length - 1 ?
                                          $"{metaSegments[k]}{_punctuations[j]} " : $"{metaSegments[k]} ";
                            texts.Add(segment);
                        }
                        hit = true;
                    }
                }
                if (!hit)
                {
                    texts.Add($"{segments[index]} ");
                }
            }
            else
            {
                texts.Add($"{segments[index]}");
            }
        }

        private static bool CheckPunctuationText(string text)
        {
            return text.Length > 0 && text.Length <= 500 ? true : false;
        }

    }
}
