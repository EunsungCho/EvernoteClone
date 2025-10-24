using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel.Helpers
{
    internal class DatabaseHelper
    {
        private static string dbFile = Path.Combine(Environment.CurrentDirectory, "notesDb.db3");
        public static bool Insert<T>(T item)
        {
            bool result = false;
            
            using (SQLiteConnection con = new SQLiteConnection(dbFile))
            {
                con.CreateTable<T>();
                int rows = con.Insert(item);
                if (rows > 0)
                    result = true;
            }
            return result;
        }

        public static bool Update<T>(T item)
        {
            bool result = false;
            using(SQLiteConnection con = new SQLiteConnection(dbFile))
            {
                con.CreateTable<T>();
                int rows = con.Update(item);
                if (rows > 0)
                    result = true;
            }
            return result;
        }

        public static bool Delete<T>(T item)
        {
            bool result = false;
            using(SQLiteConnection con = new SQLiteConnection(dbFile))
            {
                con.CreateTable<T>();
                int rows = con.Delete(item);
                if (rows > 0)
                    result = true;
            }
            return result;
        }

        public static List<T> Read<T>() where T : new()
        {
            List<T> items;
            using(SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                items = conn.Table<T>().ToList();
            }
            return items;
        }
    }
}
