using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzing_logs.Tests
{
    [TestClass]
    public class EventAggregatorTests
    {
        [TestMethod]
        public void AddEvent_ShouldAggregateCorrectly()
        {
            var aggregator = new EventAggregator();

            aggregator.AddEvent("MoveBroiEvent", 100);
            aggregator.AddEvent("MoveBroiEvent", 200);
            aggregator.AddEvent("MoveCroiEvent", 300);

            var statistics = aggregator.GetStatistics();

            Assert.AreEqual(2, statistics["MoveBroiEvent"].Count);
            Assert.AreEqual(100, statistics["MoveBroiEvent"].MinTime);
            Assert.AreEqual(200, statistics["MoveBroiEvent"].MaxTime);
            Assert.AreEqual(150, statistics["MoveBroiEvent"].GetAverageTime());

            Assert.AreEqual(1, statistics["MoveCroiEvent"].Count);
            Assert.AreEqual(300, statistics["MoveCroiEvent"].MinTime);
            Assert.AreEqual(300, statistics["MoveCroiEvent"].MaxTime);
            Assert.AreEqual(300, statistics["MoveCroiEvent"].GetAverageTime());
        }
    }
}

