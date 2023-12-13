using PracMVVM.Models;
using PracMVVM.Services;
using PracMVVM.Views;
using System;
using System.Windows.Input;

namespace PracMVVM.ViewModels;

public class TipoFacturasViewModel: BaseViewModel
{
    #region Variables locales

    string _TipoFactura;
    int _tipoFacturaId;
    

    List<clsTipoFacturasBE> _TipoFacturas;

    #endregion

    #region Propiedades

    public List<clsTipoFacturasBE> TipoFacturas
    {
        get
        {
            return _TipoFacturas;
        }

        set
        {
            if (_TipoFacturas != value)
            {
                _TipoFacturas = value;

                OnPropertyChanged(nameof(TipoFacturas));
            }
        }
    }

    public string TipoFactura 
    {
        get
        {
            return _TipoFactura;
        }

        set
        {
            if (_TipoFactura != value)
            {
                _TipoFactura = value;

                OnPropertyChanged(nameof(TipoFactura));
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

                OnPropertyChanged(nameof(TipoFacturaId));
            }
        }
    }



    #endregion

    #region Commands

    private ICommand _saveCommand;

    private void MostrarFormulario()
    {
        Application.Current.MainPage.Navigation.PushAsync(new TipoFacturaView());
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
        try
        {
            if (string.IsNullOrEmpty(TipoFactura.ToString()))
            {
                Application.Current.MainPage.DisplayAlert("Aviso", "Es necesario el nombre del TipoFactura", "Aceptar");
                return;
            }

            TipoFacturaServices data = new TipoFacturaServices();
            var result = data.TipoFacturasSave(TipoFactura);
            getDatos();
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
        try
        {
            if (string.IsNullOrEmpty(TipoFacturaId.ToString()))
            {
                Application.Current.MainPage.DisplayAlert("Aviso", "Por Favor seleccione una TipoFactura valida", "Aceptar");
                return;
            }
            TipoFacturaServices data = new TipoFacturaServices();
            var result = data.TipoFacturasUpdate(TipoFacturaId, TipoFactura);
            getDatos();
            Application.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
            App.Current.MainPage.Navigation.PushAsync(new TipoFacturaView());
        }
        catch { }
    }
    #endregion

    public TipoFacturasViewModel()
    {
        getDatos();
    }

    private void getDatos()
    {
        TipoFacturaServices data = new TipoFacturaServices();
        TipoFacturas = data.TipoFacturasGet();
    }
}

