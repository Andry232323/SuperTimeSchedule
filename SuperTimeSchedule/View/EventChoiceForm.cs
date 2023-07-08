using SuperTimeSchedule.Controler;
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
        private MonthCalendar _calendar;
        private TextBox addTypeTextBox;
        public ComboBox EventTypeComboBox;
        public TextBox NameTextBox;
        public RichTextBox DescrTextBox;
        public EventChoiceForm(MainForm form) 
        {
            this._form = form;
            this._calendar = form.calendar;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.MinimumSize = new Size(450, 450);

            Text = Program.APP_NAME;
            StartPosition = FormStartPosition.CenterScreen;
            var addTypeLabel = new Label();
            var addTypeButton = new Button();
            var addTypeTextBox = new TextBox();
            var dateInfoEndLabel = new Label();
            var dateInfoStartLabel = new Label();
            var comboBoxlabel = new Label();
            var descrlabel = new Label();
            var nameLabel = new Label();
            var finalizeChoice = new Button();
            var flowPanel = new FlowLayoutPanel();
            EventTypeComboBox = new ComboBox();
            NameTextBox = new TextBox();
            DescrTextBox = new RichTextBox();

            flowPanel.Dock = DockStyle.Fill;
            flowPanel.FlowDirection = FlowDirection.TopDown;
            flowPanel.AutoScroll = true;

            addTypeLabel.AutoSize = true;
            addTypeLabel.Text = "Créer un nouveau type d'évènement";
            addTypeButton.AutoSize = true;
            addTypeButton.Text = "Créer le nouveau type";
            dateInfoEndLabel.AutoSize = true;
            dateInfoEndLabel.Text = "- la date de fin est : " + _calendar.SelectionStart.ToString();
            dateInfoStartLabel.AutoSize = true;
            dateInfoStartLabel.Text = "- la date de debut est : " + _calendar.SelectionEnd.ToString();
            comboBoxlabel.Text = "Type de l'évènement\\Tâche";
            comboBoxlabel.AutoSize =  true;
            descrlabel.Text = "Description de l'évènement\\Tâche";
            descrlabel .AutoSize = true;    
            nameLabel.Text = "Nom de l'évènement\\Tâche";
            nameLabel .AutoSize = true;

            addTypeButton.Click += (s, e) => {
                string newType = addTypeTextBox.Text;
                if(!EventTypeComboBox.Items.Contains(newType))
                {
                    EventTypeComboBox.Items.Add(newType);
                    EventTypeComboBox.SelectedItem = newType;
                    addTypeTextBox.Text = "";
                }
                //TODO: Enregistrer le nouveau type creer
            };

            EventTypeComboBox.Items.AddRange(new string[] { "Anniversaire" });

            DescrTextBox.Size = new Size(250, 100);

            ButtonEventHandler btnEvtHandler = new(this, _calendar);
            finalizeChoice.Text = "Créer l'évènement";
            finalizeChoice.AutoSize = true;
            finalizeChoice.Click += btnEvtHandler.Create_Event;

            flowPanel.Controls.AddRange(new Control[] {
                nameLabel, NameTextBox, descrlabel, 
                DescrTextBox, comboBoxlabel, EventTypeComboBox, 
                addTypeLabel, addTypeTextBox, addTypeButton, dateInfoStartLabel, 
                dateInfoEndLabel,finalizeChoice});
            Controls.Add(flowPanel);
        }
    }
}
