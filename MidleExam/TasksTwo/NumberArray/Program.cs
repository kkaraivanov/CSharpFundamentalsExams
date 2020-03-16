using System;
using System.Linq;

namespace NumberArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] inputNumberArray = input.Split().Select(int.Parse).ToArray();
            string[] currentLine = new string[input.Length];
            while (currentLine[0] != "End")
            {
                string command = currentLine[0];
                int indexNumber = 0;
                bool numberExist = false;
                switch (command)
                {
                    case "Switch":
                        indexNumber = int.Parse(currentLine[1]);
                        numberExist = inputNumberArray.Length - 1 >= indexNumber;
                        if (indexNumber < 0)
                            break;
                        else if (numberExist)
                        {
                            int num = inputNumberArray[indexNumber] * 2;
                            inputNumberArray[indexNumber] -= num;
                        }
                        break;
                    case "Change":
                        indexNumber = int.Parse(currentLine[1]);
                        numberExist = inputNumberArray.Length - 1 >= indexNumber;
                        if (indexNumber < 0)
                            break;
                        else if (numberExist)
                        {
                            inputNumberArray[indexNumber] = int.Parse(currentLine[2]);
                        }
                        break;
                    case "Sum":
                        string subCommand = currentLine[1];
                        Console.WriteLine(GetSum(subCommand, inputNumberArray));
                        break;
                }
                currentLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(" ", inputNumberArray.Where(i => i >= 0)));
        }
        static int GetSum(string command, int[] arr)
        {
            int result = 0;
            foreach (var num in arr)
            {
                if (command == "Negative")
                {
                    if (num < 0)
                        result += num;
                }
                else if (command == "Positive")
                {
                    if (num >= 0)
                        result += num;
                }
                else if (command == "All")
                {
                    result += num;
                }
            }
            return result;
        }
    }
}
