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
        private readonly CalendarEvent _calendarEvent;
        private readonly MonthCalendar _calendar;
        private readonly MainForm _from;
        public CalendarEventControler(CalendarEvent calendarEvent, MainForm form) 
        {
            _from = form;
            _calendar = form.calendar;
            _calendarEvent = calendarEvent;
        }

        public void DisplayCalendarEvent()
        {
            for(DateTime date = _calendar.SelectionStart; date <= _calendar.SelectionEnd; date = date.AddDays(1)) { _calendar.AddBoldedDate(date); }
            _calendar.UpdateBoldedDates(); 
        }

        public void DisplayCalendarEventInfo(Object sender, EventArgs e)
        {
            Panel infoPanel = _from.EventInfoPanel;
        }
    }
}
