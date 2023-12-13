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
[Table("Productos")]
public class clsProductosBE
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductoId { get; set; }
    public string Producto { get; set; } = string.Empty;
    public float Costo { get; set;}
    public float Cantidad { get; set;}
    public float Precio { get; set; }
    public int CategoriaID { get; set;}




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
            if (string.IsNullOrEmpty(ProductoId.ToString()))
            {
                Application.Current.MainPage.DisplayAlert("Aviso", "Es necesario el ID", "Aceptar");
                return;
            }


            ProductoServices data = new ProductoServices();
            var result = data.DeleteByProductoID(ProductoId);
            Application.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
            App.Current.MainPage.Navigation.PushAsync(new ProductosView());
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



        App.Current.MainPage.Navigation.PushAsync(new ProductoUpdate(ProductoId));
    }
}














