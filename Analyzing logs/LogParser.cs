using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzing_logs
{
    // This class is responsible for reading log files and extracting event data.
    public class LogParser
    {
        public List<string> ReadLogFile(string filePath)
        {
            // Basic logic to read all lines from a file.
            // Returning a list of strings for further processing
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Log file not found: " + filePath);

            return new List<string>(File.ReadAllLines(filePath));
        }
    }
}
