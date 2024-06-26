﻿using PracMVVM.Models;
using PracMVVM.Services;
using PracMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracMVVM.ViewModels;

internal class ProductosViewModels : BaseViewModel
{
    #region Variables locales

    string _producto;
    int _productoId;
    float _costo;
    float _cantidad;
    float _precio;
    int _categoriaId;

    List<clsProductosBE> _Productos;

    #endregion

    #region Propiedades

    public List<clsProductosBE> Productos
    {
        get
        {
            return _Productos;
        }

        set
        {
            if (_Productos != value)
            {
                _Productos = value;

                this.OnPropertyChanged(nameof(Productos));
            }
        }
    }

    public string Producto
    {
        get
        {
            return _producto;
        }

        set
        {
            if (_producto != value)
            {
                _producto = value;

                this.OnPropertyChanged(nameof(Producto));
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

                this.OnPropertyChanged(nameof(_productoId));
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

    public int CategoriaID
    {
        get
        {
            return _categoriaId;
        }

        set
        {
            if (_categoriaId != value)
            {
                _categoriaId = value;

                this.OnPropertyChanged(nameof(CategoriaID));
            }
        }
    }

    #endregion

    private void MostrarFormulario()
    {
        App.Current.MainPage.Navigation.PushAsync(new ProductosView());
    }


    private ICommand _saveCommand;
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
            if (string.IsNullOrEmpty(Producto))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es necesario el nombre del Producto", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(Costo.ToString()))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es necesario el apellido del Producto", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(Cantidad.ToString()))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es necesario la direccion del Producto", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(Precio.ToString()))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es necesario el telefono del Producto", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(CategoriaID.ToString()))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Es necesario la ciudad del Producto", "Aceptar");
                return;
            }

            ProductoServices data = new ProductoServices();
            var result = data.ProductosSave(Producto, Costo, Cantidad, Precio, CategoriaID);
            getDatos();
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
        try
        {
            if (string.IsNullOrEmpty(CategoriaID.ToString()))
            {
                Application.Current.MainPage.DisplayAlert("Aviso", "Por Favor seleccione una categoria valida", "Aceptar");
                return;
            }
            ProductoServices data = new ProductoServices();
            var result = data.ProductosUpdate( ProductoId, Producto, Costo, Cantidad, Precio, CategoriaID);
            getDatos();
            Application.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
            App.Current.MainPage.Navigation.PushAsync(new ProductosView());
        }
        catch { }
    }

    public ProductosViewModels()
    {
        getDatos();
    }

    private void getDatos()
    {
        ProductoServices data = new ProductoServices();
        Productos = data.ProductosGet();
    }
}

