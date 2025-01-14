using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzing_logs
{
    public class EventAggregator
    {
        private readonly Dictionary<string, EventStats> _events = [];

        public void AddEvent(string eventName, int time)
        {
            if (!_events.TryGetValue(eventName, out EventStats? value))
            {
                value = new EventStats { EventName = eventName };
                _events[eventName] = value;
            }

            value.AddTime(time);
        }

        public Dictionary<string, EventStats> GetStatistics()
        {
            return _events;
        }
    }
}