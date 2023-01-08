using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoesShopping.Models;
using SQLite;

namespace ShoesShopping.Data
{
    public class ShoeShopDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ShoeShopDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ShoeShop>().Wait();
        }
        public Task<List<ShoeShop>> GetShoeShopsAsync()
        {
            return _database.Table<ShoeShop>().ToListAsync();
        }
        public Task<ShoeShop> GetShoeShopAsync(int id)
        {
            return _database.Table<ShoeShop>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(ShoeShop slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteShopListAsync(ShoeShop slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
