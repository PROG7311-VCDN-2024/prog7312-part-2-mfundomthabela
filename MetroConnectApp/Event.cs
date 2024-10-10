using System;

namespace MetroConnectApp
{
    // Event class to store event details
    public class Event
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Event(string name, string category, DateTime date, string title, string description)
        {
            Name = name;
            Category = category;
            Date = date;
            Title = title;
            Description = description;
        }
    }
}
