using System;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine()
                .Split("!")
                .ToList();
            string commands = null;

            while ((commands = Console.ReadLine()) != "Go Shopping!")
            {
                string command = commands.Split()[0];
                string action = commands.Split(" ", 2)[1];

                switch (command)
                {
                    // Urgent {item}
                    case "Urgent":
                        if (groceries.Contains(action))
                            continue;
                        groceries.Insert(0, action);
                        break;
                    // Unnecessary {item}
                    case "Unnecessary":
                        if (!groceries.Contains(action))
                            continue;
                        groceries.Remove((action));
                        break;
                    // Correct {oldItem} {newItem}
                    case "Correct":
                        if (!groceries.Contains(action.Split()[0]))
                            continue;
                        groceries[groceries.IndexOf(action.Split()[0])] = action.Split()[1];
                        break;
                    // Rearrange {item}
                    case "Rearrange":
                        if (groceries.Contains(action))
                        {
                            string str = groceries[groceries.IndexOf(action)];
                            groceries.Remove(action);
                            groceries.Add(str);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}
