namespace BossRush
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string input = Console.ReadLine();
                var name = Regex.Match(input, @"[|]([A-Z]+)[|]").Groups[1].ToString();
                var title = Regex.Match(input, @"[#]([A-Za-z]+\s[A-Za-z]+)[#]").Groups[1].ToString();

                if (InputIsValid(input))
                {
                    Console.WriteLine($"{name}, The {title}");
                    Console.WriteLine($">> Strength: {name.Length}");
                    Console.WriteLine($">> Armour: {title.Length}");
                }
                else
                    Console.WriteLine("Access denied!");
            }
        }

        static bool InputIsValid(string str)
        {
            return Regex.IsMatch(str, @"[|]([A-Z]+)[|]\:[#]([A-Za-z]+\s[A-Za-z]+)[#]");
        }
    }
}
