using System;
using System.Collections.Generic;
using System.Linq;

namespace FriendlistMaintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friends = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string commands = null;
            int blackList = 0;
            int lostList = 0;

            while ((commands = Console.ReadLine()) != "Report")
            {
                string actions = commands.Split(" ", 2)[1];
                switch (commands.Split()[0])
                {
                    // Blacklist {name}
                    case "Blacklist":
                        if (friends.Contains(actions))
                        {
                            blackList++;
                            friends[friends.IndexOf(actions)] = "Blacklisted";
                            Console.WriteLine($"{actions} was blacklisted.");
                        }
                        else
                            Console.WriteLine($"{actions} was not found.");
                        break;
                    // Error {index}  
                    case "Error":
                        int findIndex = int.Parse(actions);
                        string name = friends[findIndex];
                        if (name != "Blacklisted" && name != "Lost")
                        {
                            lostList++;
                            friends[findIndex] = "Lost";
                            Console.WriteLine($"{name} was lost due to an error.");
                        }
                        break;
                    // Change {index} {newName}
                    case "Change":
                        int.TryParse(actions.Split()[0], out int index);
                        if (IndexIsValid(friends, index))
                        {
                            string currentName = friends[index];
                            friends[index] = actions.Split()[1];
                            Console.WriteLine($"{currentName} changed his username to {actions.Split()[1]}.");
                        }
                        break;
                }
            }

            Console.WriteLine($"Blacklisted names: {blackList}");
            Console.WriteLine($"Lost names: {lostList}");
            Console.WriteLine(string.Join(" ", friends));
        }

        static bool IndexIsValid(List<string> arr, int index)
        {
            return index >= 0 && index < arr.Count;
        }
    }
}
