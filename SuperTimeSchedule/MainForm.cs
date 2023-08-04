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
        public EventInfoPanelModel EventInfoPanelModel { get; set; }
        public MonthCalendar Calendar { get; set; }
        public Panel EventInfoPanel { get; set; }
        public Panel CalendarPanel { get; set; }
        public Panel ControlPanel { get; set; }
        public List<CalendarEvent> CalendarEvents { get; set; }

        public MainForm()
        {
            InitializeComponent();

            //Handling App closing 
            FormClosed += (s, e) =>
            {
                DataManager dataManager = new(CalendarEvents);
                dataManager.SaveData();
            };

            CalendarEvents = DataManager.LoadData();

            //Main controls 
            var topMenuStrip = new TopMenuStrip(this);
            var splitContainerVertical = new SplitContainer();
            var splitContainerHorizontal = new SplitContainer();
            
            Calendar = new MonthCalendar
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Dock = DockStyle.Fill
            };
            
            CalendarPanel = splitContainerHorizontal.Panel1;
            ControlPanel = splitContainerVertical.Panel1 ;
            EventInfoPanel = splitContainerHorizontal.Panel2;

            EventInfoPanelModel = new EventInfoPanelModel();
            EventInfoPanel.Controls.Add(EventInfoPanelModel);
            ControlPanel.Controls.Add(new ControlPanelModel(this));

            CalendarEventControler.DisplayCalendarEvent(CalendarEvents, Calendar);

            var calendarEventControler = new CalendarEventControler(this);
            Calendar.DateSelected += calendarEventControler.DisplayCalendarEventInfo;

            //Split panle style
            splitContainerVertical.Dock = DockStyle.Fill;
            splitContainerHorizontal.Dock = DockStyle.Fill;
            splitContainerVertical.Orientation = Orientation.Vertical;
            splitContainerHorizontal.Orientation = Orientation.Horizontal;
            splitContainerVertical.Panel2.Controls.Add(splitContainerHorizontal);

            CalendarPanel.AutoSize = true;
            CalendarPanel.Controls.Add(Calendar);

            Controls.Add(splitContainerVertical);
            Controls.Add(topMenuStrip);
        }

        
    }
}