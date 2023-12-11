using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace PracMVVM.Views;

public partial class Inicio : ContentPage
{
	public Inicio()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync( new CategoriasGET());
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductosView());
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TipoFacturaView());
    }

    private async void Button_Clicked_3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientesGet());
    }

    private async void Button_Clicked_4(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FacturasView());
    }
    private async void Button_Clicked_5(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetalleFacturaView());
    }
}