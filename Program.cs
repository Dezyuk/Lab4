using System;


namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(15,48,34);
            Time t2 = new Time(5, 55);
            Time t3 = new Time(hours:3, seconds:16);
            Time t4 = new Time(minutes:54);

            Console.WriteLine("Время 1:" + t1.DisplayTime());
            Console.WriteLine("\nВремя 2:" + t2.DisplayTime());
            Console.WriteLine("\nВремя 3:" + t3.DisplayTime());
            Console.WriteLine("\nВремя 4:" + t4.DisplayTime());

            Time T1 = t1 + t3;
            Time T2 = t4 - t2;
            Console.WriteLine("\nВремя T1 = t1 + t3:" + T1.DisplayTime());
            Console.WriteLine("\nВремя T2 = t4 - t2:" + T2.DisplayTime());
            

            Console.WriteLine($"\nРезультат сравнения T1 > T2 : {T1 > T2}");
            Console.WriteLine($"Результат сравнения T1 < T2 : {T1 < T2}");

            Console.WriteLine("\n---------------------------------------------------------------------------\n");
            Console.WriteLine("Попытка задать переменной класса время недопустимые значения:\n");
            Time t5 = new Time(hours:24);
        }
    }
}
