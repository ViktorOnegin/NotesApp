﻿using System;
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
            var newStock = new Stock();
            newStock.Title = title;
            newStock.Content = content;
            db.Insert(newStock);
        }

        public void DeleteStock(int id)
        {
            var newStock = new Stock();
            newStock.ID = id;
            db.Delete(newStock);
        }

        public TableQuery<Stock> GetAllStocks()
        {
            var table = db.Table<Stock>();
            return table;
        }
    }
}