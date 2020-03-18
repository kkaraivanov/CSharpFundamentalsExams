namespace Nikulden_sMeals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var collectionMeals = new Dictionary<string, List<string>>();
            int unlikeMealsCount = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop")
                    break;

                var command = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string guest = command[1];
                string meal = command[2];
                var meals = new List<string>();

                switch (command[0])
                {
                    // Like-{guest}-{mea1}
                    case "Like":
                        if (!collectionMeals.ContainsKey(guest))
                            collectionMeals.Add(guest, meals);
                        if (!collectionMeals[guest].Contains(meal))
                            collectionMeals[guest].Add(meal);
                        break;
                    // Unlike-{guest}-{meal}
                    case "Unlike":
                        if (!collectionMeals.ContainsKey(guest))
                        {
                            Console.WriteLine($"{guest} is not at the party.");
                            continue;
                        }
                        if (!collectionMeals[guest].Contains(meal))
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                            continue;
                        }
                        collectionMeals[guest].Remove(meal);
                        Console.WriteLine($"{guest} doesn't like the {meal}.");
                        unlikeMealsCount++;
                        break;
                }
            }

            foreach (var meal in collectionMeals
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{meal.Key}: {string.Join(", ", meal.Value)}");
            }
            Console.WriteLine($"Unliked meals: {unlikeMealsCount}");
        }
    }
}
