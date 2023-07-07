using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.Model
{
    internal class ClassEvent : ScheduledEvent
    {
        public string ClassDescription { get; set; }
        public string Subject { get; set; }
        public ClassEvent(string name, string description, DateTime date, string subject, string ClassDescription) : base(name, description, date)
        {
            this.ClassDescription = ClassDescription;
            this.Subject = subject;
        }
    }
}
