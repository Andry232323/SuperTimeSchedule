using SuperTimeSchedule.Controller;
using SuperTimeSchedule.View;

namespace SuperTimeSchedule
{
    public partial class MainForm : Form
    {
        public MonthCalendar calendar;
        public Panel EventInfoPanel;
        public Panel CalendarPanel;
        public Panel ControlPanel;
        public MainForm()
        {
            InitializeComponent();

            var topMenuStrip = new TopMenuStrip();
            var splitContainerVertical = new SplitContainer();
            var splitContainerHorizontal = new SplitContainer();
            var addEventButton = new Button();
            calendar = new MonthCalendar
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Dock = DockStyle.Fill
            };


            addEventButton.AutoSize = true;
            addEventButton.Anchor = AnchorStyles.Bottom;
            addEventButton.Text = "Ajouter un évènement";

            CalendarPanel = splitContainerHorizontal.Panel1;
            ControlPanel = splitContainerVertical.Panel1 ;
            EventInfoPanel = splitContainerHorizontal.Panel2;

            EventInfoPanel.Controls.Add(new EventInfoPanelModel());
            ControlPanel.BackColor = Color.Beige;


            addEventButton.Click += (s, e) => 
            {
                EventChoiceForm ChoiceForm = new(this);
                ChoiceForm.ShowDialog();
            };

            splitContainerVertical.Dock = DockStyle.Fill;
            splitContainerHorizontal.Dock = DockStyle.Fill;
            splitContainerVertical.Orientation = Orientation.Vertical;
            splitContainerHorizontal.Orientation = Orientation.Horizontal;
            splitContainerVertical.Panel2.Controls.Add(splitContainerHorizontal);

            ControlPanel.AutoSize = true;
            CalendarPanel.AutoSize = true;
            ControlPanel.Controls.Add(addEventButton);
            CalendarPanel.Controls.Add(calendar);
            
            Controls.Add(splitContainerVertical);
            Controls.Add(topMenuStrip);
        }
    }
}