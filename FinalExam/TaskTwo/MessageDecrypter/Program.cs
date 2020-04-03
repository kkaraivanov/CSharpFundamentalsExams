using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MessageDecrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var regex = new Regex(@"^(\$|\%)([A-Z][a-z]{2,})\1\: ((\[[0-9]+\]\|){3})$");

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                var match = regex.Match(input);

                if (match.Success)
                {
                    var tag = match.Groups[2].ToString();
                    var ascii = match.Groups[3].ToString();
                    Console.WriteLine($"{tag}: {DecryptedMessage(ascii)}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }

        private static string DecryptedMessage(string input)
        {
            var sb = new StringBuilder();
            var numberForAscii = input
                .Split('|')
                .Select(x => x.Replace("[", ""))
                .Select(x => x.Replace("]", ""))
                .Where(x => x != string.Empty)
                .Select(int.Parse)
                .ToArray();

            foreach (var item in numberForAscii)
            {
                sb.Append((char) item);
            }

            return new string(sb.ToString());
        }
    }
}
