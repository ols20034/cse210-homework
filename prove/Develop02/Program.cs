using System;

class Program
{
    static void Main()
    {   //____________________________________________________________________
        // Exceeds Requirements:
        // This program includes additional features beyond the core:
        // 1. Editing existing journal entries.
        // 2. Timestamp formatting for each entry.
        // 3. Random prompt generator class.
        // 4. Full file save/load functionality with formatting.
        // These enhancements go beyond the basic assignment requirements.
        //_____________________________________________________________________

        Journal myJournal = new Journal();
        JournalPrompt promptGenerator = new JournalPrompt();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nJournal Menu: Please choose an option");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save entries to a file");
            Console.WriteLine("4. Load entries from a file");
            Console.WriteLine("5. Edit an entry");
            Console.WriteLine("6. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    myJournal.AddEntry(prompt, response);
                    break;

                case "2":
                    myJournal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("\nEnter filename to save: ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("\nEnter filename to load: ");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadFromFile(loadFile);
                    break;

                case "5":
                    myJournal.EditEntry();
                    break;

                case "6":
                    isRunning = false;
                    Console.WriteLine("\nGoodbye!");
                    break;

                default:
                    Console.WriteLine("\nInvalid choice, please try again.");
                    break;
            }
        }
    }
}