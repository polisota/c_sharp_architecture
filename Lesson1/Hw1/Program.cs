using System;
using System.Diagnostics;

namespace Hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Здравствуйте!
Вас приветствует математическая программа
Пожалуйста введите число:");            

            String S = Console.ReadLine();

            if (S == "q" || S == "Q")
            {
                Process.GetCurrentProcess().Kill();
            }
            else
            {                               
                bool success = Int64.TryParse(S, out long N);
                if (success)
                {
                    Console.WriteLine("Факториал равен " + Factorial(N));
                    Console.WriteLine("Сумма от 1 до N равна " + SumFromOne(N));
                    Console.WriteLine("Максимальное четное число меньше N равно " + MaxOdd(N));
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Введите корректное число.");
                    Console.ReadLine();
                }                
            }
        }

        static long Factorial(long n)
        {
            return (n == 0) ? 1 : n * Factorial(n - 1);
        }

        static long SumFromOne(long n)
        {            
            return (n * (n + 1))/2;
        }

        static long MaxOdd(long n)
        {
            return Odd(n) ? n - 2 : n - 1;
        }

        static bool Odd(long n)
        {
            return n % 2 == 0;
        }

    }
}
