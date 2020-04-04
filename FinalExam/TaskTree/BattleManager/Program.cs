using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleManager
{
    class Program
    {
        private static Dictionary<string, PersonBody> Persons;

        static void Main(string[] args)
        {
            Persons = new Dictionary<string, PersonBody>();

            while (true)
            {
                var commands = Console.ReadLine()
                    .Split(':')
                    .ToArray();
                var person = new PersonBody();

                if (commands.Contains("Results"))
                {
                    break;
                }

                if (commands.Contains("Add"))
                {
                    person.Name = commands[1];
                    person.Health = int.Parse(commands[2]);
                    person.Energy = int.Parse(commands[3]);

                    AddPerson(person);
                }

                if (commands.Contains("Attack"))
                {
                    var attacker = commands[1];
                    var defender = commands[2];
                    var damage = int.Parse(commands[3]);

                    if (PersonExist(attacker) && PersonExist(defender))
                    {
                        int reductionHealth = ReductionHealth(defender, damage);
                        int reductionEnergy = ReductionEnergy(attacker);
                        
                        if (reductionHealth <= 0)
                        {
                            DeletePerson(defender,true);
                        }

                        if (reductionEnergy <= 0)
                        {
                            DeletePerson(attacker,true);
                        }
                    }
                }

                if (commands.Contains("Delete"))
                {
                    if (commands[1].Contains("All"))
                    {
                        Persons.Clear();
                    }
                    DeletePerson(commands[1]);
                }
            }

            Console.WriteLine($"People count: {Persons.Count}");
            foreach (var person in Persons
                .OrderByDescending(x => x.Value.Health)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{person.Key} - {person.Value.Health} - {person.Value.Energy}");
            }
        }

        private static int ReductionEnergy(string name)
        {
            return Persons[name].Energy -= 1;
        }

        private static int ReductionHealth(string name, int damage)
        {
            return Persons[name].Health -= damage;
        }

        private static void DeletePerson(string name, bool b = false)
        {
            Persons.Remove(name);
            if(b)
                Console.WriteLine($"{name} was disqualified!");
        }

        private static bool PersonExist(PersonBody person)
        {
            return Persons.ContainsKey(person.Name);
        }

        private static bool PersonExist(string name)
        {
            return Persons.ContainsKey(name);
        }

        private static void AddPerson(PersonBody person)
        {
            if (PersonExist(person))
            {
                Persons[person.Name].Health += person.Health;
            }
            else
            {
                Persons.Add(person.Name, person);
            }
        }
    }

    class PersonBody
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Energy { get; set; }
    }
}
