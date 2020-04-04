using System;
using System.ComponentModel.Design;
using System.Text;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string pattern = @"^[@][#]+([A-Z][A-Za-z0-9]+[A-Z])[@][#]+$";
            var regex = new Regex(pattern);

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine();
                var match = regex.Match(input);
                var barCode = match.Groups[1].ToString();
                var sb = new StringBuilder();
                var productGroup = "00";

                foreach (var item in barCode)
                {
                    if (char.IsDigit(item))
                        sb.Append(item);
                }

                if (sb.Length != 0)
                {
                    productGroup = new string(sb.ToString());
                }

                if (match.Success && barCode.Length >= 6)
                {
                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
