using SuperTimeSchedule.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.Controller
{
    public class TopMenuStrip : MenuStrip
    {
        private readonly MainForm _form;
        public TopMenuStrip(MainForm form) 
        {
            _form = form;  
            Dock = DockStyle.Top;
            PopulationMenuStrip();
        }

        public void PopulationMenuStrip()
        {
            ToolStripMenuItem Menu = new("Menu");
            
            ToolStripMenuItem DeleteAllEvents = new("Suprimer tous les évènements");
            ToolStripMenuItem Save = new("Sauver")
            {
                ShortcutKeys = Keys.Control | Keys.S
            };

            DeleteAllEvents.Click += (s, e) =>
            {
                DataManager dataManager = new(_form.CalendarEvents);
                dataManager.DeleteAllCalendarEvents(_form);
            };

            Save.Click += (s, e) => 
            {
                DataManager dataManager = new(_form.CalendarEvents);
                dataManager.SaveData();
            };

            Menu.DropDownItems.AddRange(new ToolStripItem[] {Save, DeleteAllEvents});
           Items.Add(Menu);
        }
    }
}
