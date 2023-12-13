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

public class FacturasViewModel : BaseViewModel
{
    #region Variables locales

    int _facturaId;
    DateTime _fecha;
    float _subTodal;
    float _descuento;
    float _monto;
    int _tipoFacturaId;
    int _clienteId;
    int _detalleFactura;
  

    List<clsFacturasBE> _Facturas;

    #endregion

    #region Propiedades

    public List<clsFacturasBE> Facturas
    {
        get
        {
            return _Facturas;
        }

        set
        {
            if (_Facturas != value)
            {
                _Facturas = value;

                this.OnPropertyChanged(nameof(Facturas));
            }
        }
    }

    public DateTime Fecha
    {
        get
        {
            return _fecha;
        }

        set
        {
            if (_fecha != value)
            {
                _fecha = value;

                this.OnPropertyChanged(nameof(Fecha));
            }
        }
    }



    public float SubTotal
    {
        get
        {
            return _subTodal;
        }

        set
        {
            if (_subTodal != value)
            {
                _subTodal = value;

                this.OnPropertyChanged(nameof(SubTotal));
            }
        }
    }

    public float Descuento
    {
        get
        {
            return _descuento;
        }

        set
        {
            if (_descuento != value)
            {
                _descuento = value;

                this.OnPropertyChanged(nameof(Descuento));
            }
        }
    }
    public float Monto
    {
        get
        {
            return _monto;
        }

        set
        {
            if (_monto != value)
            {
                _monto = value;

                this.OnPropertyChanged(nameof(Monto));
            }
        }
    }
    public int TipoFacturaId
    {
        get
        {
            return _tipoFacturaId;
        }

        set
        {
            if (_tipoFacturaId != value)
            {
                _tipoFacturaId = value;

                this.OnPropertyChanged(nameof(TipoFacturaId));
            }
        }
    }
    public int ClienteId
    {
        get
        {
            return _clienteId;
        }

        set
        {
            if (_clienteId != value)
            {
                _clienteId = value;

                this.OnPropertyChanged(nameof(ClienteId));
            }
        }
    }
    public int DetalleFactura
    {
        get
        {
            return _detalleFactura;
        }

        set
        {
            if (_detalleFactura != value)
            {
                _detalleFactura = value;

                this.OnPropertyChanged(nameof(DetalleFactura));
            }
        }
    }
    public int FacturaID
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

                this.OnPropertyChanged(nameof(FacturaID));
            }
        }
    }




    #endregion

    #region Commands

    private ICommand _saveCommand;
    private ICommand _deleteCommand;

    private void MostrarFormulario()
    {
        App.Current.MainPage.Navigation.PushAsync(new FacturasView());
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

    private void Save()
    {
        try
        {
            if (string.IsNullOrEmpty(Fecha.ToString()))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es necesario la Fecha de la Factura", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(SubTotal.ToString()))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es necesario el SubTotal del Factura", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(Descuento.ToString()))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es necesario el Descuento del Factura", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Monto.ToString()))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es necesario el Monto del Factura", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(TipoFacturaId.ToString()))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es necesario TipoFactura", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(ClienteId.ToString()))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es necesario ClienteID", "Aceptar");
                return;
            }
      
            FacturaServices data = new FacturaServices();
            var result = data.FacturasSave(Fecha,SubTotal,Descuento,Monto, TipoFacturaId, ClienteId);
            getDatos();
            App.Current.MainPage.Navigation.PushAsync(new FacturasView());
        }
        catch { }
    }
    private void Delete()
    {
        try
        {
            FacturaServices data = new FacturaServices();
            var result = data.DeleteByFacturaID(FacturaID);
            getDatos();
            App.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
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
        try
        {
            if (string.IsNullOrEmpty(FacturaID.ToString()))
            {
                Application.Current.MainPage.DisplayAlert("Aviso", "Por Favor seleccione una categoria valida", "Aceptar");
                return;
            }
            FacturaServices data = new FacturaServices();
            var result = data.FacturasUpdate(FacturaID, Fecha, SubTotal, Descuento, Monto, TipoFacturaId, ClienteId);
            getDatos();
            Application.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
            App.Current.MainPage.Navigation.PushAsync(new FacturasView());
        }
        catch { }
    }
    #endregion

    public FacturasViewModel()
    {
        getDatos();
    }

    private void getDatos()
    {
        FacturaServices data = new FacturaServices();
        Facturas = data.FacturasGet();
    }
}
