using System.Linq;

namespace InboxManager
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, List<string>>();
            string command = null;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                var arr = command.Split("->", 2);
                var task = arr[0];
                var actions = arr[1];

                switch (task)
                {
                    case "Add":
                        if (users.ContainsKey(actions))
                            Console.WriteLine($"{actions} is already registered");
                        else
                            users.Add(actions, new List<string>());
                        break;
                    case "Send":
                        var user = actions.Split("->")[0];
                        var email = actions.Split("->")[1];
                        users[user].Add(email);
                        break;
                    case "Delete":
                        if (!users.ContainsKey(actions))
                            Console.WriteLine($"{actions} not found!");
                        else
                            users.Remove(actions);
                        break;
                }
            }

            Console.WriteLine($"Users count: {users.Count}");

            foreach (var user in users
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine(user.Key);
                var emails = user.Value;
                for (int i = 0; i < emails.Count; i++)
                {
                    Console.WriteLine($"- {emails[i]}");
                }
            }
        }
    }
}
