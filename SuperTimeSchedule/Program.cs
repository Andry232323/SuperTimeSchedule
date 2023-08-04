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
                bool isConnected = GoogleAuth.ConnectGoogle();
                if(!isConnected) 
                {
                    DialogResult res = MessageBox.Show("Erreur lors de la connection avec Google, Voulez-vous restez en mode hors ligne ou quitter l'application ?", "Erreur de Connection", MessageBoxButtons.YesNo);
                    if(res == DialogResult.No) { Environment.Exit(0); }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur lors du démarage de l'application : " + e.Message);
                Environment.Exit(0);
            }

            Application.Run(new MainForm());
        }
    }
}