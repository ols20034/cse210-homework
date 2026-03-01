using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : mindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people you appreciate?",
        "What are your personal strengths?",
        "Where do you feel most calm?",
        "When have you felt the Holy Ghost?",
        "Who are some of your personal heroes?",
        "Who are people that you have helped this week?"
    };

    public ListingActivity(int duration)
        : base("Listing",
               "This activity will help you reflect on the good things in your life by listing as many blessings as you can. Remember that every good gift comes from God.",
               duration)
    {
    }

    public override void Run()
    {
        StartActivity();

        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("You may begin in...");
        Countdown(3);

        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("- ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items. Beautiful reflections!");
        EndActivity();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}