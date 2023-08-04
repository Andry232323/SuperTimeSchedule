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
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="form">the main form that contains the TopMenuStrip</param>
        public TopMenuStrip(MainForm form) 
        {
            _form = form;  
            Dock = DockStyle.Top;
            InitMenuStrip();
        }

        /// <summary>
        /// Initialize the components of the TopMenuStrip
        /// </summary>
        public void InitMenuStrip()
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
