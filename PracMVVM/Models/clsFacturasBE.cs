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
[Table("Facturas")]
public class clsFacturasBE
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FacturaID { get; set; }
    public DateTime? Fecha { get; set; }
    public float SubTotal { get; set; }
    public float Descuento { get; set; }
    public float Monto { get; set; }
    public int TipoFacturaId { get; set; }
    public virtual clsTipoFacturasBE? TipoFacturas { get; set; }
    public int ClienteId { get; set; }
    public virtual clsClientesBE? Cliente { get; set;}
    public virtual ICollection<clsDetalleFacturasBE>? DetalleFacturas { get; set; }





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
            if (string.IsNullOrEmpty(FacturaID.ToString()))
            {
                Application.Current.MainPage.DisplayAlert("Aviso", "Es necesario el ID", "Aceptar");
                return;
            }


            FacturaServices data = new FacturaServices();
            var result = data.DeleteByFacturaID(FacturaID);
            Application.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
            App.Current.MainPage.Navigation.PushAsync(new FacturasView());
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
        App.Current.MainPage.Navigation.PushAsync(new FacturaUpdate(FacturaID));
    }
}