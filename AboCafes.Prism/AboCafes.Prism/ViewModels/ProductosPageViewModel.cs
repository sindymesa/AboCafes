using AboCafes.Common.Entities;
using AboCafes.Common.Responses;
using AboCafes.Common.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Essentials;

namespace AboCafes.Prism.ViewModels
{
    public class ProductosPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<Producto> _productos;

        public ProductosPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Productos";
            LoadProductsAsync();
        }

        public ObservableCollection<Producto> Productos
        {
            get => _productos;
            set => SetProperty(ref _productos, value);
        }

        private async void LoadProductsAsync()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Check the internet connection.", "Accept");
                return;
            }

            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetListAsync<Producto>(
                url,
                "/api",
                "/Productos");

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            List<Producto> myProducts = (List<Producto>)response.Result;
            Productos = new ObservableCollection<Producto>(Productos);
        }
    }
}
