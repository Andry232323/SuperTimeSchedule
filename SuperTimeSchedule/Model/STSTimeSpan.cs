using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.Model
{
    internal class STSTimeSpan : ScheduledEvent
    {
        DateTime EventStart;
        DateTime EventEnd;

        public STSTimeSpan(string name, string description, DateTime start, DateTime end) : base(name, description) 
        { 
            this.EventStart = start;
            this.EventEnd = end;
        }
    }
}
