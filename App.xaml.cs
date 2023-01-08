using System;
using ShoesShopping.Data;
using System.IO;

namespace ShoesShopping;

public partial class App : Application
{
    static ShoeShopDatabase database;
    public static ShoeShopDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               ShoeShopDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "ShoeShop.db3"));
            }
            return database;
        }
    }


    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
