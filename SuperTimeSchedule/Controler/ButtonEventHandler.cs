using SuperTimeSchedule.Model;
using SuperTimeSchedule.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.Controler
{
    public  class ButtonEventHandler
    {
        public ComboBox EventTypeComboBox;
        public TextBox NameTextBox;
        public RichTextBox DescrTextBox;
        public MonthCalendar calendar;

        public ButtonEventHandler(EventChoiceForm eventChoiceForm, MonthCalendar calendar) 
        {
            this.calendar = calendar;
            this.EventTypeComboBox = eventChoiceForm.EventTypeComboBox;
            this.NameTextBox = eventChoiceForm.NameTextBox;
            this.DescrTextBox = eventChoiceForm.DescrTextBox;
        }


        //TODO: faire le type de retour en Evenement du calendrier 
        public void Create_Event(Object sender, EventArgs e)
        {
            CalendarEvent calendarEvent = new CalendarEvent(NameTextBox.Text, DescrTextBox.Text, EventTypeComboBox.SelectedItem.ToString(), calendar.SelectionStart, calendar.SelectionEnd);
            Form parent = ((Button)sender).FindForm();

            CalendarEventControler calendarEventControler = new(calendarEvent, calendar);
            calendarEventControler.DisplayCalendarEvent();

            parent.Close();
        }
    }
}
