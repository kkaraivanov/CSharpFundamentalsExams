using System;
using System.Collections.Generic;
using System.Linq;

namespace ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> statusPirateShip = Console.ReadLine()
                .Split('>')
                .Select(int.Parse)
                .ToList();
            List<int> statusWarShip = Console.ReadLine()
                .Split('>')
                .Select(int.Parse)
                .ToList();
            int healthCapacity = int.Parse(Console.ReadLine());
            string commands = null;

            while ((commands = Console.ReadLine()) != "Retire")
            {
                switch (commands.Split()[0])
                {
                    // Fire {index} {damage} 
                    case "Fire":
                        int.TryParse(commands.Split()[1], out int fireIndex);
                        int.TryParse(commands.Split()[2], out int fireDamage);

                        if (!IndexIsValid(statusWarShip, fireIndex))
                            continue;
                        if(HealtIsNotEnough(statusWarShip, fireIndex, fireDamage))
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }

                        statusWarShip[fireIndex] = statusWarShip[fireIndex] - fireDamage;
                        break;
                    // Defend {startIndex} {endIndex} {damage}
                    case "Defend":
                        int.TryParse(commands.Split()[1], out int startIndex);
                        int.TryParse(commands.Split()[2], out int endIndex);
                        int.TryParse(commands.Split()[3], out int defendDamage);

                        if (!IndexIsValid(statusPirateShip, startIndex) || !IndexIsValid(statusPirateShip, endIndex))
                            continue;
                        if (HealtIsNotEnough(statusPirateShip, startIndex, endIndex, defendDamage))
                        {
                            Console.WriteLine("You lost! The pirate ship has sunken.");
                            return;
                        }

                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            statusPirateShip[i] -= defendDamage;
                        }
                        break;
                    // Repair {index} {health} 
                    case "Repair":
                        int.TryParse(commands.Split()[1], out int repareIndex);
                        int.TryParse(commands.Split()[2], out int repareHealt);
                        if (!IndexIsValid(statusPirateShip, repareIndex))
                            continue;

                        statusPirateShip[repareIndex] = Math.Min(healthCapacity, statusPirateShip[repareIndex] + repareHealt);
                        break;
                    case "Status":
                        int sectionNeedRepair = (int)(healthCapacity * 0.20);
                        Console.WriteLine($"{statusPirateShip.Where(x => x < sectionNeedRepair).Count()} sections need repair.");
                        break;
                }
            }

            Console.WriteLine($"Pirate ship status: {statusPirateShip.Sum()}");
            Console.WriteLine($"Warship status: {statusWarShip.Sum()}");
        }

        private static bool HealtIsNotEnough(List<int> arr, int index, int damage)
        {
            return arr[index] - damage <= 0;
        }

        private static bool HealtIsNotEnough(List<int> arr, int startIndex, int endIndex, int damage)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (arr[i] - damage <= 0)
                    return true;
            }

            return false;
        }

        private static bool IndexIsValid(List<int> arr, int index)
        {
            return index >= 0 && index < arr.Count;
        }
    }
}
