using System;
using System.Threading;

public abstract class mindfulnessActivity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public mindfulnessActivity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {_name} Activity...");
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    public void EndActivity()
    {
        Console.WriteLine($"Great job completing the {_name} Activity!");
        Console.WriteLine("Remember that Heavenly Father and Jesus Christ love you deeply.");
        Console.WriteLine();
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void Spinner(int seconds)
    {
        string[] symbols = { "|", "/", "-", "\\" };
        int index = 0;

        DateTime end = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < end)
        {
            Console.Write(symbols[index]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            index = (index + 1) % symbols.Length;
        }
    }

    public abstract void Run(); // Each activity implements its own logic
}