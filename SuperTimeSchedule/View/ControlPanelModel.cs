using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using SuperTimeSchedule.Controler;
using SuperTimeSchedule.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;
using SuperTimeSchedule.Model;

namespace SuperTimeSchedule.View
{
    public class ControlPanelModel : FlowLayoutPanel
    {
        private readonly BtnResponsive _saveOnDrivebtn;
        private readonly BtnResponsive _disconnectGoogle;
        private readonly BtnResponsive _connectGoogle;
        private readonly BtnResponsive _addEventBtn;
        private readonly BtnResponsive _deleteEventBtn;

        private readonly LblResponsive _deleteEventLbl;
        private readonly LblResponsive _User_Name;

        private readonly MainForm _form;
        
        private readonly TextBox _deleteTextBox;

        public ControlPanelModel(MainForm form) 
        {
            BackColor = Color.Beige;
            AutoSize = true;
            Dock = DockStyle.Fill;

            _saveOnDrivebtn = new("sauver dans le drive");
            _disconnectGoogle = new("Deconnecter l'utilisateur");
            _connectGoogle = new("connecter un compte google");
            _deleteEventBtn = new("suprimer l'évènement");
            _addEventBtn = new BtnResponsive("Ajouter un évènement");

            _deleteEventLbl = new("nom de l'évènement : ");
            
            _deleteTextBox = new();
            
            _form = form;

            /*---------------------------------Event-Handling-------------------------------------------------*/
            _deleteEventBtn.Click += (s, e) =>
            {
                DataManager dataManager = new(_form.CalendarEvents);
                dataManager.DeleteOneCalendarEvent(_deleteTextBox.Text, _form);
                _deleteTextBox.Text = string.Empty;
            };

            _addEventBtn.Click += (s, e) =>
            {
                EventChoiceForm ChoiceForm = new(_form);
                ChoiceForm.ShowDialog();
            };

            _connectGoogle.Click += (s, e) => { GoogleAuth.ConnectGoogleAsync(); };

            _disconnectGoogle.Click += (s, e) => { GoogleAuth.DisconnectGoogleAsync(); };

            _saveOnDrivebtn.Click += (s, e) => { DataManager.SendToDrive(GoogleAuth.UserCredential); };
            /*---------------------------------------------------------------------------------------------------*/
           
            Controls.AddRange(new Control[] { _User_Name, _deleteEventLbl, _deleteTextBox, _deleteEventBtn, _addEventBtn, _connectGoogle, _disconnectGoogle, _saveOnDrivebtn });
        }
    }
}
