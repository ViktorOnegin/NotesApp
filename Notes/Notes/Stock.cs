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

namespace Notes
{
    public class Stock
    {
        //[PrimaryKey, AutoIncrement, Column("_ID")]
        //[MaxLength(8)]
        public string Title { get; set; }
        public string Text { get; set; }
        public int ID { get; set; }
    }
}