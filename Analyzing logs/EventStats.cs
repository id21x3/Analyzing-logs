using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzing_logs
{
    public class EventStats
    {
        public string EventName { get; set; }
        public int MinTime { get; private set; } = int.MaxValue;
        public int MaxTime { get; private set; } = int.MinValue;
        public int TotalTime { get; private set; } = 0;
        public int Count { get; private set; } = 0;

        public void AddTime(int time)
        {
            MinTime = Math.Min(MinTime, time);
            MaxTime = Math.Max(MaxTime, time);
            TotalTime += time;
            Count++;
        }

        public double GetAverageTime()
        {
            return Count == 0 ? 0 : (double)TotalTime / Count;
        }
    }
}
