using System;

namespace TheHuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int adventureDay = int.Parse(Console.ReadLine());
            int playersCount = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterForOnePerson = double.Parse(Console.ReadLine());
            double foodForOnePerson = double.Parse(Console.ReadLine());

            double supliesWater = waterForOnePerson * playersCount * adventureDay;
            double supliesFood = foodForOnePerson * playersCount * adventureDay;
            int days = 0;

            for (int i = 1; i <= adventureDay; i++)
            {
                double loseEnergy = double.Parse(Console.ReadLine());
                if (groupEnergy - loseEnergy <= 0)
                    break;

                groupEnergy -= loseEnergy;
                if(i % 2 == 0)
                {
                    groupEnergy *= 1.05;
                    supliesWater *= 0.70;
                }
                if(i % 3 == 0)
                {
                    groupEnergy *= 1.10;
                    supliesFood -= (supliesFood / playersCount);
                }
                days++;
            }
            if(days == adventureDay)
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
            else
                Console.WriteLine($"You will run out of energy. You will be left with {supliesFood:f2} food and {supliesWater:f2} water.");
        }
    }
}
