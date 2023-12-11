using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class DetalleFacturaCrear : ContentPage
{
	public DetalleFacturaCrear()
	{
		InitializeComponent();
        BindingContext = new DetalleFacturasViewModel();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetalleFacturaView());
    }
}