using System;
using System.Linq;
using System.Collections.Generic;

namespace HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> num = Console.ReadLine()
                 .Split("@")
                 .Select(int.Parse)
                 .ToList();
            string commands = null;
            int currentIndex = 0;
            while ((commands = Console.ReadLine()) != "Love!")
            {
                int len = int.Parse(commands.Split()[1]);
                currentIndex += len;
                if (currentIndex > num.Count - 1)
                    currentIndex = 0;
                if (num[currentIndex] == 0)
                {
                    Console.WriteLine($"Place {currentIndex} already had Valentine's day.");
                    continue;
                }
                num[currentIndex] -= 2;

                if (num[currentIndex] <= 0)
                {
                    Console.WriteLine($"Place {currentIndex} has Valentine's day.");
                }
            }

            Console.WriteLine($"Cupid's last position was {currentIndex}.");
            bool checkTrue = true; 

            foreach (var item in num)
            {
                if(item != 0)
                {
                    checkTrue = false;
                    break;
                }
            }

            if(checkTrue)
                Console.WriteLine("Mission was successful.");
            else
                Console.WriteLine($"Cupid has failed {num.Where(x => x != 0).Count()} places.");
        }
    }
}
