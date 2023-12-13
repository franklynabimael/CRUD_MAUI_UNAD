
using PracMVVM.Services;
using PracMVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PracMVVM.Models;
[Table("TipoFacturas")]
public class clsTipoFacturasBE
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TipoFacturaID { get; set; }
    public string? TipoFactura { get; set; }











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
            if (string.IsNullOrEmpty(TipoFacturaID.ToString()))
            {
                Application.Current.MainPage.DisplayAlert("Aviso", "Es necesario el ID", "Aceptar");
                return;
            }


            TipoFacturaServices data = new TipoFacturaServices();
            var result = data.DeleteByTipoFacturaID(TipoFacturaID);
            Application.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
            App.Current.MainPage.Navigation.PushAsync(new TipoFacturaView());
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
        App.Current.MainPage.Navigation.PushAsync(new TipoFacturaUpdate(TipoFacturaID));
    }
}