using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            DateTime range1 = DateTime.Now;
            DateTime range2 = DateTime.Now.AddDays(10);


            Console.WriteLine((range2 - range1).Days);
            Console.WriteLine();
            Console.WriteLine((range2 - range1).TotalDays);
            Console.WriteLine();
            Console.WriteLine(range1.Date);

        }
    }
}
