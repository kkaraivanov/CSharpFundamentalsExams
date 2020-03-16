using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = Console.ReadLine().Split().ToList();
            string[] commands = null;
            bool exit = false;
            while (!exit)
            {
                commands = Console.ReadLine().Split().ToArray();
                string command = commands[0];
                switch (command)
                {
                    case "Add":
                        string contact = commands[1];
                        int index = int.Parse(commands[2]);
                        ContactAdd(contact, index, contacts);
                        break;
                    case "Remove":
                        int removeIndex = int.Parse(commands[1]);
                        RemoveIndex(removeIndex, contacts);
                        break;
                    case "Export":
                        int startIndex = int.Parse(commands[1]);
                        int count = int.Parse(commands[2]);
                        PrintContacts(startIndex, count, contacts);
                        break;
                    case "Print":
                        string subCommand = commands[1];
                        Console.Write("Contacts: ");
                        PrintContacts(contacts, subCommand);
                        exit = true;
                        break;
                }
            }
        }

        private static void PrintContacts(List<string> contacts, string command)
        {
            switch (command)
            {
                case "Normal":
                    Console.WriteLine($"{string.Join(" ", contacts)}");
                    break;
                case "Reversed":
                    contacts.Reverse();
                    Console.WriteLine($"{string.Join(" ", contacts)}");
                    break;
            }
        }

        private static void PrintContacts(int startIndex, int count, List<string> contacts)
        {
            if (IndexExist(startIndex, contacts) && startIndex + count < contacts.Count)
            {
                Console.WriteLine(string.Join(" ", contacts.GetRange(startIndex, count).ToArray()));
            }
            else
                Console.WriteLine(string.Join(" ", contacts.Skip(startIndex)));
        }

        private static void RemoveIndex(int index, List<string> contacts)
        {
            if (IndexExist(index, contacts))
            {
                contacts.RemoveAt(index);
            }
        }

        private static void ContactAdd(string contact, int index, List<string> contacts)
        {
            bool contactExist = contacts.Contains(contact);

            if (!contactExist)
            {
                contacts.Add(contact);
            }
            else if(IndexExist(index, contacts) && contactExist)
            {
                contacts.Insert(index, contact);
            }
        }
        private static bool IndexExist(int index, List<string> contacts)
        {
            return index >= 0 && index < contacts.Count;
        }
    }
}
