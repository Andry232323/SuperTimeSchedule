using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using SuperTimeSchedule.Data;

namespace SuperTimeSchedule
{
    internal static class Program
    {
        public const string APP_NAME = "SuperTimeSchedule";

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                if(GoogleAuth.ConnectGoogleAsync().Result)
                {
                    Application.Run(new MainForm());
                } else
                {
                    MessageBox.Show("Erreur lors du démarrage de l'application");
                    Environment.Exit(0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur lors du démarage de l'application : " + e.Message);
                Environment.Exit(0);
            }

        }
    }
}