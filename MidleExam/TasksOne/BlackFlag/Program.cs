using System;

namespace BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int piratingDay = int.Parse(Console.ReadLine());
            int piratesPlunderForDay = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double plumber = 0;
            for (int i = 1; i <= piratingDay; i++)
            {
                plumber += piratesPlunderForDay;

                if (i % 3 == 0)
                    plumber += piratesPlunderForDay * 0.5;
                if (i % 5 == 0)
                    plumber = plumber * 0.7;
            }

            if(plumber >= expectedPlunder)
                Console.WriteLine($"Ahoy! {plumber:f2} plunder gained.");
            else if (plumber < expectedPlunder)
                Console.WriteLine($"Collected only {plumber / expectedPlunder * 100:f2}% of the plunder.");
        }
    }
}
