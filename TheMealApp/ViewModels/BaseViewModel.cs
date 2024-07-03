using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TheMealApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotLoading))]
        public bool isLoading;
        public bool IsNotLoading => !isLoading;
    }
}

