using PracMVVM.Services;
using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class FacturaUpdate : ContentPage
{
    public FacturaUpdate(int FacturaId)
    {
        InitializeComponent();

        FacturaServices dataServices = new FacturaServices();
        var FacturaDb = dataServices.FacturasGetByFacturaID(FacturaId);
        FacturasViewModel viewModel = new FacturasViewModel();
        viewModel.FacturaID = FacturaDb.FacturaID;
        
        viewModel.SubTotal = FacturaDb.SubTotal;
        viewModel.Descuento = FacturaDb.Descuento;
        viewModel.TipoFacturaId = FacturaDb.TipoFacturaId;
        viewModel.ClienteId = FacturaDb.ClienteId;
        viewModel.Monto = FacturaDb.Monto;

        BindingContext = viewModel;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FacturasView());
    }
}