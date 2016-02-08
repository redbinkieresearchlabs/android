using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RedBinkieResearchLabs
{
    class clsAuth
    {
        Context pCont;
        public bool doAuth(string username, string password, Context context)
        {
            this.pCont = context;
            sharedPref.SavePreference(context, "uname", username);
            return true;
        }
    }
}