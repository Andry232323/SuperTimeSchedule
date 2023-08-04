using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTimeSchedule.Model
{
    public class User_Calendar
    {
        public string Name { get; set; }

        /// <summary>
        /// Constructor of User_Calendar
        /// </summary>
        /// <param name="credential"> user's credentials</param>
        public User_Calendar(UserCredential credential)
        {
            var service = new Oauth2Service(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential
            });

            var userInfo = service.Userinfo.Get().Execute();

            Name = userInfo.Name;

        }
    }
}
