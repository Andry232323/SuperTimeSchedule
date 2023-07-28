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

namespace SuperTimeSchedule.View
{
    public class ControlPanelModel : FlowLayoutPanel
    {

        private DriveService _driveService;
        private Auth _driveConnector;
        private UserCredential _userCredential;
        private string _accessToken;

        private BtnResponsive _saveOnDrivebtn;
        private BtnResponsive _disconnectGoogle;
        private BtnResponsive _connectGoogle;
        private BtnResponsive _addEventButton;
        private LblResponsive _deleteEventLbl;
        private BtnResponsive _deleteEventBtn;

        private MainForm _form;
        
        private TextBox _deleteTextBox;

        public ControlPanelModel(MainForm form) 
        {
            
            BackColor = Color.Beige;
            AutoSize = true;
            Dock = DockStyle.Fill;

            _driveConnector = new Auth();
            _userCredential = _driveConnector.GetUserCredentials();
            _driveService = _driveConnector.CreateDriveService(_userCredential);

            _saveOnDrivebtn = new("sauver dans le drive");
            _disconnectGoogle = new("Deconnecter l'utilisateur");
            _connectGoogle = new("connecter un compte google");
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

            _connectGoogle.Click += (s, e) =>
            {
                _driveConnector = new Auth();
                _userCredential = _driveConnector.GetUserCredentials();
                _driveService = _driveConnector.CreateDriveService(_userCredential);
            };

            _disconnectGoogle.Click += async (s, e) =>
            {
                _accessToken = _userCredential.Token.AccessToken;
                {
                    using (var client = new HttpClient())
                    {
                        var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("token", _accessToken) });

                        await client.PostAsync("https://accounts.google.com/o/oauth2/revoke", content);
                    }
                };
            };

            _saveOnDrivebtn.Click += (s, e) => 
            {
                string fileContent = File.ReadAllText("C:\\Users\\Andry\\Desktop\\Lecon C#\\SuperTimeSchedule\\SuperTimeSchedule\\Data\\Data.json");
                string fileName = "Data.json";
                DataManager dataManager = new(_driveService, _accessToken);
                dataManager.SaveGOnDrive(fileName, fileContent, _driveService);
            };

            Controls.AddRange(new Control[] {_deleteEventLbl, _deleteTextBox, _deleteEventBtn, _addEventButton, _connectGoogle, _disconnectGoogle, _saveOnDrivebtn });
        }
    }
}
