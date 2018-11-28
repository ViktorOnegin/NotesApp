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
    [Activity(Label = "Activity1")]
    public class AddNotesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddNotesLayout);

            var Title = FindViewById<EditText>(Resource.Id.editText1);
            var Content = FindViewById<EditText>(Resource.Id.editText2);
            var Addbtn = FindViewById<Button>(Resource.Id.button1);
            var list = FindViewById<ListView>(Resource.Id.listView1);

            var deleteBtn = FindViewById<Button>(Resource.Id.button1);
            //deleteBtn.Click += DeleteBtn_Click;

            var databaseService = new DatabaseService();
            databaseService.CreateDatabase();
            var stocks = databaseService.GetAllStocks();


            Addbtn.Click += delegate
            {
                var StockName1 = Title.Text;
                var StockName2 = Content.Text;
                databaseService.AddStock(StockName1,StockName2);

                stocks = databaseService.GetAllStocks();
                list.Adapter = new NotesAdapter(this, stocks.ToList(), databaseService);
            };

            list.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
            {
                databaseService.DeleteStock(stocks.ToList()[e.Position].ID);
                stocks = databaseService.GetAllStocks();
                list.Adapter = new NotesAdapter(this, stocks.ToList(), databaseService);
            };
        }

    }
}