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

[Table("Categorias")]
public class ClsCategoriasBE
{
    [Key]
    public int CategoriaID { get; set; }
    
    public string Categoria { get; set; }
    public virtual ICollection<clsProductosBE> Productos { get; set; }
    public ClsCategoriasBE() 
    {
    }

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
            if (string.IsNullOrEmpty(CategoriaID.ToString()))
            {
                Application.Current.MainPage.DisplayAlert("Aviso", "Es necesario el ID", "Aceptar");
                return;
            }
            

            CategoriaServices data = new CategoriaServices();
            var result = data.DeleteByCategoriaID(CategoriaID);
          Application.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
            App.Current.MainPage.Navigation.PushAsync(new CategoriasGET());
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
        App.Current.MainPage.Navigation.PushAsync(new CategoriaUpdate(CategoriaID));
    }
}
