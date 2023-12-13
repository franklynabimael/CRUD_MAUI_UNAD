using PracMVVM.Services;
using PracMVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracMVVM.Models;
[Table("Clientes")]
public class clsClientesBE
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClienteID { get; set; }
    public string? Nombres { get; set;}
    public string? Direccion { get; set; }

    public string? Telefono { get; set; }


    
    
    
    
    
    
    
    
    
    private ICommand _DeleteCommand;

    public ICommand DeleteCommand
    {
        get
        {
            return _DeleteCommand ?? (_DeleteCommand =
                new Command((obj) =>
                {
                    Delete();
                }
            ));
        }
    }


    private void Delete()
    {
        try
        {
            if (string.IsNullOrEmpty(ClienteID.ToString()))
            {
                Application.Current.MainPage.DisplayAlert("Aviso", "Es necesario el ID", "Aceptar");
                return;
            }


            ClienteServices data = new ClienteServices();
            var result = data.DeleteByClienteID(ClienteID);
            Application.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
            App.Current.MainPage.Navigation.PushAsync(new ClientesGet());
        }
        catch { }
    }

    private ICommand _updateCommand;

    public ICommand UpdateCommand
    {
        get
        {
            return _updateCommand ?? (_updateCommand =
                new Command((obj) =>
                {
                    Update();
                }
            ));
        }
    }

    private void Update()
    {
        App.Current.MainPage.Navigation.PushAsync(new ClientesUpdate(ClienteID));
    }
}
