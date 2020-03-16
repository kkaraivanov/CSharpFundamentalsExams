using System;

namespace DistanceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsMade = int.Parse(Console.ReadLine());
            decimal lengthOfOneStep = decimal.Parse(Console.ReadLine());
            int distanceYouNeedToTravel = int.Parse(Console.ReadLine());

            decimal distanceTravel = 0;
            decimal discountStep = lengthOfOneStep * 0.70m;
            for (int i = 1; i <= stepsMade; i++)
            {
                if (i % 5 == 0)
                    distanceTravel += discountStep;
                else
                    distanceTravel += lengthOfOneStep;
            }

            decimal percent = distanceTravel / distanceYouNeedToTravel;
            Console.WriteLine($"You travelled {percent:f2}% of the distance!");
        }
    }
}
