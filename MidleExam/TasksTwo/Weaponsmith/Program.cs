using System;
using System.Collections.Generic;
using System.Linq;

namespace Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> partsOfName = Console.ReadLine()
                .Split('|')
                .ToList();
            string commands = null;

            while ((commands = Console.ReadLine()) != "Done")
            {
                string command = commands.Split(" ", 2)[0];
                string action = commands.Split(" ", 2)[1];

                switch (command)
                {
                    // "Move Left {index}":
                    // "Move Right {index}":
                    case "Move":
                        int.TryParse(action.Split()[1], out int index);
                        switch (action.Split()[0])
                        {
                            case "Left":
                                if (!CanMoveLeft(partsOfName, index))
                                    continue;
                                if (IndexIsValid(partsOfName, index))
                                    partsOfName = MoveIndexLeft(partsOfName, index).ToList();
                                break;
                            case "Right":
                                if (!CanMoveRignt(partsOfName, index))
                                    continue;
                                if (IndexIsValid(partsOfName, index))
                                    partsOfName = MoveIndexRight(partsOfName, index).ToList();
                                break;
                        }
                        break;
                    // "Check Even":
                    // "Check Odd":
                    case "Check":
                        switch (action)
                        {
                            case "Even":
                                Console.WriteLine(string.Join(" ", partsOfName.ToList().Where((s, i) => i % 2 == 0)));
                                break;
                            case "Odd":
                                Console.WriteLine(string.Join(" ", partsOfName.ToList().Where((s, i) => i % 2 != 0)));
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine($"You crafted {string.Join("", partsOfName)}!");
        }

        private static List<string> MoveIndexLeft(List<string> arr, int index)
        {
            List<string> temp = arr.Where(x => x != arr[index]).ToList();
            temp.Insert(index - 1, arr[index]);

            return temp;
        }

        private static List<string> MoveIndexRight(List<string> arr, int index)
        {
            List<string> temp = arr.Where(x => x != arr[index]).ToList();
            temp.Insert(index + 1, arr[index]);

            return temp;
        }

        private static bool IndexIsValid(List<string> arr, int index)
        {
            return index >= 0 && index < arr.Count;
        }

        private static bool CanMoveLeft(List<string> arr, int index)
        {
            return index - 1 >= 0;
        }

        private static bool CanMoveRignt(List<string> arr, int index)
        {
            return index + 1 <= arr.Count - 1;
        }
    }
}
