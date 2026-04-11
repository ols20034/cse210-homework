using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Load Goals");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    LoadGoals();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.Write("Enter the name of your goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a brief description of your goal: ");
        string desc = Console.ReadLine();

        Console.Write("What is your point value? ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("That is not a valid point value, please try again.");
            return;
        }

        Console.WriteLine("Choose your goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Cancel");
        string type = Console.ReadLine();

        Goal goal = null;

        if (type == "1")
        {
            goal = new SimpleGoal(name, desc, points);
        }
        else if (type == "2")
        {
            goal = new EternalGoal(name, desc, points);
        }
        else if (type == "3")
        {
            Console.Write("Enter the number of times to complete: ");
            if (!int.TryParse(Console.ReadLine(), out int targetCount))
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            Console.Write("Enter the bonus for completing the checklist: ");
            if (!int.TryParse(Console.ReadLine(), out int bonus))
            {
                Console.WriteLine("Invalid bonus.");
                return;
            }

            goal = new ChecklistGoal(name, desc, points, targetCount, bonus);
        }
        else if (type == "4")
        {
            Console.WriteLine("Goal creation cancelled.");
            return;
        }
        else
        {
            Console.WriteLine("Incorrect goal type, please try again.");
            return;
        }

        goals.Add(goal);
        Console.WriteLine("The " + goal.GetGoalType() + " goal \"" + goal.GetName() + "\" has been added.");
    }

    static void ListGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet, let's add some goals.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Goal g = goals[i];
            string status;

            if (g.IsComplete())
            {
                status = "[X]";
            }
            else
            {
                status = "[ ]";
            }

            if (g is ChecklistGoal)
            {
                ChecklistGoal checklist = (ChecklistGoal)g;
                Console.WriteLine((i + 1) + ". " + status + " " + g.GetGoalType() + " - " + g.GetName() + " (" + checklist.GetProgress() + "/" + checklist.GetTarget() + ")");
            }
            else
            {
                Console.WriteLine((i + 1) + ". " + status + " " + g.GetGoalType() + " - " + g.GetName());
            }
        }
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (Goal g in goals)
            {
                string line = g.GetGoalType() + "|" + g.GetName() + "|" + g.GetDescription() + "|" + g.GetPoints() + "|" + g.IsComplete();

                if (g is ChecklistGoal)
                {
                    ChecklistGoal checklist = (ChecklistGoal)g;
                    line += "|" + checklist.GetProgress() + "|" + checklist.GetTarget() + "|" + checklist.GetBonus();
                }

                writer.WriteLine(line);
            }
        }

        Console.WriteLine("Your goals have been saved.");
    }

    static void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("Sorry, no saved goals found.");
            return;
        }

        goals.Clear();

        foreach (string line in File.ReadAllLines("goals.txt"))
        {
            string[] parts = line.Split('|');
            string type   = parts[0];
            string name   = parts[1];
            string desc   = parts[2];
            int points    = int.Parse(parts[3]);
            bool complete = bool.Parse(parts[4]);

            Goal g = null;

            if (type == "Simple")
            {
                g = new SimpleGoal(name, desc, points);
            }
            else if (type == "Eternal")
            {
                g = new EternalGoal(name, desc, points);
            }
            else if (type == "Checklist")
            {
                int target = int.Parse(parts[6]);
                int bonus  = int.Parse(parts[7]);
                g = new ChecklistGoal(name, desc, points, target, bonus);
            }

            if (g != null)
            {
                if (g is ChecklistGoal)
                {
                    ChecklistGoal checklist = (ChecklistGoal)g;
                    int savedProgress = int.Parse(parts[5]);
                    while (checklist.GetProgress() < savedProgress)
                    {
                        checklist.RecordEvent();
                    }
                }
                else if (complete)
                {
                    g.RecordEvent();
                }

                goals.Add(g);
            }
        }

        Console.WriteLine("Your goals are loaded.");
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Enter goal number to record event: ");

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= goals.Count)
        {
            Goal g = goals[index - 1];
            int earned = g.RecordEvent();
            Console.WriteLine("Event recorded for \"" + g.GetName() + "\". You have earned " + earned + " points.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }
}