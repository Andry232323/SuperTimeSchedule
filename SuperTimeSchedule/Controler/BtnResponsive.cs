using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperTimeSchedule.Controler
{
    public class BtnResponsive : Button
    {
        /// <summary>
        /// A responsive button
        /// </summary>
        /// <param name="Content">The content of the button</param>
        public BtnResponsive(string Content) 
        {
            Text = Content;

            ///style
            AutoSize = true;
            Text = Content;
        }
    }
}
