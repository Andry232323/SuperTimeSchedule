using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Oauth2.v2;
using Google.Apis.Util.Store;
using SuperTimeSchedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.Data
{
    public class GoogleAuth
    {
        private readonly static string secretPath = "C:\\Users\\Andry\\Desktop\\Lecon C#\\SuperTimeSchedule\\SuperTimeSchedule\\client_secret.json";
        private static readonly string[] scopes = { DriveService.Scope.Drive , "https://www.googleapis.com/auth/userinfo.profile", "https://www.googleapis.com/auth/userinfo.email" };
        private static FileDataStore fileDataStore = new("C:\\Users\\Andry\\Desktop\\Lecon C#\\SuperTimeSchedule\\SuperTimeSchedule\\Data\\ConnectionData", false);
        public static UserCredential UserCredential { get; set; }
        public static User_Calendar User { get; set; }

        /// <summary>
        /// Connect to Google by OAuth2.0 Async
        /// </summary>
        /// <returns></returns>
        public static async Task ConnectGoogleAsync()
        {
            try
            {
                using(var stream = new FileStream(secretPath, FileMode.Open, FileAccess.Read)) 
                {
                    UserCredential = await GoogleWebAuthorizationBroker.AuthorizeAsync
                        (
                        GoogleClientSecrets.Load(stream).Secrets, scopes,
                        "user", CancellationToken.None,
                        fileDataStore
                        );

                }
                 User = new User_Calendar(UserCredential);
            } catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la connection avec google : " + ex.Message);
            }
        }


        public static bool ConnectGoogle()
        {
            try
            {
                using (var stream = new FileStream(secretPath, FileMode.Open, FileAccess.Read))
                {
                    Task<Task<UserCredential>> res = Task.Run
                    ( async() => GoogleWebAuthorizationBroker.AuthorizeAsync
                        (
                        GoogleClientSecrets.Load(stream).Secrets, scopes,
                        "user", CancellationToken.None,
                        fileDataStore
                        )
                    );
                    UserCredential = res.Result.Result;
                }
                User = new User_Calendar(UserCredential);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la connection avec google : " + ex.Message);
            }

            return UserCredential != null;
        }

        /// <summary>
        /// Disconnect the current Google Account by clearing the credentials, also quit the App
        /// </summary>
        /// <returns></returns>
        public static async Task DisconnectGoogleAsync()
        {
            try { 
                await fileDataStore.ClearAsync();
                DialogResult res = MessageBox.Show("Etes vous sur de vouloir quitter l'application ? Toute donnée non sauvegarder sera perdue.", "Confirmation", MessageBoxButtons.YesNo);
                if(res == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
            } catch (Exception ex)
            {
                MessageBox.Show("erreur lors de la deconnection : " + ex.Message);
            }
        }

    }
}
