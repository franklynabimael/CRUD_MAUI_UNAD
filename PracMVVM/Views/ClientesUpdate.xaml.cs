using PracMVVM.Services;
using PracMVVM.ViewModels;

namespace PracMVVM.Views;

public partial class ClientesUpdate : ContentPage
{
    public ClientesUpdate(int ClienteID)
    {
        InitializeComponent();

        ClienteServices dataServices = new ClienteServices();
        var x = dataServices.ClientesGetByClienteID(ClienteID);
        ClientesViewModel viewModel = new ClientesViewModel();
        viewModel.ClienteId = x.ClienteID;
        viewModel.Nombres = x.Nombres;
        viewModel.Direccion = x.Direccion;
        viewModel.Telefonos = x.Telefono;
        BindingContext = viewModel;

    }

}