using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.Model
{
    internal class ScheduledEvent
    {
        public DateTime date;
        public string description;
        public string name;
        
        public ScheduledEvent(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
        public ScheduledEvent(string name, string description, DateTime date) 
        { 
            this.name = name;
            this.description = description;
            this.date = date;
        }
    }
}
