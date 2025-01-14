using System;
using System.Collections.Generic;

namespace Analyzing_logs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Analyzing logs - Application Started");

            var logParser = new LogParser();
            var eventAggregator = new EventAggregator();
            var testLogPath = "testlog.txt";

            try
            {
                // Parse
                List<(string EventName, int Time)> events = logParser.ParseLogFile(testLogPath);

                // Aggregate statistics
                foreach (var (eventName, time) in events)
                {
                    eventAggregator.AddEvent(eventName, time);
                }

                DisplayStatistics(eventAggregator.GetStatistics());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Displays statistics in a formatted table.
        private static void DisplayStatistics(Dictionary<string, EventStats> statistics)
        {
            Console.WriteLine();
            Console.WriteLine("Event Statistics:");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("{0,-20} {1,-10} {2,-10} {3,-10} {4,-10}", "Event Name", "Min Time", "Max Time", "Avg Time", "Count");
            Console.WriteLine("-------------------------------------------------------------");

            foreach (var stat in statistics.Values)
            {
                Console.WriteLine("{0,-20} {1,-10} {2,-10} {3,-10:F2} {4,-10}",
                    stat.EventName, stat.MinTime, stat.MaxTime, stat.GetAverageTime(), stat.Count);
            }

            Console.WriteLine("-------------------------------------------------------------");
        }
    }
}
