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
        public EventInfoPanelModel EventInfoPanelModel;
        public MonthCalendar calendar;
        public Panel eventInfoPanel;
        public Panel calendarPanel;
        public Panel controlPanel;
        public List<CalendarEvent> CalendarEvents;
        
        public MainForm()
        {
            InitializeComponent();

            FormClosed += (s, e) =>
            {
                DataManager dataManager = new(CalendarEvents);
                dataManager.SaveData();
            };

            CalendarEvents = DataManager.LoadData();

            var topMenuStrip = new TopMenuStrip(this);
            var splitContainerVertical = new SplitContainer();
            var splitContainerHorizontal = new SplitContainer();
            
            calendar = new MonthCalendar
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Dock = DockStyle.Fill
            };
            
            
            calendarPanel = splitContainerHorizontal.Panel1;
            controlPanel = splitContainerVertical.Panel1 ;
            eventInfoPanel = splitContainerHorizontal.Panel2;

            EventInfoPanelModel = new EventInfoPanelModel();
            eventInfoPanel.Controls.Add(EventInfoPanelModel);
            controlPanel.Controls.Add(new ControlPanelModel(this));

            CalendarEventControler.DisplayCalendarEvent(CalendarEvents, calendar);

            var calendarEventControler = new CalendarEventControler(this);
            calendar.DateSelected += calendarEventControler.DisplayCalendarEventInfo;

            splitContainerVertical.Dock = DockStyle.Fill;
            splitContainerHorizontal.Dock = DockStyle.Fill;
            splitContainerVertical.Orientation = Orientation.Vertical;
            splitContainerHorizontal.Orientation = Orientation.Horizontal;
            splitContainerVertical.Panel2.Controls.Add(splitContainerHorizontal);

            calendarPanel.AutoSize = true;
            calendarPanel.Controls.Add(calendar);

            Controls.Add(splitContainerVertical);
            Controls.Add(topMenuStrip);
        }

        
    }
}