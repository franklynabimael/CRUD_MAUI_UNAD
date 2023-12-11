using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class TipoFacturasCrear : ContentPage
{
	public TipoFacturasCrear()
	{
		InitializeComponent();
        BindingContext = new TipoFacturasViewModel();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TipoFacturaView());
    }
}