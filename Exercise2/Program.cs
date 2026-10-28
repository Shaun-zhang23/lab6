using System;

// Exercise 2: Output 0,1,2,3,4,5,6,7,8,9,10 using a while loop
namespace Lab6
{
    class Exercise2
    {
        static void Main(string[] args)
        {
            int i = 0;
            while (i <= 10)
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
                i++;
            }
            Console.WriteLine();
        }
    }
}
