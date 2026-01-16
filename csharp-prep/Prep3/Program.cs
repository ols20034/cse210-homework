using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int number = random.Next(1, 101);

        int guess = 0;

        for (int guesses = 1; guess != number; guesses++)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < number)
            {
                Console.WriteLine("Guess a higher number");
            }
            else if (guess > number)
            {
                Console.WriteLine("Guess a lower number");
            }
            else
            {
                Console.WriteLine($"You guessed it in {guesses} guesses!");
            }
        }
    }
}
