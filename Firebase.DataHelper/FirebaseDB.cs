using Appreciation.Manager.AppSettings;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase.DataHelper
{
    public class FirebaseDB : IDisposable
    {
        public IFirebaseClient FirebaseClient { get; set; }

        public FirebaseDB()
        {
           
            FirebaseClient = new FirebaseClient(new FirebaseConfig()
            {
                AuthSecret = Settings.FirebaseDbKey,
                BasePath = Settings.FirebaseDb
            });
        }


        public void Dispose()
        {
            FirebaseClient = null;
        }
    }
}
