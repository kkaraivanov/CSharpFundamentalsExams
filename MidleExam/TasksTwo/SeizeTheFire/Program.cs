using System;
using System.Linq;
using System.Collections.Generic;

namespace SeizeTheFire
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lineOfFire = Console.ReadLine()
                .Split('#')
                .ToList();
            int water = int.Parse(Console.ReadLine());
            double effort = 0;
            List<int> totalFire = new List<int>();

            foreach (var cell in lineOfFire)
            {
                var type = cell.Split(" = ")[0];
                var value = int.Parse(cell.Split(" = ")[1]);

                if (!ValidCellFire(type, value) ||
                    water < value 
                    || water - value < 0)
                    continue;
                water -= value;
                effort += value * 0.25;
                totalFire.Add(value);
            }

            Console.WriteLine("Cells:");
            foreach (var cell in totalFire)
            {
                Console.WriteLine($"- {cell}");
            }
            
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire.Sum()}");
        }

        private static bool ValidCellFire(string fireType, int value)
        {
            switch (fireType)
            {
                // 81 - 125
                case "High":
                    if (value > 80 && value <= 125)
                        return true;
                    break;
                // 51 - 80
                case "Medium":
                    if (value > 50 && value <= 80)
                        return true;
                    break;
                // 1 - 50
                case "Low":
                    if (value > 0 && value <= 50)
                        return true;
                    break;
            }

            return false;
        }
    }
}
