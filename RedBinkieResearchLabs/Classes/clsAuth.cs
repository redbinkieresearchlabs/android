using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Newtonsoft.Json;
using System.Threading.Tasks;


namespace RedBinkieResearchLabs
{
    class clsAuth
    {
        private string GlobalUsername;
        private string GlobalPassword;

        public bool doAuth(string username, string password, Context context)
        {
            
            GlobalUsername = username;
            GlobalPassword = password;
            string[] str= connection();

            if (str[0] == "0")
            {
                ISharedPreferences prefs = Application.Context.GetSharedPreferences("FlowPref", FileCreationMode.Private);
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutString("uname", username);
                editor.PutString("uid", str[1]);
                editor.PutString("authmode", str[2]);
                editor.PutString("userstatus", str[3]);
                editor.PutString("logincount", str[4]);
                editor.PutString("lastlogin", str[5]);
                editor.Apply();

                //it was a successfull login so update the values in db
                OnlineServices.BasicHttpBinding_IService1 obj = new OnlineServices.BasicHttpBinding_IService1();
                obj.UpdateUserLogin(str[1], Int32.Parse(str[4]),true);
                return true;
            }
            else
            {
                if (str[2] != "local")
                {
                    return nonSQLAuthentication(str[2]);
                }
                else
                {
                    return false;
                }
                    
            }
            
        }        

        private string[] connection()
        {
            string[] strDefault = new string[2];
            try
            {
                OnlineServices.BasicHttpBinding_IService1 obj = new OnlineServices.BasicHttpBinding_IService1();
                return obj.GetUserData(GlobalUsername, GlobalPassword);
               
            }
            catch (Exception ex)
            {
                strDefault[0] = "5";
                strDefault[1] = ex.InnerException.Message.ToString();
                return strDefault;
            }
            
        }

        private bool nonSQLAuthentication(string mode)
        {
            return true;
        }
    }

}