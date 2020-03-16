using System;
using System.Collections.Generic;
using System.Linq;

namespace TanksCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tanks = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string commands = Console.ReadLine();
                string command = commands.Split(", ", 2)[0];
                string action = commands.Split(", ", 2)[1];

                switch (command)
                {
                    // Add, {tankName}: 
                    case "Add":
                        if (tanks.Contains(action))
                            Console.WriteLine("Tank is already bought");
                        else
                        {
                            Console.WriteLine("Tank successfully bought");
                            tanks.Add(action);
                        }
                        break;
                    // Remove, {tankName}
                    case "Remove":
                        if (tanks.Contains(action))
                        {
                            Console.WriteLine("Tank successfully sold");
                            tanks.Remove(action);
                        }
                        else
                            Console.WriteLine("Tank not found");
                        break;
                    // Remove At, {index}
                    case "Remove At":
                        int.TryParse(action, out int index);
                        if(!IndexIsValid(tanks, index))
                        {
                            Console.WriteLine("Index out of range");
                            continue;
                        }
                        tanks.RemoveAt(index);
                        Console.WriteLine("Tank successfully sold");
                        break;
                    // Insert, {index}, {tankName}
                    case "Insert":
                        int.TryParse(action.Split(", ")[0], out int insertIndex);
                        string tankName = action.Split(", ")[1];
                        if (!IndexIsValid(tanks, insertIndex))
                        {
                            Console.WriteLine("Index out of range");
                            continue;
                        }
                        if(tanks.Contains(tankName))
                            Console.WriteLine("Tank is already bought");
                        else
                        {
                            Console.WriteLine("Tank successfully bought");
                            tanks.Insert(insertIndex, tankName);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", tanks));
        }

        static bool IndexIsValid(List<string> arr, int index)
        {
            return index >= 0 && index < arr.Count;
        }
    }
}
