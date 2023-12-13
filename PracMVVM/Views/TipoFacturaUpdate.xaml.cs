using PracMVVM.Services;
using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class TipoFacturaUpdate : ContentPage
{
    public TipoFacturaUpdate(int TipoFacturaID)
    {
        InitializeComponent();

        TipoFacturaServices dataServices = new TipoFacturaServices();
        var TipoFacDb = dataServices.TipoFacturasGetByTipoFacturaID(TipoFacturaID);
        TipoFacturasViewModel viewModel = new TipoFacturasViewModel();
        viewModel.TipoFacturaId = TipoFacDb.TipoFacturaID;
        viewModel.TipoFactura = TipoFacDb.TipoFactura;

        BindingContext = viewModel;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TipoFacturaView());
    }
}