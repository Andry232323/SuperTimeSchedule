using SuperTimeSchedule.Controler;
using SuperTimeSchedule.Controller;
using System.Windows.Forms;

namespace SuperTimeSchedule
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var topMenuStrip = new TopMenuStrip();
            var splitContainerVertical = new SplitContainer();
            var splitContainerHorizontal = new SplitContainer();
            var calendar = new MonthCalendar();
            var addEventButton = new Button();

            calendar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            calendar.Dock = DockStyle.Fill;

            addEventButton.AutoSize = true;
            addEventButton.Anchor = AnchorStyles.Bottom;
            addEventButton.Text = "Ajouter un évènement";

            var calendarPanel = splitContainerHorizontal.Panel1;
            var controlPanel = splitContainerVertical.Panel1 ;
            var viewPanel = splitContainerHorizontal.Panel2;

            controlPanel.BackColor = Color.Beige;
            viewPanel.BackColor = Color.Beige;

#pragma warning disable CS8622 // La nullabilité des types référence dans le type du paramètre ne correspond pas au délégué cible (probablement en raison des attributs de nullabilité).
            addEventButton.Click += ButtonEventHandler.Add_Event;
#pragma warning restore CS8622 // La nullabilité des types référence dans le type du paramètre ne correspond pas au délégué cible (probablement en raison des attributs de nullabilité).

            splitContainerVertical.Dock = DockStyle.Fill;
            splitContainerHorizontal.Dock = DockStyle.Fill;
            splitContainerVertical.Orientation = Orientation.Vertical;
            splitContainerHorizontal.Orientation = Orientation.Horizontal;
            splitContainerVertical.Panel2.Controls.Add(splitContainerHorizontal);
            
            controlPanel.Controls.Add(addEventButton);
            calendarPanel.Controls.Add(calendar);
            
            Controls.Add(splitContainerVertical);
            Controls.Add(topMenuStrip);
        }
    }
}