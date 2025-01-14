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

                // Aggregate statistics.
                foreach (var (eventName, time) in events)
                {
                    eventAggregator.AddEvent(eventName, time);
                }

                Console.WriteLine("Event Statistics:");
                Console.WriteLine("Event Name\tMin Time\tMax Time\tAvg Time\tCount");
                foreach (var (eventName, stats) in eventAggregator.GetStatistics())
                {
                    Console.WriteLine($"{stats.EventName}\t{stats.MinTime}\t\t{stats.MaxTime}\t\t{stats.GetAverageTime():F2}\t\t{stats.Count}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
