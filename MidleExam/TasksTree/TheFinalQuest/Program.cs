using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFinalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split()
                .ToList();
            string commands = null;

            while ((commands = Console.ReadLine()) != "Stop")
            {
                switch (commands.Split()[0])
                {
                    // Delete { index}
                    case "Delete":
                        int.TryParse(commands.Split()[1], out int deleteIndex);
                        if (DeleteIndexIsValid(words, deleteIndex))
                            words.RemoveAt(deleteIndex + 1);
                        break;
                    // Swap { word1} { word2}
                    case "Swap":
                        if (WordIsValid(words, commands.Split()[1]) && WordIsValid(words, commands.Split()[2]))
                            words = Swap(words, commands.Split()[1], commands.Split()[2]).ToList();
                        break;
                    // Put { word} {index} 
                    case "Put":
                        int.TryParse(commands.Split()[2], out int index);
                        if (PutIndexIsValid(words, index))
                        {
                            if (index == 0)
                                words.Add(commands.Split()[1]);
                            else
                                words.Insert(index - 1, commands.Split()[1]);
                        }
                        break;
                    // Sort
                    case "Sort":
                        words.Sort((x,y) => y.CompareTo(x));
                        break;
                    // Replace { word1}{word2} 
                    case "Replace":
                        if (WordIsValid(words, commands.Split()[2]))
                            words[words.IndexOf(commands.Split()[2])] = commands.Split()[1];
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", words));
        }

        static bool DeleteIndexIsValid(List<string> arr, int index)
        {
            return index >= -1 && index < arr.Count - 1;
        }

        static bool PutIndexIsValid(List<string> arr, int index)
        {
            return index > 0 && index <= arr.Count + 1;
        }

        static bool WordIsValid(List<string> arr, string word)
        {
            return arr.Contains(word);
        }

        static List<string> Swap(List<string> arr, string word1, string word2)
        {
            List<string> temp = arr.ToList();
            temp[arr.IndexOf(word1)] = word2;
            temp[arr.IndexOf(word2)] = word1;

            return temp;
        }
    }
}
