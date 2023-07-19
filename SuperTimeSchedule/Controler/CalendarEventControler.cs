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

        /// <summary>
        /// Display peramantly the selected dates on the calendar
        /// </summary>
        /// <param name="calendar"></param>
        public static void DisplayNewCalendarEvent(MonthCalendar calendar)
        {
            List<DateTime> boldedDates = calendar.BoldedDates.ToList();
            for (DateTime date = calendar.SelectionStart; date <= calendar.SelectionEnd; date = date.AddDays(1))
            {
                boldedDates.Add(date);
            }
            calendar.BoldedDates = boldedDates.ToArray();

        }

        /// <summary>
        /// Display all the events on the calendar as bolded dates
        /// </summary>
        /// <param name="events"> List of CalendarEvent </param>
        /// <param name="calendar">MonthCalendar</param>
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

        /// <summary>
        /// Dislpays Name, Description, start DateTIme, end Date and Type of a CalendarEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DisplayCalendarEventInfo(Object sender, EventArgs e)
        {
            EventInfoPanelModel infoPanel = _form.EventInfoPanelModel;
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
                    infoPanel.EventTypelabel.Text = "Type : " + _calendarEvent.Type;
                    infoPanel.StartDatelabel.Text = "Début : " + _calendarEvent.Start.ToString();
                    infoPanel.EndDateLabel.Text = "Fin : " + _calendarEvent.End.ToString();
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
