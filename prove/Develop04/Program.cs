using System;

class Program
{
    static void Main(string[] args)
    {
        bool mindfulness = true;

        while (mindfulness)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            if (choice == "4")
            {
                mindfulness = false;
                Console.WriteLine("Thank you for practicing mindfulness. Remember Jesus loves you!");
                break;
            }

            Console.Write("Enter duration in seconds: ");
            if (!int.TryParse(Console.ReadLine(), out int duration) || duration <= 0)
            {
                Console.WriteLine("Please enter a valid positive number.");
                Thread.Sleep(500);
                continue;
            }

            mindfulnessActivity activity = choice switch
            {
                "1" => new BreathingActivity(duration),
                "2" => new ReflectionActivity(duration),
                "3" => new ListingActivity(duration),
                _ => null
            };

            if (activity != null)
            {
                Console.Clear();
                activity.Run();
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}