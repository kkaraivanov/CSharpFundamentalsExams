using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogicVII
{
    // maximum of 100 HP and 200 MP
    class Program
    {
        
        private static Dictionary<string, Hero> heros { get; set; }
        private const int maxHP = 100;
        private const int maxMP = 200;

        static void Main(string[] args)
        {
            heros = new Dictionary<string, Hero>();
            int countHero = int.Parse(Console.ReadLine());
            for (int i = 0; i < countHero; i++)
            {
                var hero = new Hero();
                var input = Console.ReadLine().Split();
                hero.Name = input[0];
                hero.HP = int.Parse(input[1]);
                hero.MP = int.Parse(input[2]);
                heros.Add(hero.Name,hero);
            }

            while (true)
            {
                var commands = Console.ReadLine()
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                
                if (commands.Contains("End"))
                {
                    break;
                }

                if (commands.Contains("CastSpell"))
                {
                    var name = commands[1];
                    var mpNeed = int.Parse(commands[2]);
                    var spell = commands[3];

                    if (CastSpell(name,mpNeed))
                    {
                        Console.WriteLine($"{name} has successfully cast {spell} and now has {heros[name].MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spell}!");
                    }
                }

                if (commands.Contains("TakeDamage"))
                {
                    var name = commands[1];
                    var damage = int.Parse(commands[2]);
                    var attacker = commands[3];

                    if (TakeDamage(name, damage))
                    {
                        Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heros[name].HP} HP left!");
                    }
                    else
                    {
                        heros.Remove(name);
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                    }
                }

                if (commands.Contains("Recharge"))
                {
                    var name = commands[1];
                    var amount = int.Parse(commands[2]);

                    Console.WriteLine($"{name} recharged for {Recharge(name, amount)} MP!");
                }

                if (commands.Contains("Heal"))
                {
                    var name = commands[1];
                    var amount = int.Parse(commands[2]);

                    Console.WriteLine($"{name} healed for {Heal(name, amount)} HP!");
                }
            }

            foreach (var hero in heros
                .OrderByDescending(x => x.Value.HP)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{hero.Key}{Environment.NewLine}" +
                                  $"HP: {hero.Value.HP}{Environment.NewLine}" +
                                  $"MP: {hero.Value.MP}");
            }
        }

        static int Heal(string name, int amount)
        {
            if (amount + heros[name].HP > maxHP)
            {
                var result = maxHP - heros[name].HP;
                heros[name].HP = maxHP;
                return result;
            }

            heros[name].HP += amount;
            return amount;
        }
        static int Recharge(string name, int amount)
        {
            if (amount + heros[name].MP > maxMP)
            {
                var result = maxMP - heros[name].MP;
                heros[name].MP = maxMP;
                return result;
            }
            
            heros[name].MP += amount;
            return amount;
        }
        static bool TakeDamage(string name, int damage)
        {
            var damageAmount = heros[name].HP - damage;
            if (damageAmount > 0)
            {
                heros[name].HP -= damage;
                return true;
            }

            return false;
        }
        static bool CastSpell(string name, int mp)
        {
            var need = heros[name].MP - mp;
            if (need >= 0)
            {
                heros[name].MP -= mp;
                return true;
            }

            return false;
        }
    }

    class Hero
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
    }
}
