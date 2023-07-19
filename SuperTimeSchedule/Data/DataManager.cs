using SuperTimeSchedule.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.Data
{
    public class DataManager
    {
        /// <summary>
        /// Path of the Json file which stock the CalendarEvent's data
        /// </summary>
        private static readonly string filePath = "C:\\Users\\Andry\\Desktop\\Lecon C#\\SuperTimeSchedule\\SuperTimeSchedule\\Data\\Data.json";
        private readonly List<CalendarEvent> _events;
        public DataManager(List<CalendarEvent> events) 
        {
            _events = events;
        }    

        /// <summary>
        /// Load all the CalendarEvent
        /// </summary>
        /// <returns></returns>
        public static List<CalendarEvent>  LoadData()
        {
            List<CalendarEvent> calendarEvents;
            try
            {
                if (File.Exists(filePath)) {
                    string json = File.ReadAllText(filePath);
                    if(JsonConvert.DeserializeObject<List<CalendarEvent>>(json) == null)
                    {
                        calendarEvents = new List<CalendarEvent>();
                    } else
                    {
                        calendarEvents = JsonConvert.DeserializeObject<List<CalendarEvent>>(json);
                    }
                } else
                {
                    calendarEvents = new List<CalendarEvent>();
                    File.Create(filePath).Dispose();
                }
            } catch (Exception ex)
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
            if(_events == null)
            {
                MessageBox.Show("Aucun évènement à sauvegarder");
                return;
            }

            try
            {
                string jsonContent = JsonConvert.SerializeObject(_events);
                File.WriteAllText(filePath, jsonContent);
                MessageBox.Show("Donnée sauvegarder");
            } catch (Exception ex) 
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
                if(result == DialogResult.Yes) 
                { 
                    File.WriteAllText(filePath, "");
                    _from.CalendarEvents.Clear();
                    _from.calendar.BoldedDates = null;
                    _from.calendar.UpdateBoldedDates();
                    MessageBox.Show("Evenement suprimer !", "",MessageBoxButtons.OK);
                }
            } catch (Exception ex)
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
                        List<DateTime> tmp =boldeDates.ToList();
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
    }
}
