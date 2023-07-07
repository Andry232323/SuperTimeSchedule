using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.View
{
    public class EventChoiceForm : Form
    {
        public EventChoiceForm() 
        {
            Text = Program.APP_NAME;
            StartPosition = FormStartPosition.CenterScreen;

            var eventTypeComboBox = new ComboBox();
            var finalizeChoice = new Button();

            eventTypeComboBox.Items.AddRange(new string[] { "ClassEvent", "Task", "SpanEvent" });
            finalizeChoice.Text = "Créer l'évènement";

            Controls.Add(finalizeChoice);
            Controls.Add(eventTypeComboBox);
        }
    }
}
