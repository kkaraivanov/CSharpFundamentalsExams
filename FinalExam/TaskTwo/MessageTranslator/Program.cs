namespace MessageTranslator
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[!]([A-Z][a-z]{3,})[!]\:[\[]([A-Za-z]{8,})[\]]";
            int line = int.Parse(Console.ReadLine());

            for (int i = 0; i < line; i++)
            {
                string input = Console.ReadLine();

                if (MessageIsValid(input, pattern))
                {
                    string command = Regex.Match(input, pattern).Groups[1].Value;
                    string message = Regex.Match(input, pattern).Groups[2].Value;

                    Console.WriteLine($"{command}: {string.Join(" ", DisplayASCII(message))}");
                }
                else
                    Console.WriteLine("The message is invalid");
            }
        }

        static int[] DisplayASCII(string str)
        {
            var temp = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
                temp[i] = str[i];
            
            return temp;
        }
        static bool MessageIsValid(string message, string pattern)
        {
            return Regex.IsMatch(message, pattern);
        }
    }
}
