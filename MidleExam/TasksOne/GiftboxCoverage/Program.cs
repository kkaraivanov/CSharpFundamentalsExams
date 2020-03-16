using System;

namespace GiftboxCoverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sizeOfSide = double.Parse(Console.ReadLine()); // дължина на страната на кутията
            int sheetsOfPaper = int.Parse(Console.ReadLine()); // брой листове хартия
            double singlePaperArea = double.Parse(Console.ReadLine()); // площ на един лист хартия
            
            double areaOfTheBox = (sizeOfSide * sizeOfSide) * 6; // площа на кутията
            double discount = (sheetsOfPaper / 3) * (singlePaperArea * 0.25);
            sheetsOfPaper -= (sheetsOfPaper / 3);
            double realAreaPaper = sheetsOfPaper * singlePaperArea + discount;
            double percent = realAreaPaper / areaOfTheBox * 100;

            Console.WriteLine($"You can cover {percent:f2}% of the box.");
        }
    }
}
