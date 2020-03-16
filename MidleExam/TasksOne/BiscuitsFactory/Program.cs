using System;
using System.Collections;

namespace BiscuitsFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            long amountOfBiscuits = long.Parse(Console.ReadLine()); // for one worker per day
            long workersCount = long.Parse(Console.ReadLine()); // workers
            long concurents = long.Parse(Console.ReadLine()); // amount for 30 days

            double monthAmount = 0; // amountOfBiscuits * workersCount * 30;
            double dayAmount = amountOfBiscuits * workersCount;
            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0)
                    monthAmount += Math.Floor(dayAmount * 0.75);
                else
                    monthAmount += dayAmount;

            }
            double percentAmount = Math.Abs(monthAmount - concurents) / concurents * 100;

            Console.WriteLine($"You have produced {monthAmount} biscuits for the past month.");
            if(monthAmount > concurents)
                Console.WriteLine($"You produce {percentAmount:f2} percent more biscuits.");
            else
                Console.WriteLine($"You produce {percentAmount:f2} percent less biscuits.");
        }
    }
}
