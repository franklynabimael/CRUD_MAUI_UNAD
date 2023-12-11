using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class DetalleFacturaView : ContentPage
{
	public DetalleFacturaView()
	{
		InitializeComponent();
        BindingContext = new DetalleFacturasViewModel();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetalleFacturaCrear());
    }
}