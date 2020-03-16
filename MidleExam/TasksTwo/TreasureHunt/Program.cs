using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> loot = Console.ReadLine()
                .Split('|')
                .ToList();
            string command = null;

            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                switch (command.Split()[0])
                {
                    case "Loot":
                        List<string> newLoot = command.Split().Skip(1).Reverse().ToList();
                        loot.InsertRange(0, newLoot.Where(x => !loot.Contains(x)));
                        break;
                    case "Drop":
                        int.TryParse(command.Split()[1], out int index);
                        if (index < 0 || index > loot.Count - 1)
                            continue;
                        loot.Add(loot[index]);
                        loot.RemoveAt(index);
                        break;
                    case "Steal":
                        int.TryParse(command.Split()[1], out int count);
                        if (count >= loot.Count)
                        {
                            Console.WriteLine(string.Join(", ", loot));
                            loot.RemoveRange(0, loot.Count);
                        }
                        else
                        {
                            List<string> steal = loot.Skip(loot.Count - count).ToList();
                            loot = loot.Take(loot.Count - count).ToList();
                            Console.WriteLine(string.Join(", ", steal));
                        }
                        break;
                }
            }

            if (loot.Count > 0)
            {
                int allItemsLength = 0;
                loot.ForEach(x => allItemsLength += x.Length);
                double averageGain = (double)allItemsLength / loot.Count();
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
            else
                Console.WriteLine("Failed treasure hunt.");
        }
    }
}
