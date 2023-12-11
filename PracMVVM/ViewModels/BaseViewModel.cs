using System;
using System.Runtime.CompilerServices;

namespace PracMVVM.ViewModels
{
    public class BaseViewModel
    {
        public event PropertyChangingEventHandler PropertyChange;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChange?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }
    }
}

