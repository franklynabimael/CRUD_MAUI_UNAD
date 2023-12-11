using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class CategoriaView : ContentPage
{
	public CategoriaView()
	{
        InitializeComponent();

        BindingContext = new CategoriasViewModel();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CategoriasGET());
    }
}