using SuperTimeSchedule.Controller;
using SuperTimeSchedule.View;

namespace SuperTimeSchedule
{
    public partial class MainForm : Form
    {
        public MonthCalendar calendar;
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

            var calendarPanel = splitContainerHorizontal.Panel1;
            var controlPanel = splitContainerVertical.Panel1 ;
            var viewPanel = splitContainerHorizontal.Panel2;

            controlPanel.BackColor = Color.Beige;
            viewPanel.BackColor = Color.Beige;

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

            controlPanel.AutoSize = true;
            calendarPanel.AutoSize = true;
            controlPanel.Controls.Add(addEventButton);
            calendarPanel.Controls.Add(calendar);
            
            Controls.Add(splitContainerVertical);
            Controls.Add(topMenuStrip);
        }
    }
}