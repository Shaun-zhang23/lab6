using System;

// Exercise 1: Output 0,1,2,3,4,5,6,7,8,9,10 using a for loop
namespace Lab6
{
    class Exercise1
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 10; i++)
            {
                // No comma after the last number
                if (i < 10)
                {
                    Console.Write(i + ",");
                }
                else
                {
                    Console.Write(i);
                }
            }
            Console.WriteLine();
        }
    }
}
