using SuperTimeSchedule.Controler;
using SuperTimeSchedule.Controller;
using SuperTimeSchedule.Data;
using SuperTimeSchedule.Model;
using SuperTimeSchedule.View;
using System.Globalization;

namespace SuperTimeSchedule
{
    public partial class MainForm : Form
    {
        public EventInfoPanelModel eventInfoPanelModel;
        public MonthCalendar calendar;
        public Panel EventInfoPanel;
        public Panel CalendarPanel;
        public Panel ControlPanel;
        public List<CalendarEvent> CalendarEvents;
        
        private DataManager _dataManager;
        public MainForm()
        {
            InitializeComponent();

            this.FormClosed += (s, e) =>
            {
                DataManager dataManager = new DataManager(CalendarEvents);
                dataManager.SaveData();
            };

            CalendarEvents = DataManager.LoadData();

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

            eventInfoPanelModel = new EventInfoPanelModel();
            EventInfoPanel.Controls.Add(eventInfoPanelModel);
            ControlPanel.BackColor = Color.Beige;


            addEventButton.Click += (s, e) => 
            {
                EventChoiceForm ChoiceForm = new(this);
                ChoiceForm.ShowDialog();
            };

            CalendarEventControler.DisplayCalendarEvent(CalendarEvents, calendar);

            var calendarEventControler = new CalendarEventControler(this);
            calendar.DateSelected += calendarEventControler.DisplayCalendarEventInfo;

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