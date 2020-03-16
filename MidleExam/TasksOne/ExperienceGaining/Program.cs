using System;

namespace ExperienceGaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int countOfBattles = int.Parse(Console.ReadLine());

            double colectExperience = 0;
            int battleCount = 0;
            int counter = 0;
            for (int i = 1; i <= countOfBattles; i++)
            {
                if (counter == 6)
                    counter = 0;
                battleCount++;
                counter++;
                colectExperience += ExperienceEarned(counter, double.Parse(Console.ReadLine()));
                if (colectExperience >= neededExperience)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {battleCount} battles.");
                    break;
                }
            }
            if (colectExperience < neededExperience)
                Console.WriteLine($"Player was not able to collect the needed experience, {neededExperience - colectExperience:f2} more needed.");
        }
        static double ExperienceEarned(int battleCount, double experienceEarned)
        {
            double expiriensUp = experienceEarned * 0.15;
            double expiriensDown = experienceEarned * 0.10;

            return battleCount == 3 ? experienceEarned + expiriensUp :
                   battleCount == 5 ? experienceEarned - expiriensDown :
                   experienceEarned;
        }
    }
}
