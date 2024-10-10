using System.Collections.Generic;
using System.Linq;

namespace MetroConnectApp
{
    public static class IssueRepository
    {
        private static readonly List<Issue> reportedIssues = new List<Issue>();

        public static List<Issue> GetReportedIssues()
        {
            return reportedIssues.ToList(); // Return a copy to avoid modification
        }

        public static void AddIssue(Issue issue)
        {
            reportedIssues.Add(issue);
        }
    }
}
