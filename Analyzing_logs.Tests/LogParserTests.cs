using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzing_logs.Tests
{
    [TestClass]
    public class LogParserTests
    {
        private const string TestLogPath = "testlog.txt";

        [TestInitialize]
        public void Setup()
        {
            File.WriteAllLines(TestLogPath, new[]
            {
                "[Event] Processing MoveBroiEvent",
                "[Performance] MoveBroiEvent with Tid 12 has been processed in 100 ms",
                "[Performance] MoveCroiEvent with Tid 14 has been processed in 300 ms",
                "[Performance] MoveBroiEvent with Tid 13 has been processed in 200 ms"
            });
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(TestLogPath))
            {
                File.Delete(TestLogPath);
            }
        }

        [TestMethod]
        public void ParseLogFile_ShouldExtractCorrectData()
        {
            var logParser = new LogParser();
            var events = logParser.ParseLogFile(TestLogPath);

            Assert.AreEqual(3, events.Count);
            Assert.AreEqual(("MoveBroiEvent", 100), events[0]);
            Assert.AreEqual(("MoveCroiEvent", 300), events[1]);
            Assert.AreEqual(("MoveBroiEvent", 200), events[2]);
        }
    }
}

