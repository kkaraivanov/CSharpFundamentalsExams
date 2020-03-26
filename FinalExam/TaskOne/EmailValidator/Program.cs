using System.Diagnostics.Tracing;

namespace EmailValidator
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string commands = null;

            while ((commands = Console.ReadLine()) != "Complete")
            {
                var command = commands.Split();
                
                switch (command[0])
                {
                    case "Make":
                        if (command[1] == "Upper")
                        {
                            email = email.ToUpper();
                        }
                        else if(command[1] == "Lower")
                        {
                            email = email.ToLower();
                        }

                        Console.WriteLine(email);
                        break;
                    case "GetDomain":
                        int.TryParse(command[1], out int count);
                        Console.WriteLine(email.Substring(email.Length - count, count));
                        break;
                    case "GetUsername":
                        if (!email.Contains("@"))
                        {
                            Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                            break;
                        }

                        Console.WriteLine($"{email.Split("@", 2)[0]}");
                        break;
                    case "Replace":
                        var replace = char.Parse(command[1]);
                        Console.WriteLine(DoReplace(email, replace));
                        break;
                    case "Encrypt":
                        Console.WriteLine(string.Join(" ", Encrypt(email)));
                        break;
                }
            }
        }

        static int[] Encrypt(string str)
        {
            var temp = new int[str.Length];
            int counter = 0;

            foreach (var c in str)
            {
                int current = c;
                temp[counter] = current;
                counter++;
            }

            return temp;
        }

        static string DoReplace(string str, char c)
        {
            var temp = str.ToCharArray();

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Equals(c))
                {
                    temp[i] = '-';
                }
            }

            return new string(temp);
        }
    }
}
