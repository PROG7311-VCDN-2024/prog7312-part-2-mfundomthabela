using System;

namespace MetroConnectApp
{
    public class Issue
    {
        public int Id { get; }
        public string Description { get; }
        public DateTime ReportedDate { get; }

        public Issue(int id, string description, DateTime reportedDate)
        {
            Id = id;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            ReportedDate = reportedDate;
        }
    }
}
