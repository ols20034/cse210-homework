using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<JournalEntry> _entries = new List<JournalEntry>();

    public void AddEntry(string prompt, string response)
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        _entries.Add(new JournalEntry(date, prompt, response));
    }

    public void DisplayEntries()
    {
        Console.WriteLine("\nJournal Entries:");
        foreach (JournalEntry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in _entries)
            {
                writer.WriteLine($"{entry.GetDate()}|{entry.GetPrompt()}|{entry.GetResponse()}");
            }
        }

        Console.WriteLine("\nJournal saved successfully!");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("\nFile not found.");
            return;
        }

        _entries.Clear();

        foreach (string line in File.ReadLines(filename))
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                _entries.Add(new JournalEntry(parts[0], parts[1], parts[2]));
            }
        }

        Console.WriteLine("\nJournal loaded successfully!");
    }

    public void EditEntry()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo entries to edit.");
            return;
        }

        Console.WriteLine("\nWhich entry would you like to edit?");

        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_entries[i].GetDate()} - {_entries[i].GetPrompt()}");
        }

        Console.Write("\nEnter entry number: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int entryNumber) &&
            entryNumber >= 1 &&
            entryNumber <= _entries.Count)
        {
            JournalEntry entry = _entries[entryNumber - 1];

            Console.WriteLine($"\nCurrent response:\n{entry.GetResponse()}");
            Console.Write("\nEnter your new response: ");
            string newResponse = Console.ReadLine();

            entry.UpdateResponse(newResponse);

            Console.WriteLine("\nEntry updated successfully!");
        }
        else
        {
            Console.WriteLine("\nInvalid entry number.");
        }
    }
}