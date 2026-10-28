using System;

// Exercise 3: Output 0,1,2,3,4,5,6,7,8,9,10 using a do-while loop
namespace Lab6
{
    class Exercise3
    {
        static void Main(string[] args)
        {
            int i = 0;
            do
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
            } while (i <= 10);
            Console.WriteLine();
        }
    }
}
