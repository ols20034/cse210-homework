using System;
using System.Collections.Generic;

public class JournalPrompt
{
    private List<string> _prompts = new List<string>
    {
        "What made you smile today?",
        "Describe a moment you felt proud.",
        "What was the biggest challenge you faced today?",
        "What is something you’re grateful for?",
        "Reflect on a decision you made today.",
        "Describe a moment that you helped someone.",
        "reflect on a memory that you have that made you feel loved.",
        "Describe a time when you made a mistake and was able to correct the mistake. How did it make you feel?"
    };

    public string GetPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}