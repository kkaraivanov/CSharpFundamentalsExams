using System;
using System.Linq;
using System.Text;

namespace PasswordReset
{
    class Program
    {
        private static string input = null;
        static void Main(string[] args)
        {
            input = Console.ReadLine();

            while (true)
            {
                var commands = Console.ReadLine().Split().ToArray();

                if (commands.Contains("Done"))
                {
                    break;
                }

                if (commands.Contains("TakeOdd"))
                {
                    input = TakeOdd(input);
                    Console.WriteLine(input);
                }

                if (commands.Contains("Cut"))
                {
                    int index = int.Parse(commands[1]);
                    int length = int.Parse(commands[2]);
                    var sb = new StringBuilder(input);
                    sb.Remove(index, length);
                    input = sb.ToString();
                    Console.WriteLine(input);
                }

                if (commands.Contains("Substitute"))
                {
                    var substring = commands[1];
                    var substitute = commands[2];
                    
                    Console.WriteLine(Substitute(substring, substitute));
                }
            }

            Console.WriteLine($"Your password is: {input}");
        }

        static string Substitute(string substring, string substitute)
        {
            if(!input.Contains(substring))
                return "Nothing to replace!";

            input = input.Replace(substring, substitute);
            return new string(input);
        }
        static string TakeOdd(string input)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 != 0)
                    sb.Append(input[i]);
            }

            return new string(sb.ToString());
        }
    }
}
