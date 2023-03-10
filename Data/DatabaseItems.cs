using NuGet.Common;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApp.Data
{
    public class DatabaseItems
    {
        static SQLiteAsyncConnection Databse;
        public static readonly AsyncLazy<DatabaseItems> Instance = new AsyncLazy<DatabaseItems>(
            async () =>
            {
                var instance = new DatabaseItems();
                try
                {
                    CreateTableResult result = await Databse.CreateTableAsync<TableItems>();
                }
                catch(Exception ex) {
                    throw;
                }
                return instance;
            });
        public DatabaseItems()
        {
            Databse = new SQLiteAsyncConnection(Constants.dbpath, Constants.flags);
        }
        public Task<List<TableItems>> GetTableItemsAsync()
        {
            return Databse.Table<TableItems>().ToListAsync();
        } 
        public Task<List<TableItems>> GetItemsNotDoneAsync()
        {
            return Databse.QueryAsync<TableItems>("SELECT * FROM [TableItems] Where [Done] = 0");
        } 
        public Task<TableItems> GetItemAsync(int id)
        {
            return Databse.Table<TableItems>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        public Task<int> saveItemAsync(TableItems items)
        {
            if(items.Id != 0)
            {
                return Databse.UpdateAsync(items);
            }
            else
            {   
                return Databse.InsertAsync(items);
            }
        }       
        public Task<int> deleteItemAsync(TableItems items)
        {
                return Databse.DeleteAsync(items);
        }

    }
}
