using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApp.Data
{
    public static class Constants
    {
        public const string dbName = "sqlite.db3";
        public const SQLite.SQLiteOpenFlags flags = SQLite.SQLiteOpenFlags.ReadWrite 
            | SQLite.SQLiteOpenFlags.SharedCache;
        public static string dbpath
        {
            get {
                //var basepath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                //var basepath = AppDomain.CurrentDomain.BaseDirectory;
                //var basepath = AppContext.BaseDirectory + "MauiAssets";
                //var basepath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                var dir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName;
                var basepath = Path.Combine(dir, "MauiAssets");
                return Path.Combine(basepath, dbName);
            }
        }
    }
}
