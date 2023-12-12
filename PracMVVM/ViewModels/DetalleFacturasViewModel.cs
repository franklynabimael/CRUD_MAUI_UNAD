using PracMVVM.Models;
using PracMVVM.Services;
using PracMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracMVVM.ViewModels;

public class DetalleFacturasViewModel : BaseViewModel
{
    #region Variables locales

    int _detalleFacturaId;
    int _productoId;
    int _facturaId;
    float _costo;
    float _cantidad;
    float _precio;




    List<clsDetalleFacturasBE> _DetalleFacturas;

    #endregion

    #region Propiedades

    public List<clsDetalleFacturasBE> DetalleFacturas
    {
        get
        {
            return _DetalleFacturas;
        }

        set
        {
            if (_DetalleFacturas != value)
            {
                _DetalleFacturas = value;

                this.OnPropertyChanged(nameof(DetalleFacturas));
            }
        }
    }

    public int DetalleFacturaId
    {
        get
        {
            return _detalleFacturaId;
        }

        set
        {
            if (_detalleFacturaId != value)
            {
                _detalleFacturaId = value;

                this.OnPropertyChanged(nameof(DetalleFacturaId));
            }
        }
    }
    public int ProductoId
    {
        get
        {
            return _productoId;
        }

        set
        {
            if (_productoId != value)
            {
                _productoId = value;

                this.OnPropertyChanged(nameof(ProductoId));
            }
        }
    }
    public int FacturaId
    {
        get
        {
            return _facturaId;
        }

        set
        {
            if (_facturaId != value)
            {
                _facturaId = value;

                this.OnPropertyChanged(nameof(FacturaId));
            }
        }
    }
    public float Costo
    {
        get
        {
            return _costo;
        }

        set
        {
            if (_costo != value)
            {
                _costo = value;

                this.OnPropertyChanged(nameof(Costo));
            }
        }
    }
    public float Cantidad
    {
        get
        {
            return _cantidad;
        }

        set
        {
            if (_cantidad != value)
            {
                _cantidad = value;

                this.OnPropertyChanged(nameof(Cantidad));
            }
        }
    }
    public float Precio
    {
        get
        {
            return _precio;
        }

        set
        {
            if (_precio != value)
            {
                _precio = value;

                this.OnPropertyChanged(nameof(Precio));
            }
        }
    }



    #endregion

    #region Commands

    private ICommand _saveCommand;
    private ICommand _deleteCommand;
    private ICommand _updateCommand;


   

    public ICommand SaveCommand
    {
        get
        {
            return _saveCommand ?? (_saveCommand =
                new Command((obj) =>
                {
                    Save();
                }
            ));
        }
    }
    public ICommand DeleteCommand
    {
        get
        {
            return _deleteCommand ?? (_deleteCommand =
                new Command((obj) =>
                {
                    Delete();
                }
            ));
        }
    }
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


    private void Save()
    {
        try
        {

      

            if (string.IsNullOrEmpty(ProductoId.ToString()))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es necesario ID del Producto  del Detalle de la Factura", "Aceptar");
                return;
            }


            if (string.IsNullOrEmpty(FacturaId.ToString() ))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es necesario ID de la Factura  del Detalle de la Factura", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(Costo.ToString()))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es necesario El Costo ", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Cantidad.ToString()))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es necesario La cantidad ", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Precio.ToString()))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es Necesario el Precio", "Aceptar");
                return;
            }
        }
        catch { }

        DetalleFacturasServices data = new DetalleFacturasServices();
            var result = data.DetalleFacturasSave(ProductoId, FacturaId, Costo, Cantidad, Precio);
            getDatos();
            App.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
            App.Current.MainPage.Navigation.PushAsync(new DetalleFacturaView(), true);
       
    }
    private void Update()
    {

         DetalleFacturasServices data = new DetalleFacturasServices();
         var result = data.DetalleFacturasUpdate(DetalleFacturaId, ProductoId,FacturaId, Costo, Cantidad, Precio);
         getDatos();

         Application.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
         App.Current.MainPage.Navigation.PushAsync(new CategoriasGET());
       
    }
    private void Delete()
    {
        try
        {
            DetalleFacturasServices data = new DetalleFacturasServices();
            var result = data.DetalleFacturasDeleteGetByDetalleFacturaID(DetalleFacturaId);
            App.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
        }
        catch { }
    }

    #endregion

    public DetalleFacturasViewModel()
    {
        getDatos();
    }

    private void getDatos()
    {
        DetalleFacturasServices data = new DetalleFacturasServices();
        DetalleFacturas = data.DetalleFacturasGet();
    }
}