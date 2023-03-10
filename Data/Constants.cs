﻿using Microsoft.Maui.Storage;
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
            | SQLite.SQLiteOpenFlags.Create
            | SQLite.SQLiteOpenFlags.SharedCache;
        public static string dbpath
        {
            get {
                //var basepath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var basepath = AppDomain.CurrentDomain.BaseDirectory;
                return Path.Combine(basepath, dbName);
            }
        }
    }
}
