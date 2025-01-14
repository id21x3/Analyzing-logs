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
            var logFilePath = "Acquisition.log";

            try
            {
                // Parse
                var events = logParser.ParseLogFile(logFilePath);

                // Aggregate
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

        private static void DisplayStatistics(Dictionary<string, EventStats> statistics)
        {
            Console.WriteLine();
            Console.WriteLine("Event Statistics:");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-40} {1,-10} {2,-10} {3,-15} {4,-10}", "Event Name", "Min Time", "Max Time", "Avg Time", "Count");
            Console.WriteLine("------------------------------------------------------------------------------------------");

            foreach (var stat in statistics.Values)
            {
                Console.WriteLine("{0,-40} {1,-10} {2,-10} {3,-15:F2} {4,-10}",
                    stat.EventName, stat.MinTime, stat.MaxTime, stat.GetAverageTime(), stat.Count);
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------");
        }
    }
}
