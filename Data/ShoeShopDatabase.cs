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
            _database.CreateTableAsync<Product>().Wait();
            _database.CreateTableAsync<ListProduct>().Wait();

        }

        public Task<int> SaveProductAsync(Product product)
        {
            if (product.ID != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }
        public Task<int> DeleteProductAsync(Product product)
        {
            return _database.DeleteAsync(product);
        }
        public Task<List<Product>> GetProductsAsync()
        {
            return _database.Table<Product>().ToListAsync();
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

        public Task<int> SaveListProductAsync(ListProduct listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Product>> GetListProductsAsync(int shoeshopid)
        {
            return _database.QueryAsync<Product>(
            "select P.ID, P.Description from Product P" + " inner join ListProduct LP" + " on P.ID = LP.ProductID where LP.ShoeShopID = ?", shoeshopid);
        }



    }
}
