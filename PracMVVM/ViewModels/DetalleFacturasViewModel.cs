using PracMVVM.Models;
using PracMVVM.Services;
using PracMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracMVVM.ViewModels;

public    class DetalleFacturasViewModel: BaseViewModel
{
    #region Variables locales

    int _productoID;
    int _facturaID;
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

    public int ProductoID
    {
        get
        {
            return _productoID;
        }

        set
        {
            if (_productoID != value)
            {
                _productoID = value;

                this.OnPropertyChanged(nameof(_productoID));
            }
        }
    }

    public int FacturaID
    {
        get
        {
            return _facturaID;
        }

        set
        {
            if (_facturaID != value)
            {
                _facturaID = value;

                this.OnPropertyChanged(nameof(_facturaID));
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

                this.OnPropertyChanged(nameof(_costo));
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

                this.OnPropertyChanged(nameof(_cantidad));
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

                this.OnPropertyChanged(nameof(_precio));
            }
        }
    }

    #endregion

    #region Commands

    private ICommand _saveCommand;

    private void MostrarFormulario()
    {
        App.Current.MainPage.Navigation.PushAsync(new DetalleFacturaView());
    }

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

    private void Save()
    {
       

            DetalleFacturasServices data = new DetalleFacturasServices();
            var result = data.DetalleFacturasSave(ProductoID, FacturaID, Costo, Cantidad,Precio);

            App.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
        }
       
    }

    #endregion


