using SuperTimeSchedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.Controler
{
    public class CalendarEventControler 
    {
        private CalendarEvent _calendarEvent;
        private MonthCalendar _calendar;
        public CalendarEventControler(CalendarEvent calendarEvent, MonthCalendar calendar) 
        {
            _calendar = calendar;
            _calendarEvent = calendarEvent;
        }

        public void DisplayCalendarEvent()
        {
            List<DateTime> boldedDates = new List<DateTime>();
            for(DateTime date = _calendar.SelectionStart; date <= _calendar.SelectionEnd; date = date.AddDays(1)) { boldedDates.Add(date); }
            _calendar.BoldedDates = boldedDates.ToArray();
        }
    }
}
