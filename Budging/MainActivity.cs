using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace Budging
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Typeface budgingfont = Typeface.CreateFromAsset(this.Assets, "Fonts/amaranthfont.ttf");

            ViewGroup rootLayout = FindViewById<ViewGroup>(Android.Resource.Id.Content);
            SetTypefaceForView(rootLayout, budgingfont);

        }

        private void SetTypefaceForView(View view, Typeface typeface)
        {
            if (view is TextView)
            {
                ((TextView)view).Typeface = typeface;
            }

            else if (view is ViewGroup)
            {
                ViewGroup viewGroup = (ViewGroup)view;
                for (int i = 0; i < viewGroup.ChildCount; i++)
                {
                    SetTypefaceForView(viewGroup.GetChildAt(i), typeface);
                }
            }
        }
    }
}