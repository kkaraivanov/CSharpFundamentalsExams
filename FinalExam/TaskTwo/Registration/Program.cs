namespace Registration
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([U]\$)([A-Z][a-z]{2,})\1([P]\@\$)([a-z]{5,}[0-9]+)\3";
            int numLine = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 0; i < numLine; i++)
            {
                string email = Console.ReadLine();
                var match = Regex.Match(email, pattern);

                if (match.Success)
                {
                    counter++;
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {match.Groups[2].ToString()}, Password: {match.Groups[4].ToString()}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {counter}");
        }
    }
}
