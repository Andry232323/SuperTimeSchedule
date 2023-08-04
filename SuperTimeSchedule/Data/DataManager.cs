using SuperTimeSchedule.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;

namespace SuperTimeSchedule.Data
{
    public class DataManager
    {
        /// <summary>
        /// Path of the Json file which stock the CalendarEvent's data
        /// </summary>
        private static readonly string filePath = "C:\\Users\\Andry\\Desktop\\Lecon C#\\SuperTimeSchedule\\SuperTimeSchedule\\Data\\Data.json";
        private readonly List<CalendarEvent> _events;
        private static FileList _fileList;
        public DataManager(List<CalendarEvent> events)
        {
            _events = events;
        }

        /// <summary>
        /// Load all the CalendarEvent
        /// </summary>
        /// <returns></returns>
        public static List<CalendarEvent> LoadData()
        {
            List<CalendarEvent> calendarEvents;
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    string json = System.IO.File.ReadAllText(filePath);
                    if (JsonConvert.DeserializeObject<List<CalendarEvent>>(json) == null)
                    {
                        calendarEvents = new List<CalendarEvent>();
                    }
                    else
                    {
                        calendarEvents = JsonConvert.DeserializeObject<List<CalendarEvent>>(json);
                    }
                }
                else
                {
                    calendarEvents = new List<CalendarEvent>();
                    System.IO.File.Create(filePath).Dispose();
                }
            }
            catch (Exception ex)
            {
                calendarEvents = new List<CalendarEvent>();
                MessageBox.Show(ex.Message);
            }
            return calendarEvents;
        }

        /// <summary>
        /// Save all the CalendarEvent on a Json file 
        /// </summary>
        public void SaveData()
        {
            if (_events == null)
            {
                MessageBox.Show("Aucun évènement à sauvegarder");
                return;
            }

            try
            {
                string jsonContent = JsonConvert.SerializeObject(_events);
                System.IO.File.WriteAllText(filePath, jsonContent);
                MessageBox.Show("Donnée sauvegarder");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la sauvegarde des donnée " + ex.Message);
            }
        }

        /// <summary>
        /// delete all the calendar events
        /// </summary>
        /// <param name="_from"></param>
        public void DeleteAllCalendarEvents(MainForm _from)
        {
            try
            {
                DialogResult result = MessageBox.Show("Etes vous sûr de suprimmer tous les évènements ? Cet action sera irréversible.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    System.IO.File.WriteAllText(filePath, "");
                    _from.CalendarEvents.Clear();
                    _from.calendar.BoldedDates = null;
                    _from.calendar.UpdateBoldedDates();
                    MessageBox.Show("Evenement suprimer !", "", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la supression des évènements " + ex);
            }
        }


        /// <summary>
        /// delete an event "name"
        /// </summary>
        /// <param name="name">name of the event to delete</param>
        /// <param name="form"></param>
        public void DeleteOneCalendarEvent(string name, MainForm form)
        {
            DialogResult result = MessageBox.Show("Etes vous sûr de vouloir suprimer l'évènement " + name + " cet action sera irreversible", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                foreach (CalendarEvent e in _events)
                {
                    if (e.Name == name.Trim())
                    {
                        _events.Remove(e);

                        //remove bolded date off the calendar
                        List<DateTime> boldeDates = form.calendar.BoldedDates.ToList();
                        List<DateTime> tmp = boldeDates.ToList();
                        foreach (var date in boldeDates)
                        {
                            if (date >= e.Start && date <= e.End)
                            {
                                tmp.Remove(date);
                            }
                        }
                        boldeDates = new List<DateTime>(tmp);
                        form.calendar.BoldedDates = boldeDates.ToArray();
                        form.calendar.UpdateBoldedDates();

                        //delete the event from the json file
                        SaveData();
                        return;
                    }
                }
                MessageBox.Show("L'évènement " + name + " n'a pas été trouvé");

            }

        }

        public static void SendToDrive(UserCredential credential)
        {
            string fileId = "";
            DriveService driveService = new(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "SuperCalendar"
            });

            FilesResource fileRessource = new(driveService);

            FilesResource.ListRequest listRequest = fileRessource.List();
            listRequest.Q = "trashed=false";
            _fileList = listRequest.Execute();

            bool fileExist = false;
            foreach (var file in _fileList.Files)
            {
                if(file.Name == "Data.json")
                {
                    fileExist = true;
                    fileId = file.Id;
                    break;
                }
            }
            
            var fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = System.IO.Path.GetFileName(filePath)
            };

            try
            {
                if (!fileExist)
                {
                    using var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open);
                    var request = driveService.Files.Create(fileMetadata, stream, "application/octet-stream");
                    request.Fields = "id";
                    request.Upload();
                }
                else
                {
                    driveService.Files.Delete(fileId).Execute();
                    using var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open);
                    var request = driveService.Files.Create(fileMetadata, stream, "application/octet-stream");
                    request.Fields = "id";
                    request.Upload();
                }

                MessageBox.Show("Sauvegarde vers google drive effectué avec succes !");
            } catch(Exception ex)
            {
                MessageBox.Show("Erreur lors de la sauvergarde vers google drive : " + ex.Message);
            }
        }
    }
}