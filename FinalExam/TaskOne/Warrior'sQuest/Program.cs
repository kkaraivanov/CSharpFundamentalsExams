namespace Warrior_sQuest
{
    using System;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();
            string commands = null;
            var sb = new StringBuilder(skill);

            while ((commands = Console.ReadLine()) != "For Azeroth")
            {
                var actions = commands.Split(" ", 2);
                int index = 0;

                switch (actions[0])
                {
                    // GladiatorStance
                    case "GladiatorStance":
                        sb.Replace(sb.ToString(), sb.ToString().ToUpper());
                        Console.WriteLine(sb.ToString());
                        break;
                    // DefensiveStance
                    case "DefensiveStance":
                        sb.Replace(sb.ToString(), sb.ToString().ToLower());
                        Console.WriteLine(sb.ToString());
                        break;
                    // Dispel {index} {letter}
                    case "Dispel":
                        int.TryParse(actions[1].Split()[0], out index);
                        var letter = char.Parse(actions[1].Split()[1]);
                        
                        if(index >= 0 && index <= sb.Length - 1)
                        {
                            sb.Remove(index, 1).Insert(index, letter);
                            Console.WriteLine("Success!");
                        }
                        else
                            Console.WriteLine("Dispel too weak.");
                        break;
                    // Target Change {substring} {second substring}
                    // Target Remove {substring}
                    case "Target":
                        string sub = actions[1].Split()[1];
                        switch (actions[1].Split()[0])
                        {
                            case "Change":
                                string seccond = actions[1].Split()[2];
                                sb.Replace(sub, seccond);
                                Console.WriteLine(sb.ToString());
                                break;
                            case "Remove":
                                index = sb.ToString().IndexOf(sub);
                                for (int i = 0; i < sub.Length; i++)
                                    sb.Remove(index, 1);
                                Console.WriteLine(sb.ToString());
                                ;
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Command doesn't exist!");
                        break;
                }
            }
        }
    }
}
