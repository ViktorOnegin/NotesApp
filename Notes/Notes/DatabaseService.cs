using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Notes
{
    public class DatabaseService
    {
        SQLiteConnection db;

        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "database.db3");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Stock>();
        }

        public void AddStock(string title, string content)
        {
            var newStock = new Stock
            {
                Title = title,
                Content = content
            };
            db.Insert(newStock);
        }

        public void UptadeStock(string title, string content)
        {
            var newStock = new Stock
            {
                Title = title,
                Content = content
            };
            db.Update(newStock);
        }

        public void DeleteStock(Stock stock)
        {
            db.Delete(stock);
        }

        public TableQuery<Stock> GetAllStocks()
        {
            var table = db.Table<Stock>();
            return table;
        }
    }
}