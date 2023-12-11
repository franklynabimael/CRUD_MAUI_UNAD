using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class ProductosView : ContentPage
{
	public ProductosView()
	{
		InitializeComponent();
        BindingContext = new ProductosViewModels();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductoCrear());

    }
}