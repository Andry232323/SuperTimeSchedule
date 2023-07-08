using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.Controller
{
    public class TopMenuStrip : MenuStrip
    {
        public TopMenuStrip() 
        {
            Dock = DockStyle.Top;
            PopulationMenuStrip();
        }

        public void PopulationMenuStrip()
        {
           ToolStripMenuItem item1 = new("Menu 1");

           Items.Add(item1);
        }
    }
}
