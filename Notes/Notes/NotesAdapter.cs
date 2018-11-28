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
using Java.Lang;

namespace Notes
{
    class NotesAdapter : BaseAdapter
    {
        List<Stock> items;
        DatabaseService databaseService;
        Activity context;
        //Stock stock;

        public NotesAdapter(Activity context, List<Stock> items, DatabaseService databaseService) : base()
        {
            this.context = context;
            this.items = items;
            this.databaseService = databaseService;
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null; 
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.NotesList, null);
            var Title = view.FindViewById<TextView>(Resource.Id.textView1).Text = items[position].Title;
            var Content = view.FindViewById<TextView>(Resource.Id.textView2).Text = items[position].Content;

            position = (items.Count - 1) - position;
            view.Tag = position;

            //var deleteBtn = view.FindViewById<Button>(Resource.Id.button1);
            //deleteBtn.Tag = position;

            //var databaseService = new DatabaseService();
            //databaseService.CreateDatabase();
            //var stocks = databaseService.GetAllStocks();

            //deleteBtn.Click += delegate
            //{
            //    var StockName1 = Title;
            //    var StockName2 = Content;
            //    databaseService.DeleteStock(StockName1, StockName2);
            //};

            return view;
        }
    }
}