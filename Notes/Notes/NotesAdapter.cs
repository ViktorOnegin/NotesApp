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
using Newtonsoft.Json;

namespace Notes
{
    class NotesAdapter : BaseAdapter<Stock>
    {
        List<Stock> items;
        readonly DatabaseService databaseService;
        Activity context;

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
        
        public override Stock this[int position]
        {
            get { return items[position]; }
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
            view.FindViewById<TextView>(Resource.Id.textView3).Text = items[position].Title;
            view.FindViewById<TextView>(Resource.Id.textView4).Text = items[position].Content;

            view.Tag = position;
            view.Click -= View_Click;
            view.Click += View_Click;

            return view;
        }

        public void View_Click(object sender, EventArgs args)
        {
            var position = (int)((View)sender).Tag;
            var stock = new Intent(context, typeof(MyNotesActivity));
            stock.PutExtra("stock", JsonConvert.SerializeObject(items[position]));
            context.StartActivity(stock);
        }
    }
}