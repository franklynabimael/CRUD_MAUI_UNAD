using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class FacturasView : ContentPage
{
	public FacturasView()
	{
		InitializeComponent();
        BindingContext = new FacturasViewModel();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FacturasCrear());

    }
}