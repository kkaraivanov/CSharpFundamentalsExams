using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gifts = Console.ReadLine()
                .Split()
                .ToList();
            string commands = null;

            while ((commands = Console.ReadLine()) != "No Money")
            {
                string action = commands.Split(" ", 2)[1];

                switch (commands.Split(" ",2)[0])
                {
                    // OutOfStock {gift}
                    case "OutOfStock":
                        if (gifts.Contains(action))
                            gifts = OutOfStockChange(gifts, action).ToList();
                        break;
                    // Required {gift} {index}"
                    case "Required":
                        int.TryParse(action.Split()[1], out int index);
                        if (IndexIsValid(gifts, index))
                            gifts[index] = action.Split()[0];
                        break;
                    // JustInCase {gift}
                    case "JustInCase":
                        gifts[gifts.Count - 1] = action;
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", gifts.Where(x => x != "None")));
        }

        private static List<string> OutOfStockChange(List<string> arr, string giftName)
        {
            for (int i = 0; i < arr.Count; i++)
                if (arr[i] == giftName)
                    arr[i] = "None";

            return arr;
        }

        private static bool IndexIsValid(List<string> arr, int index)
        {
            return index >= 0 && index < arr.Count;
        }
    }
}
