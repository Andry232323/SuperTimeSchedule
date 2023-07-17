using SuperTimeSchedule.Model;
using SuperTimeSchedule.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.Controler
{
    public class CalendarEventControler 
    {
        private CalendarEvent _calendarEvent;
        private readonly MonthCalendar _calendar;
        private readonly MainForm _form;

        public CalendarEventControler(MainForm form)
        {
            _calendarEvent = new CalendarEvent();
            _form = form;
            _calendar = form.calendar;
        }

        public CalendarEventControler(CalendarEvent calendarEvent, MainForm form) 
        {
            _form = form;
            _calendar = form.calendar;
            _calendarEvent = calendarEvent;
        }

        public void DisplayCalendarEvent()
        {
            for(DateTime date = _calendar.SelectionStart; date <= _calendar.SelectionEnd; date = date.AddDays(1)) { _calendar.AddBoldedDate(date); }
            _calendar.UpdateBoldedDates(); 
        }

        public static void DisplayCalendarEvent(List<CalendarEvent> events, MonthCalendar calendar)
        {
            foreach(CalendarEvent calendarEvent in events)
            {
                for(DateTime date = calendarEvent.Start; date <= calendarEvent.End; date = date.AddDays(1))
                {
                    calendar.AddBoldedDate(date);
                }
            }
            
            calendar.UpdateBoldedDates();
        }

        public void DisplayCalendarEventInfo(Object sender, EventArgs e)
        {
            EventInfoPanelModel infoPanel = _form.eventInfoPanelModel;
            List<CalendarEvent> calendarEvents = _form.CalendarEvents;
            DateTime selectedStartDate = _calendar.SelectionStart;

            bool findEvent = false;

            foreach (var calendarEvent in calendarEvents)
            {
                if (calendarEvent.Start <= selectedStartDate && calendarEvent.End >= selectedStartDate)
                {
                    _calendarEvent = calendarEvent;
                    infoPanel.Namelabel.Text = "Nom de l'évènement : " + _calendarEvent.Name;
                    infoPanel.Descrlabel.Text = "Description : " + _calendarEvent.Descr;
                    infoPanel.EventTypelabel.Text = "Début : " + _calendarEvent.Type;
                    infoPanel.StartDatelabel.Text = "Fin : " + _calendarEvent.Start.ToString();
                    infoPanel.EndDateLabel.Text = "Type : " + _calendarEvent.End.ToString();
                    findEvent = true;
                    break;
                }
            }

            if(!findEvent)
            {
                infoPanel.Namelabel.Text = "Nom de l'évènement : ";
                infoPanel.Descrlabel.Text = "Description : ";
                infoPanel.EventTypelabel.Text = "Début : ";
                infoPanel.StartDatelabel.Text = "Fin : ";
                infoPanel.EndDateLabel.Text = "Type : ";

            }
        }
    }
}
