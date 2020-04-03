using System;
using System.Linq;
using System.Text;

namespace StringManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                var commands = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (commands.Contains("End"))
                {
                    break;
                }
                if (commands.Contains("Translate"))
                {
                    var oldChar = commands[1][0];
                    var replacement = commands[2][0];

                    input = Translate(input, oldChar, replacement);
                    Console.WriteLine(input);
                }

                if (commands.Contains("Includes"))
                {
                    Console.WriteLine(input.Contains(commands[1]) ? "True" : "False");
                }

                if (commands.Contains("Start"))
                {
                    Console.WriteLine(Start(input, commands[1]) ? "True" : "False");
                }

                if (commands.Contains("Lowercase"))
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }

                if (commands.Contains("FindIndex"))
                {
                    int index = FindIndex(input, commands[1][0]);
                    Console.WriteLine(index);
                }

                if (commands.Contains("Remove"))
                {
                    int.TryParse(commands[1], out int index);
                    int.TryParse(commands[2], out int count);
                    input = Remove(input, index, count);
                    Console.WriteLine(input);
                }
            }
        }

        private static string Remove(string str, int startIndex, int count)
        {
            return (startIndex >= 0 && startIndex < str.Length)&& count <= str.Substring(0,str.Length - startIndex).Length
                ? new string(str.Remove(startIndex, count)) 
                : str;
        }

        private static int FindIndex(string str, char c)
        {
            return str.LastIndexOf(c);
        }

        private static bool Start(string str, string variable)
        {
            string temp = str.Substring(0, variable.Length);

            return temp == variable;
        }

        private static string Translate(string str, char old, char replacement)
        {
            var sb = new StringBuilder();
            foreach (var item in str)
            {
                if (item.Equals(old))
                {
                    sb.Append(replacement);
                }
                else
                {
                    sb.Append(item);
                }
            }

            return new string(sb.ToString());
        }
    }
}
