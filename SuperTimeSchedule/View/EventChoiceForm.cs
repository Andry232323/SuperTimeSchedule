using SuperTimeSchedule.Controler;
using SuperTimeSchedule.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.View
{
    public class EventChoiceForm : Form
    {
        private readonly MainForm _form;
        private readonly MonthCalendar _calendar;
        
        public ComboBox EventTypeComboBox;
        public TextBox NameTextBox;
        public RichTextBox DescrTextBox;
        
        public EventChoiceForm(MainForm form) 
        {
            /// From Style
            Text = Program.APP_NAME;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MinimumSize = new Size(450, 450);
            StartPosition = FormStartPosition.CenterScreen;

            ///Parent
            _form = form;

            /*-------------------------------------------------------------------
             * ------------- Child Controls -------------------------------------
             * ----------------------------------------------------------------*/
            _calendar = form.Calendar;
            
            var addTypeButton = new BtnResponsive("Créer le nouveau type");
            var finalizeChoiceButton = new BtnResponsive("Créer l'évènement");

            var addTypeTextBox = new TextBox();
            NameTextBox = new TextBox();
            
            DescrTextBox = new RichTextBox();

            var addTypeLabel = new LblResponsive("Créer un nouveau type d'évènement");
            var dateInfoEndLabel = new LblResponsive("la date de fin est : ");
            var dateInfoStartLabel = new LblResponsive("la date de debut est : ");
            var comboBoxlabel = new LblResponsive("Type de l'évènement\\Tâche");
            var descrlabel = new LblResponsive("Description de l'évènement\\Tâche");
            var nameLabel = new LblResponsive("Nom de l'évènement\\Tâche");

            var flowPanel = new FlowLayoutPanel();
            
            EventTypeComboBox = new ComboBox();

            ///RichTextBox Style
            DescrTextBox.Size = new Size(250, 100);

            ///FLowPanel Style
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.FlowDirection = FlowDirection.TopDown;
            flowPanel.AutoScroll = true;

            ///Default ComboBox item selection
            EventTypeComboBox.Items.AddRange(new string[] { "Anniversaire" });
            EventTypeComboBox.SelectedIndex = 0;

            /*-------------------------------------------------------------------
             * ------------------------------------------------------------------
             * ----------------------------------------------------------------*/

            ///Create and select a new Type of CalendarEvent
            addTypeButton.Click += (s, e) => {
                string newType = addTypeTextBox.Text.Trim();
                if(!EventTypeComboBox.Items.Contains(newType))
                {
                    EventTypeComboBox.Items.Add(newType);
                    EventTypeComboBox.SelectedItem = newType;
                    addTypeTextBox.Text = "";
                }
            };

            ///Display a new created CalendarEvent
            finalizeChoiceButton.Click += (s, e) =>
            {
                CalendarEventControler.DisplayNewCalendarEvent(_calendar);
                CalendarEvent newEvent = new(NameTextBox.Text.Trim(), DescrTextBox.Text, EventTypeComboBox.SelectedItem.ToString().Trim(),_calendar.SelectionStart, _calendar.SelectionEnd);
                _form.CalendarEvents.Add(newEvent);
                Close();
            };
           
            flowPanel.Controls.AddRange(new Control[] {
                nameLabel, NameTextBox, descrlabel, 
                DescrTextBox, comboBoxlabel, EventTypeComboBox, 
                addTypeLabel, addTypeTextBox, addTypeButton, dateInfoStartLabel, 
                dateInfoEndLabel,finalizeChoiceButton});
            Controls.Add(flowPanel);
        }
    }
}
