using SuperTimeSchedule.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.Controler
{
    public static class ButtonEventHandler
    {
        public static void Add_Event(Object sender, EventArgs e)
        {
            EventChoiceForm ChoiceForm = new EventChoiceForm();

            
            ChoiceForm.ShowDialog();
        }
    }
}
