using System;
using System.Threading;

public class BreathingActivity : mindfulnessActivity
{
    public BreathingActivity(int duration)
        : base("Breathing",
               "This activity will help you relax by guiding you through slow, deep breathing. Focus on the peace that comes from Christ as you breathe.",
               duration)
    {
    }

    public override void Run()
    {
        StartActivity();

        int cycleTime = 5;
        int cycles = _duration / (cycleTime * 2);

        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("Breathe in...");
            Countdown(cycleTime);

            Console.WriteLine("Breathe out...");
            Countdown(cycleTime);
        }

        EndActivity();
    }
}