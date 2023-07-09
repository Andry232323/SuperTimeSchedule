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
        private readonly MainForm _form;
        public ComboBox EventTypeComboBox;
        public TextBox NameTextBox;
        public RichTextBox DescrTextBox;
        public MonthCalendar calendar;

        public ButtonEventHandler(EventChoiceForm eventChoiceForm, MainForm form) 
        {
            this._form = form;
            this.calendar = _form.calendar;
            this.EventTypeComboBox = eventChoiceForm.EventTypeComboBox;
            this.NameTextBox = eventChoiceForm.NameTextBox;
            this.DescrTextBox = eventChoiceForm.DescrTextBox;
        }


        //TODO: faire le type de retour en Evenement du calendrier 
        public void Create_Event(Object sender, EventArgs e)
        {
#pragma warning disable CS8604 // Existence possible d'un argument de référence null.
            CalendarEvent calendarEvent = new(NameTextBox.Text, DescrTextBox.Text, EventTypeComboBox.SelectedItem.ToString(), calendar.SelectionStart, calendar.SelectionEnd);
#pragma warning restore CS8604 // Existence possible d'un argument de référence null.
            Form parent = ((Button)sender).FindForm();

            CalendarEventControler calendarEventControler = new(calendarEvent, _form);
            calendarEventControler.DisplayCalendarEvent();

            parent.Close();
        }
    }
}
