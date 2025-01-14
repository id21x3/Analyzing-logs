using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzing_logs
{
    // This class aggregates statistics for all events
    public class EventAggregator
    {
        private readonly Dictionary<string, EventStats> _events = new();

        public void AddEvent(string eventName, int time)
        {
            if (!_events.ContainsKey(eventName))
            {
                _events[eventName] = new EventStats { EventName = eventName };
            }
            _events[eventName].AddTime(time);
        }

        public Dictionary<string, EventStats> GetStatistics()
        {
            return _events;
        }
    }
}
