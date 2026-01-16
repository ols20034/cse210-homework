using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the list
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Input loop
        while (true)
        {
            Console.Write("Enter number: ");
            int value = int.Parse(Console.ReadLine());

            if (value == 0)
            {
                break; // stop when user enters 0
            }

            numbers.Add(value); // append to list
        }

        // Compute the sum
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        // Compute the average
        double average = (double)sum / numbers.Count;

        // Find the largest number
        int max = numbers[0];
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }

        // Output results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}