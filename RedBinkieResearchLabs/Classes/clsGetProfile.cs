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
    class clsGetProfile
    {
        ISharedPreferences prefs = Application.Context.GetSharedPreferences("FlowPref", FileCreationMode.Private);
        public void GetProfile(string uid)
        {
            string[] strDefault = new string[6];
            ISharedPreferencesEditor editor = prefs.Edit();
            
            try
            {
                OnlineServices.BasicHttpBinding_IService1 obj = new OnlineServices.BasicHttpBinding_IService1();
                strDefault = obj.GetProfile(uid);
                editor.PutString("profileguid", strDefault[0]);
                editor.PutString("firstname", strDefault[2]);
                editor.PutString("lastname", strDefault[3]);
                editor.PutString("fullname", strDefault[2] + " " + strDefault[3]);
                editor.PutString("email", strDefault[4]);
                editor.PutString("phone", strDefault[5]);
                editor.Apply();
            }
            catch (Exception ex)
            {
            }
        }
    }
}