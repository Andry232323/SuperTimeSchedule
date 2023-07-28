using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace SuperTimeSchedule
{
    //https://github.com/googlesamples/oauth-apps-for-windows/tree/master/OAuthDesktopApp
    public class Auth
    {
        private string[] Scopes = { DriveService.Scope.Drive };
        private string ApplicationName = "SuperTimeSchedule";

        public UserCredential GetUserCredentials()
        {
            string jsonPath = "C:\\Users\\Andry\\Desktop\\Lecon C#\\SuperTimeSchedule\\SuperTimeSchedule\\credentials.json";
            //TODO
            using (var stream = new FileStream(jsonPath, FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                return GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
        }

        public DriveService GetDriveService()
        {
            UserCredential credential = GetUserCredentials();

            // Create Drive API service.
            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });
        }

        public DriveService CreateDriveService(UserCredential credential)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            try
            {
                // Créez un objet DriveService à partir des informations d'identification de l'utilisateur
                return new DriveService(new Google.Apis.Services.BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "VotreApplication"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la création du service Google Drive : " + ex.Message);
                return null;
            }
        }
    }
}
