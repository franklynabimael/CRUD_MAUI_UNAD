using PracMVVM.Services;
using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class ProductoUpdate : ContentPage
{
    public ProductoUpdate(int ProductoId)
    {
        InitializeComponent();

        ProductoServices dataServices = new ProductoServices();
        var ProductoDb = dataServices.ProductosGetByProductoID(ProductoId);
        ProductosViewModels viewModel = new ProductosViewModels();
        viewModel.Producto = ProductoDb.Producto;
        viewModel.ProductoId = ProductoDb.ProductoId;
        viewModel.Costo = ProductoDb.Costo;
        viewModel.Cantidad = ProductoDb.Cantidad;
        viewModel.Precio = ProductoDb.Precio;
        viewModel.CategoriaID = ProductoDb.CategoriaID;

        BindingContext = viewModel;
        
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductosView());
    }
}