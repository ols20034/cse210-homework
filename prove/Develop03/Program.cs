using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Load scriptures from file
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in file.");
            return;
        }

        // Pick a random scripture
        Random rand = new Random();
        int randomIndex = rand.Next(scriptures.Count);
        Scripture scripture = scriptures[randomIndex];

        // Main loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture);

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program ending.");
                break;
            }

            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();
            input = input.Trim().ToLower();

            if (input == "quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            scripture.HideRandomWords(3);
        }
    }

    static List<Scripture> LoadScripturesFromFile(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found: " + filename);
            return scriptures;
        }

        string[] lines = File.ReadAllLines(filename);

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split('|');

            if (parts.Length != 2)
            {
                continue;
            }

            string referenceText = parts[0].Trim();
            string scriptureText = parts[1].Trim();

            try
            {
                ScriptureReference reference = new ScriptureReference(referenceText);
                Scripture scripture = new Scripture(reference, scriptureText);
                scriptures.Add(scripture);
            }
            catch
            {
                Console.WriteLine("Invalid scripture format: " + line);
            }
        }

        return scriptures;
    }
}