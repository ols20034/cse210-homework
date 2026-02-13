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
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("\nJournal saved successfully!");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            _entries.Clear();
            foreach (var line in File.ReadLines(filename))
            {
                var parts = line.Split('|');
                if (parts.Length == 3)
                {
                    _entries.Add(new JournalEntry(parts[0], parts[1], parts[2]));
                }
            }
            Console.WriteLine("\nJournal loaded successfully!");
        }
    }
    public void EditEntry()
    {
      if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo entries to edit.");
            return;
        }

        Console.WriteLine("\nWhich entry would you like to edit?");
    
        // Display entries with numbers
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"{i + 1}. { _entries[i].Date } - { _entries[i].Prompt }");
        }

            Console.Write("\nEnter entry number: ");
            string input = Console.ReadLine();

        if (int.TryParse(input, out int entryNumber) &&
            entryNumber >= 1 &&
            entryNumber <= _entries.Count)
        {
            JournalEntry entry = _entries[entryNumber - 1];

            Console.WriteLine($"\nCurrent response:\n{entry.Response}");
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
