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

        public Label Namelabel = new();
        public Label Descrlabel = new();
        public Label StartDatelabel = new();
        public Label EndDateLabel = new();
        public Label EventTypelabel = new();

        public EventInfoPanelModel() 
        {
            AutoSize = true;
            Dock = DockStyle.Fill;
            BackColor = Color.White;
            ColumnCount = 2;
            RowCount = 3;
            BorderStyle = BorderStyle.Fixed3D;

            Namelabel.AutoSize = true;
            Descrlabel.AutoSize = true;
            StartDatelabel.AutoSize = true;
            EndDateLabel.AutoSize = true;
            EventTypelabel.AutoSize = true;

            Namelabel.Text = "Nom de l'évènement : ";
            Descrlabel.Text = "Description : ";
            StartDatelabel.Text = "Début : ";
            EndDateLabel.Text = "Fin : ";
            EventTypelabel.Text = "Type : ";


            Controls.Add(Namelabel, 0, 0);
            Controls.Add(Descrlabel, 0, 1);
            Controls.Add(EventTypelabel, 0, 2);
            Controls.Add(StartDatelabel, 1, 1);
            Controls.Add(EndDateLabel, 1, 2);
        }
    }
}
