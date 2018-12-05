using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
        public class StringCalculator
        {
            public int Add(string input)
            {
                if (HasCustomDelimiter(input))
                {
                    string delimiters = StripOffNumbers(input);
                    input = StripOffDelimiterMetadata(input);
                    return AddNumbers(input, GetDelimiters(delimiters));
                }

                return AddNumbers(input, GetDelimiters(string.Empty));
            }

            private string StripOffNumbers(string input)
            {
                return input.Substring(0, input.IndexOf('\n')).Substring(2);
            }

            private int AddNumbers(string input, string[] delimiters)
            {
                if (input.Length == 0)
                {
                    return 0;
                }

                return SplitNumbers(input, delimiters).Select(ParseNumber).Where(n => n < 1000).Sum();
            }

            private static int ParseNumber(string s)
            {
                int result = int.Parse(s);
                if (result < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return result;
            }

            private string[] SplitNumbers(string input, string[] delimiters)
            {
                return input.Split(delimiters, StringSplitOptions.None);
            }

            private string StripOffDelimiterMetadata(string input)
            {
                if (HasCustomDelimiter(input))
                {
                    return input.Substring(input.IndexOf('\n') + 1);
                }

                return input;
            }

            private static bool HasCustomDelimiter(string input)
            {
                return input.StartsWith("//");
            }

            private string[] GetDelimiters(string customDelimiters)
            {
                var delimiters = new List<string> { ",", "\n" };
                if (string.IsNullOrEmpty(customDelimiters))
                {
                    return delimiters.ToArray();
                }

                if (customDelimiters.StartsWith("["))
                {
                    var longDelimiters = customDelimiters.Replace("[", "]").Split(new[] { ']' }, StringSplitOptions.RemoveEmptyEntries);
                    delimiters.AddRange(longDelimiters);
                    return delimiters.ToArray();
                }

                delimiters.Add(customDelimiters[0].ToString());
                return delimiters.ToArray();
            }

        }
    }

