using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;

namespace SuperTimeSchedule
{
    internal static class Program
    {
        public const string APP_NAME = "SuperTimeSchedule";

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            
            Application.Run(new MainForm());

        }
    }
}