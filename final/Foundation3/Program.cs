using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Event> events = new List<Event>();

        // Create addresses
        Address addr1 = new Address("851 Main St", "New York", "NY", "USA");
        Address addr2 = new Address("720 Queen St", "Toronto", "ON", "Canada");
        Address addr3 = new Address("410 Beach Blvd", "San Diego", "CA", "USA");

        // Create events
        events.Add(new Lecture("Historic Association", "Life of William the Great, King of Britan", "August 20, 2025", "10:00 AM", addr1, "Dr. Ada Lovelace", 150));
        events.Add(new Reception("Olsen Family", "Wedding Celebration of Michelle Reed and Bendy Olsen", "Dec 1, 2025", "6:00 PM", addr2, "rsvp@gmail.com"));
        events.Add(new OutdoorGathering("Sunset Yoga", "Relaxing yoga session in the forest", "Oct 30, 2025", "5:30 PM", addr3, "Clear Minds Yoga"));

        // Display marketing messages
        foreach (var ev in events)
        {
            Console.WriteLine("=== Standard Details ===");
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine("\n=== Full Details ===");
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine("\n=== Short Description ===");
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine(new string('-', 50));
        }
    }
}