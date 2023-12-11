using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class ClientesGet : ContentPage
{
	public ClientesGet()
	{
		InitializeComponent();
        BindingContext = new ClientesViewModel();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientesView()); 
    }
}