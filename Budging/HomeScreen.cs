using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Xamarin.Essentials;
using static Android.Provider.ContactsContract.CommonDataKinds;
using Android.Text;
using Java.Lang;

namespace Budging
{
    [Activity(Label = "Activity1")]
    public class HomeScreen : Activity {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here

            SetContentView(Resource.Layout.home_screen);

            EditText editText = FindViewById<EditText>(Resource.Id.editText1);
            TextView textView = FindViewById<TextView>(Resource.Id.textView2);
            Button saveBtn = FindViewById<Button>(Resource.Id.button1);
            TextView budgetView = FindViewById<TextView>(Resource.Id.budgetView);

            editText.AddTextChangedListener(new MyTextWatcher(budgetView));

        }

        public class MyTextWatcher : Java.Lang.Object, ITextWatcher
        {
            private TextView textView;

            public MyTextWatcher(TextView budgetView) 
            { 
                this.textView = budgetView;
            }

            public void AfterTextChanged(IEditable s)
            {
            }

            public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
            {
            }

            public void OnTextChanged(ICharSequence s, int start, int before, int count)
            {
                string input = s.ToString();
                textView.Text = "Your current budget: " + input;
            }
        }

    }
}