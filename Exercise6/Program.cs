using System;

// Exercise 6: Create a Car class
namespace Lab6
{
    class Car
    {
        // i) Data members: make, model, colour and registration number
        private string make;
        private string model;
        private string colour;
        private string registrationNumber;

        // i) User-defined constructor: takes a set of parameters to set each of the data members
        public Car(string make, string model, string colour, string registrationNumber)
        {
            this.make = make;
            this.model = model;
            this.colour = colour;
            this.registrationNumber = registrationNumber;
        }

        // ii) Read-only property: provides a get accessor only, so the registration
        //     number can be read from an object but not written to
        public string Registration
        {
            get { return registrationNumber; }
        }

        // iii) Make property: the value can be written only if it has some value (not empty)
        public string Make
        {
            get { return make; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    make = value;
                }
            }
        }

        // iv) Method that outputs the data about a car as a string
        public string GetCarInfo()
        {
            return "Make: " + make
                 + ", Model: " + model
                 + ", Colour: " + colour
                 + ", Registration: " + registrationNumber;
        }
    }

    class Exercise6
    {
        static void Main(string[] args)
        {
            // Create an object using the user-defined constructor
            Car car = new Car("Toyota", "Corolla", "White", "ABC-123");
            Console.WriteLine(car.GetCarInfo());

            // Demonstrate iii): a valid value is written to make successfully
            car.Make = "Honda";
            Console.WriteLine(car.GetCarInfo());

            // Demonstrate iii): an empty value is rejected, make stays Honda
            car.Make = "";
            Console.WriteLine(car.GetCarInfo());

            // Demonstrate ii): Registration is a read-only property, it can only be read
            Console.WriteLine("Registration = " + car.Registration);
            // car.Registration = "XYZ-999";   // Uncommenting this line causes a compile
            //                                    error because the property has no set accessor
        }
    }
}
