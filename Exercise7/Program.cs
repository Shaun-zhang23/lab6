using System;

// Exercise 7: Input validation and exception handling - console calculator
namespace Lab6
{
    class Exercise7
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("===== Exercise 7: Input Validation and Exception Handling =====");
                Console.WriteLine("1. Prevention using if/else statements");
                Console.WriteLine("2. Exception handling using try/catch");
                Console.WriteLine("3. Exception handling using try/catch/finally");
                Console.WriteLine("4. Catch multiple types of exceptions");
                Console.WriteLine("0. Exit");
                Console.Write("Select a demo mode: ");

                string choice = Console.ReadLine();
                if (choice == "0")
                {
                    break;
                }

                switch (choice)
                {
                    case "1": Mode1_Prevention(); break;
                    case "2": Mode2_TryCatch(); break;
                    case "3": Mode3_TryCatchFinally(); break;
                    case "4": Mode4_MultipleCatches(); break;
                    default: Console.WriteLine("Invalid choice, please try again!"); break;
                }
            }
        }

        // Perform the calculation and output the result (shared by all four modes)
        static void Calculate(double a, char c, double b)
        {
            if (c == '+')
            {
                Console.WriteLine(a + " + " + b + " = " + (a + b));
            }
            else if (c == '-')
            {
                Console.WriteLine(a + " - " + b + " = " + (a - b));
            }
            else if (c == '*')
            {
                Console.WriteLine(a + " * " + b + " = " + a * b);
            }
            else if (c == '/')
            {
                Console.WriteLine(a + " / " + b + " = " + Math.Round(a / b, 2));
            }
        }

        // Mode 1: Prevention - intercept invalid input with if/else (combined with
        // TryParse) so that an exception never happens at all
        static void Mode1_Prevention()
        {
            Console.WriteLine("--- Mode 1: Prevention using if/else statements ---");
            double a, b;
            char c;

            // Prevent the first operand from not being a number
            while (true)
            {
                Console.Write("Enter the first operand: ");
                if (double.TryParse(Console.ReadLine(), out a))
                {
                    break;
                }
                Console.WriteLine("Please enter a number!");
            }

            // Prevent an invalid operator
            while (true)
            {
                Console.Write("Enter an operator (+ - * /): ");
                if (char.TryParse(Console.ReadLine(), out c) &&
                    (c == '+' || c == '-' || c == '*' || c == '/'))
                {
                    break;
                }
                Console.WriteLine("Please enter correct operator: + - * /");
            }

            // Prevent the second operand from not being a number, and division by zero
            while (true)
            {
                Console.Write("Enter the second operand: ");
                if (double.TryParse(Console.ReadLine(), out b))
                {
                    if (c == '/' && b == 0)
                    {
                        Console.WriteLine("The divisor cannot be 0!");
                        continue;
                    }
                    break;
                }
                Console.WriteLine("Please enter a number!");
            }

            Calculate(a, c, b);
        }

        // Mode 2: try/catch - use Parse directly, catch the exception and ask for input again
        static void Mode2_TryCatch()
        {
            Console.WriteLine("--- Mode 2: Exception handling using try/catch ---");
            while (true)
            {
                try
                {
                    Console.Write("Enter the first operand: ");
                    double a = double.Parse(Console.ReadLine());

                    Console.Write("Enter an operator (+ - * /): ");
                    char c = char.Parse(Console.ReadLine());
                    if (!(c == '+' || c == '-' || c == '*' || c == '/'))
                    {
                        Console.WriteLine("Please enter correct operator: + - * /");
                        continue;
                    }

                    Console.Write("Enter the second operand: ");
                    double b = double.Parse(Console.ReadLine());

                    Calculate(a, c, b);
                    break;   // All input is valid, leave this mode
                }
                catch (FormatException)
                {
                    // Catch the format exception caused by non-numeric input
                    Console.WriteLine("Invalid input format, please try again!");
                }
            }
        }

        // Mode 3: try/catch/finally - the finally block always runs whether or not an exception occurs
        static void Mode3_TryCatchFinally()
        {
            Console.WriteLine("--- Mode 3: Exception handling using try/catch/finally ---");
            while (true)
            {
                try
                {
                    Console.Write("Enter the first operand: ");
                    double a = double.Parse(Console.ReadLine());

                    Console.Write("Enter an operator (+ - * /): ");
                    char c = char.Parse(Console.ReadLine());
                    if (!(c == '+' || c == '-' || c == '*' || c == '/'))
                    {
                        Console.WriteLine("Please enter correct operator: + - * /");
                        continue;
                    }

                    Console.Write("Enter the second operand: ");
                    double b = double.Parse(Console.ReadLine());

                    Calculate(a, c, b);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format, please try again!");
                }
                finally
                {
                    // finally always runs: commonly used to release resources,
                    // demonstrated here with a message
                    Console.WriteLine("(finally block executed: this round of input is done)");
                }
            }
        }

        // Mode 4: Catch multiple types of exceptions
        // Note: dividing a double by zero does NOT throw an exception (the result is
        // infinity), so DivideByZeroException is thrown explicitly here to demonstrate
        // catching multiple exception types.
        static void Mode4_MultipleCatches()
        {
            Console.WriteLine("--- Mode 4: Catch multiple types of exceptions ---");
            try
            {
                Console.Write("Enter the first operand: ");
                double a = double.Parse(Console.ReadLine());

                Console.Write("Enter an operator (+ - * /): ");
                char c = char.Parse(Console.ReadLine());

                Console.Write("Enter the second operand: ");
                double b = double.Parse(Console.ReadLine());

                if (c == '/' && b == 0)
                {
                    throw new DivideByZeroException();   // Throw the exception explicitly
                }

                Calculate(a, c, b);
            }
            catch (FormatException fex)
            {
                Console.WriteLine("FormatException: " + fex.Message);
                Console.WriteLine("-> The input is not a valid number or operator!");
            }
            catch (DivideByZeroException dex)
            {
                Console.WriteLine("DivideByZeroException: " + dex.Message);
                Console.WriteLine("-> The divisor cannot be 0!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Other exception: " + ex.Message);
            }
        }
    }
}
