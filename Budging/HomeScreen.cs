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

namespace Budging
{
    [Activity(Label = "Activity1")]
    public class HomeScreen : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here

            SetContentView(Resource.Layout.home_screen);

            EditText editText = FindViewById<EditText>(Resource.Id.editText1);
            TextView textView = FindViewById<TextView>(Resource.Id.textView2);

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "notes.db");
            var dbContext = new NotesDatabaseContext(databasePath);

            Button saveBtn = FindViewById<Button>(Resource.Id.button1);

            saveBtn.Click += (sender, e) =>
            {
                var content = editText.Text;
                var note = new Note { Content = content };
                dbContext.AddNote(note);
                editText.Text = string.Empty;
            };

            var notes = dbContext.GetNotes();

            foreach (var note in notes)
            {
                textView.Text = note.Content;
            }
        }

        public class Note
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Content { get; set; }
        }

        public class NotesDatabaseContext : SQLiteConnection
        {
            public NotesDatabaseContext(string databasePath) : base(databasePath)
            {
                CreateTable<Note>();
            }

            public IEnumerable<Note> GetNotes() 
            {
                return Table<Note>().ToList();
            }

            public void AddNote(Note note)
            {
                Insert(note);
            }
        }
    }
}