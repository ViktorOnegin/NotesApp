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
using Newtonsoft.Json;

namespace Notes
{
    [Activity(Label = "MyNotesActivity")]
    public class MyNotesActivity : Activity
    {
        DatabaseService databaseService;
        Stock stock;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MyNotesLayout);

            var Title = FindViewById<TextView>(Resource.Id.textView3);
            var Content = FindViewById<TextView>(Resource.Id.textView4);
            var deleteBtn = FindViewById<Button>(Resource.Id.button1);
            deleteBtn.Click += DeleteBtn_Click;

            stock = JsonConvert.DeserializeObject<Stock>(Intent.GetStringExtra("stock"));
            databaseService = new DatabaseService();
            databaseService.CreateDatabase();

            Title.Text = stock.Title;
            Content.Text = stock.Content;
        }

        public void DeleteBtn_Click (object sender, EventArgs args)
        {
            databaseService.DeleteStock(stock);
            Finish();
        }
    }
}