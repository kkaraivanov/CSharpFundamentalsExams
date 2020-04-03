using System;
using System.Collections.Generic;
using System.Linq;

namespace MessagesManager
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            var users = new Dictionary<string,Messages>();

            while (true)
            {
                var commands = Console.ReadLine().Split("=").ToArray();
                ;
                if (commands.Contains("Statistics"))
                {
                    break;
                }

                if (commands.Contains("Add"))
                {
                    string user = commands[1];
                    var message = new Messages();
                    message.SentMessage = int.Parse(commands[2]);
                    message.ReceivedMessage = int.Parse(commands[3]);

                    if (UserNameIsValid(users, user))
                        continue;

                    AddUser(users, user, message);
                }

                if (commands.Contains("Message"))
                {
                    string sender = commands[1];
                    string receiver = commands[2];

                    if (UserNameIsValid(users, sender) && UserNameIsValid(users, receiver))
                    {
                        if (CapacityOut(users, sender, maxCapacity))
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                        }
                        else
                        {
                            AddSentMessage(users, sender);
                        }

                        if (CapacityOut(users, receiver, maxCapacity))
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }
                        else
                        {
                            AddReceivedMessage(users, receiver);
                        }
                    }
                }

                if (commands.Contains("Empty"))
                {
                    var user = commands[1];

                    if (user.Equals("All"))
                    {
                        users.Clear();
                    }

                    if (UserNameIsValid(users, user))
                        users.Remove(user);
                }
            }

            Console.WriteLine($"Users count: {users.Count}");
            foreach (var user in users
                .OrderByDescending(x => x.Value.ReceivedMessage)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} - {user.Value.ReceivedMessage + user.Value.SentMessage}");
            }
        }

        private static bool CapacityOut(Dictionary<string, Messages> db, string user, int capacity)
        {
            int count = MessageCount(db, user);
            if (count >= capacity)
            {
                db.Remove(user);
                return true;
            }
            else if (count + 1 >= capacity)
            {
                db.Remove(user);
                return true;
            }
            
            return false;
        }

        private static bool UserNameIsValid(Dictionary<string, Messages> db, string user)
        {
            return db.ContainsKey(user);
        }

        private static int MessageCount(Dictionary<string, Messages> db, string user)
        {
            return db[user].SentMessage + db[user].ReceivedMessage;
        }

        private static void AddUser(Dictionary<string, Messages> db, string user, Messages message)
        {
            db.Add(user, message);
        }

        private static void AddSentMessage(Dictionary<string, Messages> db, string user)
        {
            db[user].SentMessage++;
        }
        
        private static void AddReceivedMessage(Dictionary<string, Messages> db, string user)
        {
            db[user].ReceivedMessage++;
        }
    }
}
