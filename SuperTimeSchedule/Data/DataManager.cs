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
        private static readonly string filePath = "C:\\Users\\Andry\\Desktop\\Lecon C#\\SuperTimeSchedule\\SuperTimeSchedule\\Data\\Data.json";
        private List<CalendarEvent> _events;
        public DataManager(List<CalendarEvent> events) 
        {
            _events = events;
        }    
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
    }
}
