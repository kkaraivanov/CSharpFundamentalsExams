namespace HeroRecruitment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string commands = null;
            var heroes = new Dictionary<string, List<string>>();

            while ((commands = Console.ReadLine()) != "End")
            {
                var actions = commands.Split();
                string command = actions[0];
                string heroName = actions[1];
                string spellName = null;
                var spells = new List<string>();
                if (command != "Enroll")
                    spellName = actions[2];

                switch (command)
                {
                    // Enroll {HeroName}
                    case "Enroll":
                        if (!heroes.ContainsKey(heroName))
                            heroes.Add(heroName, spells);
                        else
                            Console.WriteLine($"{heroName} is already enrolled.");
                        break;
                    // Learn {HeroName} {SpellName}
                    case "Learn":
                    // Unlearn {HeroName} {SpellName}
                    case "Unlearn":
                        if (!heroes.ContainsKey(heroName))
                            Console.WriteLine($"{heroName} doesn't exist.");
                        else
                        {
                            switch (command)
                            {
                                case "Learn":
                                    if (heroes[heroName].Contains(spellName))
                                        Console.WriteLine($"{heroName} has already learnt {spellName}.");
                                    else
                                        heroes[heroName].Add(spellName);
                                    break;
                                case "Unlearn":
                                    if (heroes[heroName].Contains(spellName))
                                        heroes[heroName].Remove(spellName);
                                    else
                                        Console.WriteLine($"{heroName} doesn't know {spellName}.");
                                    break;
                            }
                        }
                        break;
                }
            }

            Console.WriteLine("Heroes:");
            Console.WriteLine(string.Join(Environment.NewLine, heroes.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .Select(x => $"== {x.Key}: {string.Join(", ", x.Value)}")));
        }
    }
}
