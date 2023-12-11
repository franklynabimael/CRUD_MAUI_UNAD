using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class ProductoCrear : ContentPage
{
	public ProductoCrear()
	{
		InitializeComponent();
        BindingContext = new ProductosViewModels();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductosView());
    }
}