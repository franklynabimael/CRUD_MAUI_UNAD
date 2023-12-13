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
    public class ClientesViewModel : BaseViewModel
    {
        #region Variables locales

        string _nombres;
        string _direccion;
        string _telefonos;
        int _clienteId;
        

        List<clsClientesBE> _Clientes;

        #endregion

        #region Propiedades

        public List<clsClientesBE> Clientes
        {
            get
            {
                return _Clientes;
            }

            set
            {
                if (_Clientes != value)
                {
                    _Clientes = value;

                    this.OnPropertyChanged(nameof(Clientes));
                }
            }
        }

        public string Nombres
        {
            get
            {
                return _nombres;
            }

            set
            {
                if (_nombres != value)
                {
                    _nombres = value;

                    this.OnPropertyChanged(nameof(Nombres));
                }
            }
        }

       

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                if (_direccion != value)
                {
                    _direccion = value;

                    this.OnPropertyChanged(nameof(Direccion));
                }
            }
        }

        public string Telefonos
        {
            get
            {
                return _telefonos;
            }

            set
            {
                if (_telefonos != value)
                {
                    _telefonos = value;

                    this.OnPropertyChanged(nameof(Telefonos));
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



    #endregion

    #region Commands

    private ICommand _saveCommand;
        private ICommand _deleteCommand;

        private void MostrarFormulario()
        {
            App.Current.MainPage.Navigation.PushAsync(new ClientesView());
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
                if (string.IsNullOrEmpty(Nombres))
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "Es necesario el nombre del Cliente", "Aceptar");
                    return;
                }

                if (string.IsNullOrEmpty(Direccion))
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "Es necesario la direccion del Cliente", "Aceptar");
                    return;
                }

                if (string.IsNullOrEmpty(Telefonos))
                {
                    App.Current.MainPage.DisplayAlert("Aviso", "Es necesario el telefono del Cliente", "Aceptar");
                    return;
                }

          

            ClienteServices data = new ClienteServices();
             var result = data.ClientesSave(Nombres, Direccion, Telefonos);
            getDatos();
          
            App.Current.MainPage.Navigation.PushAsync(new ClientesGet());
        }
            catch { }
        }
    private void Delete()
    {
        try
        {
            ClienteServices data = new ClienteServices();
            var result = data.DeleteByClienteID(ClienteId);
            getDatos();
           App.Current.MainPage.Navigation.PushAsync(new ClientesView());
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
            ClienteServices data = new ClienteServices();
            var result = data.ClientesUpdate(ClienteId, Nombres, Direccion, Telefonos);
            getDatos();
            Application.Current.MainPage.DisplayAlert("Aviso", result, "Aceptar");
            App.Current.MainPage.Navigation.PushAsync(new ClientesGet());
        }
        catch { }
    }
    #endregion

    public ClientesViewModel()
        {
            getDatos();
        }

        private void getDatos()
        {
        ClienteServices data = new ClienteServices();
            Clientes = data.ClientesGet();
        }
    }
