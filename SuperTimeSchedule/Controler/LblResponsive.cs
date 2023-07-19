using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperTimeSchedule.Controler
{
    public class LblResponsive : Label
    {
        
        public LblResponsive(string text) 
        {
            Text = text;

            ///Style
            AutoSize = true;
            
        }
    }
}
