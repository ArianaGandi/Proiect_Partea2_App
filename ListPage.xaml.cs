using ShoesShopping.Models;

namespace ShoesShopping;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shoeS = (ShoeShop)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(shoeS.ID);
    }

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((ShoeShop)
       this.BindingContext)
        {
            BindingContext = new Product()
        });

    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShoeShop)BindingContext;
        await App.Database.SaveShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShoeShop)BindingContext;
        await App.Database.DeleteShopListAsync(slist);
        await Navigation.PopAsync();
    }
}