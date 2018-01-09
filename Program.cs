using System;
namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input random number: ");
            var inputNumber = 0;
            var counter = 0;

            var random= new Random();
            int randomNumber = random.Next(1, 101);
            Console.WriteLine(randomNumber);
            do
            {
                inputNumber = int.Parse(Console.ReadLine());
                counter++;
                if (inputNumber > randomNumber)
                {
                    Console.WriteLine("Down");
                }

                else if (inputNumber < randomNumber)
                {
                    Console.WriteLine("Up");
                }

                if (inputNumber == randomNumber)
                {
                    Console.WriteLine("You win!");
                    Console.WriteLine("You win {0} tries!", counter);

                }
            }
            while (inputNumber != randomNumber);
        }
    }
}