using System;
using System.Collections.Generic;
using System.Linq;

namespace FroggySquad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frogs = Console.ReadLine()
                .Split()
                .ToList();

            while (true)
            {
                var commands = Console.ReadLine().Split();

                switch (commands[0])
                {
                    case "Join":
                        if (NameIsExist(frogs, commands[1]))
                            frogs.Add(commands[1]);
                        break;
                    case "Jump":
                        int.TryParse(commands[2], out int ji);
                        if (NameIsExist(frogs, commands[1]) && IndexIsExist(frogs, ji))
                            frogs.Insert(ji, commands[1]);
                        break;
                    case "Dive":
                        int.TryParse(commands[1], out int di);
                        if (IndexIsExist(frogs, di))
                            frogs.RemoveAt(di);
                        break;
                    case "First":
                    case "Last":
                        int.TryParse(commands[1], out int count);
                        Console.WriteLine(DisplayFerstLastFrogs(frogs, commands[0], count));
                        break;
                    case "Print":
                        switch (commands[1])
                        {
                            case "Normal":
                                Console.WriteLine($"Frogs: {string.Join(" ", frogs)}");
                                return;
                            case "Reversed":
                                frogs.Reverse();
                                Console.WriteLine($"Frogs: {string.Join(" ", frogs)}");
                                return;
                        }
                        break;
                }
            }
        }

        private static bool IndexIsExist(List<string> arr, int index)
        {
            return index >= 0 && index < arr.Count;
        }

        private static bool NameIsExist(List<string> arr, string name)
        {
            return !arr.Contains(name);
        }

        private static string DisplayFerstLastFrogs(List<string> arr, string command, int count)
        {
            if (count > arr.Count)
                return string.Join(" ", arr).ToString();
            if(command == "First")
                return string.Join(" ", arr.Take(count)).ToString();
            else if (command == "Last")
                return string.Join(" ", arr.Skip(arr.Count - count)).ToString();

            return string.Join(" ", arr).ToString();
        }
    }
}
