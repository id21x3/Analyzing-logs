namespace Analyzing_logs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Analyzing logs - Application Started");

            var logParser = new LogParser();
            var testLogPath = "testlog.txt";

            // sample log file
            File.WriteAllLines(testLogPath, new[]
            {
                "[Event] Processing MoveBroiEvent",
                "[Performance] MoveBroiEvent with Tid 12 has been processed in 100 ms",
                "[Event] Processing MoveBroiEvent",
                "[Performance] MoveBroiEvent with Tid 13 has been processed in 200 ms",
                "[Event] Processing MoveCroiEvent",
                "[Performance] MoveCroiEvent with Tid 14 has been processed in 300 ms",
                "[Event] Processing MoveCroiEvent",
                "[Performance] MoveCroiEvent with Tid 15 has been processed in 100 ms"
            });



            // Parse
            try
            {
                var events = logParser.ParseLogFile(testLogPath);
                Console.WriteLine("Parsed events:");
                foreach (var (eventName, time) in events)
                {
                    Console.WriteLine($"Event: {eventName}, Time: {time} ms");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
