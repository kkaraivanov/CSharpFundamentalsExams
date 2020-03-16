using System;

namespace NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int worker1 = int.Parse(Console.ReadLine());
            int worker2 = int.Parse(Console.ReadLine());
            int worker3 = int.Parse(Console.ReadLine());
            int totalCountPeople = int.Parse(Console.ReadLine());

            int needetTime = 0;
            int answere = worker1 + worker2 + worker3;
            
            for (int i = 1; totalCountPeople > 0; i++)
            {
                if (i % 4 == 0)
                {
                    needetTime++;
                    continue;
                }
                totalCountPeople -= answere;
                needetTime++;
            }

            Console.WriteLine($"Time needed: {needetTime}h.");
        }
    }
}
