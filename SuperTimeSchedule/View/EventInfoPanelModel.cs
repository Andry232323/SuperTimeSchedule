using SuperTimeSchedule.Controler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SuperTimeSchedule.View
{
    public class EventInfoPanelModel : TableLayoutPanel
    {

        public LblResponsive Namelabel = new("Nom de l'évènement : ");
        public LblResponsive Descrlabel = new("Description : ");
        public LblResponsive StartDatelabel = new("Début : ");
        public LblResponsive EndDateLabel = new("Fin : ");
        public LblResponsive EventTypelabel = new("Type : ");

        public EventInfoPanelModel() 
        {
            ///Panel style
            AutoSize = true;
            Dock = DockStyle.Fill;
            BackColor = Color.White;
            ColumnCount = 2;
            RowCount = 3;
            BorderStyle = BorderStyle.Fixed3D;

            Controls.Add(Namelabel, 0, 0);
            Controls.Add(Descrlabel, 0, 1);
            Controls.Add(EventTypelabel, 0, 2);
            Controls.Add(StartDatelabel, 1, 1);
            Controls.Add(EndDateLabel, 1, 2);
        }
    }
}
