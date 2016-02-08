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

using Android.Graphics;

namespace RedBinkieResearchLabs
{
    [Activity(Label = "Wessex Water Services Ltd", MainLauncher = true, Icon = "@drawable/icon")]

    public class doLogin : Activity
    {
        clsAuth oAuth = new clsAuth();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Set our view from the "login" layout resource
            SetContentView(Resource.Layout.login);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.button1);

            //get the username field
            EditText usernameText = FindViewById<EditText>(Resource.Id.editText1);
            //get the password field
            EditText passwordText = FindViewById<EditText>(Resource.Id.editText2);

            //get the error field
            TextView errorText = FindViewById<TextView>(Resource.Id.errText);

            button.Click += delegate {
                if(usernameText.Text != "" && passwordText.Text != "")
                {
                    if (validateLogin(usernameText.Text.ToString(), passwordText.Text.ToString()))
                    {
                        StartActivity(typeof(MainActivity));
                    }
                    else
                    {
                        //invalid login
                        errorText.Text = "Invalid username or password";
                    }
                }
                else
                {
                    if (usernameText.Text == "")
                    {
                        errorText.Text = "Please enter username";
                        //usernameText.SetHighlightColor(Color.Red);
                    }
                    else if (passwordText.Text == "")
                    {
                        errorText.Text = "Please enter password";
                        //passwordText.SetHighlightColor(Color.Red);
                    }
                    else
                    {
                        errorText.Text = "Unknown error";
                    }

                }


            };

        }

        public Boolean validateLogin(String username, String password)
        {
            if(oAuth.doAuth(username,password,Application.Context))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}