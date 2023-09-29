using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(8, 30, 0);
            Time t2 = new Time(5, 45, 30);
            Time t3 = new Time(13, 55, 20);
            Time t4 = new Time(23, 8, 15);

            Console.WriteLine("Время 1:");
            t1.DisplayTime();
            Console.WriteLine("\nВремя 2:");
            t2.DisplayTime();
            Console.WriteLine("\nВремя 3:");
            t3.DisplayTime();
            Console.WriteLine("\nВремя 4:");
            t4.DisplayTime();

            Time T1 = t1 + t3;
            Time T2 = t4 - t2;
            Console.WriteLine("\nВремя T1 = 1 + 3:");
            T1.DisplayTime();
            Console.WriteLine("\nВремя T2 = 4 - 2:");
            T2.DisplayTime();

            Console.WriteLine($"\nРезультат сравнения T1 > T2 : {T1 > T2}");
            Console.WriteLine($"Результат сравнения T1 < T2 : {T1 < T2}");
        }
    }
}
