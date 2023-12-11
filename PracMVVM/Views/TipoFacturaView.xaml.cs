using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class TipoFacturaView : ContentPage
{
	public TipoFacturaView()
	{
		InitializeComponent();
        BindingContext = new TipoFacturasViewModel();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TipoFacturasCrear());
    }

    
}