using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Analyzing_logs
{
    public class LogParser
    {
        public List<(string EventName, int Time)> ParseLogFile(string filePath)
        {
            var lines = ReadLogFile(filePath);
            var events = new List<(string EventName, int Time)>();

            var regex = new Regex(@"\[Performance\]\s(?<EventName>\w+)\s.+?(?<Time>\d+)\sms");

            foreach (var line in lines)
            {
                var match = regex.Match(line);
                if (match.Success)
                {
                    var eventName = match.Groups["EventName"].Value;
                    var time = int.Parse(match.Groups["Time"].Value);

                    events.Add((eventName, time));
                }
            }

            return events;
        }

        private List<string> ReadLogFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
                throw new System.IO.FileNotFoundException($"Log file not found: {filePath}");

            return new List<string>(System.IO.File.ReadAllLines(filePath));
        }
    }
}
