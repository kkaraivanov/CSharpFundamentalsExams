namespace Nikulden_sCharity
{
    using System;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string commands = null;

            while ((commands = Console.ReadLine()) != "Finish")
            {
                var actions = commands.Split(" ", 2);
                string command = actions[0];
                string action = actions[1];

                switch (command)
                {
                    // Replace {currentChar} {newChar}
                    case "Replace":
                        char oldEl = char.Parse(action.Split()[0]);
                        char newEl = char.Parse(action.Split()[1]);
                        input = new string(ReplaceElement(input, oldEl, newEl));
                        Console.WriteLine(input);
                        break;
                    //Cut {startIndex} {endIndex}
                    case "Cut":
                        int.TryParse(action.Split()[0], out int startIndex);
                        int.TryParse(action.Split()[1], out int endIndex);

                        if (IndexIsValid(input, startIndex) && IndexIsValid(input, endIndex))
                        {
                            input = new string(RemoveElement(input, startIndex, endIndex));
                            Console.WriteLine(input);
                        }
                        else
                            Console.WriteLine("Invalid indexes!");
                        break;
                    // Make {Upper/Lower}
                    case "Make":
                        if (action == "Upper")
                        {
                            input = input.ToUpper();
                            Console.WriteLine(input);
                        }
                        else if (action == "Lower")
                        {
                            input = input.ToLower();
                            Console.WriteLine(input);
                        }
                        break;
                    // Check {string}
                    case "Check":
                        if (input.Contains(action))
                            Console.WriteLine($"Message contains {action}");
                        else
                            Console.WriteLine($"Message doesn't contain {action}");
                        break;
                    // Sum {startIndex} {endIndex}
                    case "Sum":
                        int.TryParse(action.Split()[0], out int start);
                        int.TryParse(action.Split()[1], out int end);
                        int len = end - start + 1;
                        
                        if (IndexIsValid(input, start) && IndexIsValid(input, end))
                        {
                            string substring = input.Substring(start, len);
                            Console.WriteLine(Sum(substring));
                        }
                        else
                            Console.WriteLine("Invalid indexes!");
                        break;
                }
            }
        }

        static int Sum(string str)
        {
            int temp = 0;
            for (int i = 0; i < str.Length; i++)
            {
                temp += str[i];
            }

            return temp;
        }
        static char[] RemoveElement(string elements, int startIndex, int endIndex)
        {
            if (startIndex + endIndex > elements.Length)
                elements.ToCharArray();

            var temp = elements.ToCharArray();
            for (var i = startIndex; i <= endIndex; i++)
                temp[i] = ' ';
            temp = temp.Where(x => x != ' ').ToArray();

            return temp;
        }
        static char[] ReplaceElement(string elements, char oldElement, char newElement)
        {
            var temp = elements.ToCharArray();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == oldElement)
                    temp[i] = newElement;
            }

            return temp;
        }

        static bool IndexIsValid(string arr, int index)
        {
            return index >= 0 && arr.Length > index;
        }
    }
}
