using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class FacturasCrear : ContentPage
{
	public FacturasCrear()
	{
		InitializeComponent();
        BindingContext = new FacturasViewModel();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FacturasView());

    }
}