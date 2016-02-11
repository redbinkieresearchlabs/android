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
    class sharedPref
    {
        public static void SavePreference(Context context, string key, string value)
        {
            ISharedPreferences preferences = context.GetSharedPreferences("shared", FileCreationMode.Private);
            ISharedPreferencesEditor editor = preferences.Edit();
            editor.PutString(key, value);
            editor.Apply();
            editor.Commit();
        }
        public static string GetPreference(Context context, string key, string defaultValue)
        {
            ISharedPreferences preferences = context.GetSharedPreferences("shared", FileCreationMode.Private);
            string value = preferences.GetString(key, defaultValue);
            return value;
        }
    }

    public class listviewModelFault
    {
        public int colNo { get; set; }
        public string colFault { get; set; }
        public string colStatus { get; set; }

        public override string ToString()
        {
            return this.colFault;
        }
    }
}