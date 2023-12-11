using PracMVVM.Services;
using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class CategoriaUpdate : ContentPage
{
	public CategoriaUpdate(int categoriaId)
	{
        InitializeComponent();

        CategoriaServices dataServices = new CategoriaServices();
        var categoriaDb = dataServices.CategoriasGetByCategoriaID(categoriaId);
        CategoriasViewModel viewModel = new CategoriasViewModel();
        viewModel.Categoria = categoriaDb.Categoria;
        viewModel.CategoriasID = categoriaDb.CategoriaID;

        BindingContext = viewModel;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CategoriasGET());
    }
}