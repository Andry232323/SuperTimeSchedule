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
        /// <summary>
        /// A responsive label
        /// </summary>
        /// <param name="content">The label's content</param>
        public LblResponsive(string content) 
        {
            Text = content;

            ///Style
            AutoSize = true;
            
        }
    }
}
