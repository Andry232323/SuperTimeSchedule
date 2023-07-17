using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.Model
{
    public class CalendarEvent
    {
        private readonly string _DataPath = "C:\\Users\\Andry\\Desktop\\Lecon C#\\SuperTimeSchedule\\SuperTimeSchedule\\Data\\Data.json";
        public string Name;
        public string Descr;
        public string Type;
        public DateTime Start;
        public DateTime End;

        public CalendarEvent() 
        {   
            Name = "";
            Descr = "";
            Type = "";
        }

        public CalendarEvent(string name, string descr, string type, DateTime start, DateTime end) 
        {
            Name = name;
            Descr = descr;
            Type = type;
            Start = start;
            End = end;
        }
    }
}
