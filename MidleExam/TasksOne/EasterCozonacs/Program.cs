using System;

namespace EasterCozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());

            double eggsPackPrice = flourPrice * 0.75;
            double milkPrice = (flourPrice * 1.25) / 4;
            double totalPriceForOneCozonac = flourPrice + eggsPackPrice + milkPrice;

            int colorEggs = 0;
            int cozonacCounter = 0;
            while (budget - totalPriceForOneCozonac >= 0)
            {
                budget -= totalPriceForOneCozonac;
                cozonacCounter++;
                colorEggs += 3;

                if (cozonacCounter % 3 == 0)
                    colorEggs -= (cozonacCounter - 2);
            }

            Console.WriteLine($"You made {cozonacCounter} cozonacs! Now you have {colorEggs} eggs and {budget:f2}BGN left.");
        }
    }
}
