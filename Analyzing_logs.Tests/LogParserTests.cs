using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Analyzing_logs.Tests
{
    [TestClass]
    public class LogParserTests
    {
        [TestMethod]
        public void ParseLogFile_ShouldExtractCorrectData()
        {
            string tempFilePath = Path.GetTempFileName();
            File.WriteAllLines(tempFilePath, new[]
            {
                "[Event] Processing MoveBroiEvent",
                "[Performance] MoveBroiEvent with Tid 12 has been processed in 100 ms",
                "[Performance] MoveCroiEvent with Tid 14 has been processed in 300 ms",
                "[Performance] MoveBroiEvent with Tid 13 has been processed in 200 ms"
            });

            var logParser = new LogParser();

            try
            {
                var events = logParser.ParseLogFile(tempFilePath);

                Assert.AreEqual(3, events.Count);
                Assert.AreEqual(("MoveBroiEvent", 100), events[0]);
                Assert.AreEqual(("MoveCroiEvent", 300), events[1]);
                Assert.AreEqual(("MoveBroiEvent", 200), events[2]);
            }
            finally
            {
                File.Delete(tempFilePath);
            }
        }

        [TestMethod]
        public void ParseLogFile_ShouldIgnoreWarnings()
        {
            string tempFilePath = Path.GetTempFileName();
            File.WriteAllLines(tempFilePath, new[]
            {
                "Warning: Event processing took longer than 1500 ms",
                "[Performance] MoveBroiEvent with Tid 12 has been processed in 100 ms"
            });

            var logParser = new LogParser();

            try
            {
                var events = logParser.ParseLogFile(tempFilePath);

                Assert.AreEqual(1, events.Count);
                Assert.AreEqual("MoveBroiEvent", events[0].EventName);
                Assert.AreEqual(100, events[0].Time);
            }
            finally
            {
                File.Delete(tempFilePath);
            }
        }

        [TestMethod]
        public void ParseLogFile_ShouldIgnoreTypeIdEntries()
        {
            string tempFilePath = Path.GetTempFileName();
            File.WriteAllLines(tempFilePath, new[]
            {
                "[Performance] MoveBroiEvent with TypeId 12 has been processed in 100 ms",
                "[Performance] MoveBroiEvent with Tid 12 has been processed in 200 ms"
            });

            var logParser = new LogParser();

            try
            {
                var events = logParser.ParseLogFile(tempFilePath);

                Assert.AreEqual(1, events.Count);
                Assert.AreEqual("MoveBroiEvent", events[0].EventName);
                Assert.AreEqual(200, events[0].Time);
            }
            finally
            {
                File.Delete(tempFilePath);
            }
        }

        [TestMethod]
        public void ParseLogFile_ShouldHandleZeroTimeEvent()
        {
            string tempFilePath = Path.GetTempFileName();
            File.WriteAllLines(tempFilePath, new[]
            {
                "[Performance] MoveBroiEvent with Tid 12 has been processed in 0 ms"
            });

            var logParser = new LogParser();

            try
            {
                var events = logParser.ParseLogFile(tempFilePath);

                Assert.AreEqual(1, events.Count);
                Assert.AreEqual("MoveBroiEvent", events[0].EventName);
                Assert.AreEqual(0, events[0].Time);
            }
            finally
            {
                File.Delete(tempFilePath);
            }
        }
    }
}
