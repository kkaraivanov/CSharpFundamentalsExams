using System;
using System.Linq;
using System.Collections.Generic;

namespace EasterShopping
{
    class Program
    {
        static void Main()
        {
            List<string> shops = Console.ReadLine()
                .Split()
                .ToList();
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string commands = Console.ReadLine();
                string action = commands.Split(" ", 2)[1];
                switch (commands.Split()[0])
                {
                    // "Include {shop}"
                    case "Include":
                        shops.Add(action);
                        break;
                    // Visit {first/last} {numberOfShops}
                    case "Visit":
                        int.TryParse(action.Split()[1], out int numberOfShops);
                        if (numberOfShops > shops.Count)
                            continue;
                        switch (action.Split()[0])
                        {
                            case "first":
                                shops = shops.Skip(numberOfShops).ToList();
                                break;
                            case "last":
                                shops = shops.Take(shops.Count - numberOfShops).ToList();
                                break;
                        }
                        break;
                    // Prefer {shopIndex1} {shopIndex2}
                    case "Prefer":
                        int.TryParse(action.Split()[0], out int shopIndex1);
                        int.TryParse(action.Split()[1], out int shopIndex2);
                        if (IndexIsValid(shops, shopIndex1) && IndexIsValid(shops, shopIndex2))
                            shops = Swap(shops, shopIndex1, shopIndex2).ToList();
                        break;
                    // Place {shop} {shopIndex}
                    case "Place":
                        int.TryParse(action.Split()[1], out int index);
                        if (IndexIsValid(shops, index))
                            if (index < shops.Count - 1)
                                shops.Insert(index + 1, action.Split()[0]);
                        break;
                }
            }

            Console.WriteLine($"Shops left:{Environment.NewLine}{string.Join(" ",shops)}");
        }

        private static List<string> Swap(List<string> arr, int shopIndex1, int shopIndex2)
        {
            string temp = arr[shopIndex1];
            arr[shopIndex1] = arr[shopIndex2];
            arr[shopIndex2] = temp;

            return arr;
        }

        static bool IndexIsValid(List<string> arr, int index)
        {
            return index >= 0 && index < arr.Count;
        }
    }
}
