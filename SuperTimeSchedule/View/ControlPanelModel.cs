using SuperTimeSchedule.Controler;
using SuperTimeSchedule.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.View
{
    public class ControlPanelModel : FlowLayoutPanel
    {
        private BtnResponsive _addEventButton;
        private LblResponsive _deleteEventLbl;
        private MainForm _form;
        private TextBox _deleteTextBox;
        private BtnResponsive _deleteEventBtn;

        public ControlPanelModel(MainForm form) 
        {
            
            BackColor = Color.Beige;
            AutoSize = true;
            Dock = DockStyle.Fill;

            _deleteEventLbl = new("nom de l'évènement : ");
            _deleteTextBox = new();
            _deleteEventBtn = new("suprimer l'évènement");
            _form = form;
            _addEventButton = new BtnResponsive("Ajouter un évènement");

            _deleteEventBtn.Click += (s, e) =>
            {
                DataManager dataManager = new(_form.CalendarEvents);
                dataManager.DeleteOneCalendarEvent(_deleteTextBox.Text, _form);
                _deleteTextBox.Text = string.Empty;
            };

            _addEventButton.Click += (s, e) =>
            {
                EventChoiceForm ChoiceForm = new(_form);
                ChoiceForm.ShowDialog();
            };

            Controls.AddRange(new Control[] {_deleteEventLbl, _deleteTextBox, _deleteEventBtn, _addEventButton });
        }
    }
}
