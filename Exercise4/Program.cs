using System;

// Exercise 4: Output all integers from 0 to 100 that are divisible by both 3 and 4
namespace Lab6
{
    class Exercise4
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 100; i++)
            {
                // Divisible by both 3 and 4 is equivalent to being divisible by 12
                if (i % 3 == 0 && i % 4 == 0)
                {
                    Console.Write(i);
                    if (i + 12 <= 100)
                    {
                        Console.Write(",");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
