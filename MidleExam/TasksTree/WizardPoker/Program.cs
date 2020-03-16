using System;
using System.Collections.Generic;
using System.Linq;

namespace WizardPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> deck = Console.ReadLine()
                .Split(':')
                .ToList();
            List<string> newDeck = new List<string>();
            string commands = null;

            while ((commands = Console.ReadLine()) != "Ready")
            {
                switch (commands.Split()[0])
                {
                    // Add {card name}
                    case "Add":
                        if (!deck.Contains(commands.Split()[1]))
                            Console.WriteLine("Card not found.");
                        else
                            newDeck.Add(commands.Split()[1]);
                        break;
                    // Insert {card name} {index}
                    case "Insert":
                        int.TryParse(commands.Split()[2], out int index);
                        if (!deck.Contains(commands.Split()[1]) || !IndexIsValid(newDeck, index))
                            Console.WriteLine("Error!");
                        else
                            newDeck.Insert(index, commands.Split()[1]);
                        break;
                    // Remove {card name}
                    case "Remove":
                        if (!newDeck.Contains(commands.Split()[1]))
                            Console.WriteLine("Card not found.");
                        else
                            newDeck.Remove(commands.Split()[1]);
                        break;
                    // Swap {card name 1} {card name 2} 
                    case "Swap":
                        newDeck = SwapCard(newDeck, commands.Split()[1], commands.Split()[2]).ToList();
                        break;
                    // Shuffle deck 
                    case "Shuffle":
                        newDeck.Reverse();
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", newDeck));
        }

        private static bool IndexIsValid(List<string> arr, int index)
        {
            return index >= 0 && index < arr.Count;
        }

        private static List<string> SwapCard(List<string> arr, string cart1, string cart2)
        {
            List<string> temp = arr.Where(x => x != cart1 && x != cart2).ToList();
            temp.Insert(arr.IndexOf(cart1), cart2);
            temp.Insert(arr.IndexOf(cart2), cart1);

            return temp;
        }
    }
}
