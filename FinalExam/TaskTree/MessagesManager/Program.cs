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
                    int sent = int.Parse(commands[2]);
                    int received = int.Parse(commands[2]);
                }
            }
        }
    }

    class Messages
    {
        public int SentMessage { get; set; }
        public int ReceivedMessage { get; set; }
    }
}
