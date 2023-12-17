using PracMVVM.Services;
using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class DetalleFacturaUpdate : ContentPage
{
    public DetalleFacturaUpdate(int DetalleFacturaId)
    {
        InitializeComponent();

        DetalleFacturasServices dataServices = new DetalleFacturasServices();
        var detalleDb = dataServices.DetalleFacturasGetByDetalleFacturaID(DetalleFacturaId);
        DetalleFacturasViewModel viewModel = new DetalleFacturasViewModel();
        viewModel.DetalleFacturaId  = detalleDb.DetalleFacturaId;
        viewModel.ProductoId = detalleDb.ProductoID;
        viewModel.FacturaId = detalleDb.FacturaID;
        viewModel.Costo = detalleDb.Costo;
        viewModel.Cantidad = detalleDb.Cantidad;
        viewModel.Precio = detalleDb.Precio;




        BindingContext = viewModel;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetalleFacturaView());
     
    }
    
}