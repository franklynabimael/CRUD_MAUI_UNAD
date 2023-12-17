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

[Table("DetalleFactura")]
public class clsDetalleFacturasBE
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DetalleFacturaId { get; set; }
   
    [StringLength(50)]
    public int ProductoID { get; set; }
    public virtual clsProductosBE? Producto { get; set; }
    public int FacturaID { get; set; }
    public float Costo {  get; set; }
    public float Cantidad { get; set; }
    public float Precio { get; set; }


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
            if (string.IsNullOrEmpty(DetalleFacturaId.ToString()))
            {
                Application.Current.MainPage.DisplayAlert("Aviso", "Es necesario el ID", "Aceptar");
                return;
            }


            DetalleFacturasServices data = new DetalleFacturasServices();
            var result = data.DetalleFacturasDeleteGetByDetalleFacturaID(DetalleFacturaId);
            Application.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
            App.Current.MainPage.Navigation.PushAsync(new DetalleFacturaView());
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
        App.Current.MainPage.Navigation.PushAsync(new DetalleFacturaUpdate(DetalleFacturaId));
    }
}

