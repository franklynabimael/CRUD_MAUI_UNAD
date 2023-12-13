  using PracMVVM.Models;
using PracMVVM.Services;
using PracMVVM.Views;
using System;
using System.Windows.Input;

namespace PracMVVM.ViewModels;

public class CategoriasViewModel: BaseViewModel
{
    #region Variables locales

    string _categoria;
    int _categoriaId;


    List<ClsCategoriasBE> _Categorias;

    #endregion

    #region Propiedades

    public List<ClsCategoriasBE> Categorias
    {
        get
        {
            return _Categorias;
        }

        set
        {
            if (_Categorias != value)
            {
                _Categorias = value;

                OnPropertyChanged(nameof(Categorias));
            }
        }
    }
    public int CategoriasID
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

                OnPropertyChanged(nameof(CategoriasID));
            }
        }
    }

    public string Categoria 
    {
        get
        {
            return _categoria;
        }

        set
        {
            if (_categoria != value)
            {
                _categoria = value;

                OnPropertyChanged(nameof(Categoria));
            }
        }
    }




    #endregion

    #region Commands

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
            if (string.IsNullOrEmpty(Categoria))
            {
                Application.Current.MainPage.DisplayAlert("Aviso", "Es necesario el nombre del Categoria", "Aceptar");
                return;
            }

            CategoriaServices data = new CategoriaServices();
            var result = data.CategoriasSave(Categoria);
            getDatos();
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
        try
        {
            if (string.IsNullOrEmpty(Categoria))
            {
                Application.Current.MainPage.DisplayAlert("Aviso", "Es necesario el nombre del Categoria", "Aceptar");
                return;
            }
            CategoriaServices data = new CategoriaServices();
            var result = data.CategoriasUpdate(CategoriasID, Categoria);
            getDatos();
            Application.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
            App.Current.MainPage.Navigation.PushAsync(new CategoriasGET());
        }
        catch { }
    }
    #endregion

    public CategoriasViewModel()
    {
        getDatos();
    }

    private void getDatos()
    {
        CategoriaServices data = new CategoriaServices();
        Categorias = data.CategoriasGet();
    }
}

