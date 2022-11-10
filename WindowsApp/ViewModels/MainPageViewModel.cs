using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Entities;
using WindowsApp.Services.Interfaces;
using System.Collections.ObjectModel;
using WindowsApp.Views;

namespace WindowsApp.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        ITenentService tenentService;

        public MainPageViewModel(ITenentService tenentService)
        {
            this.tenentService = tenentService;
            Tenents = new();
        }

        [ObservableProperty]
        ObservableCollection<Tenent> tenents;

        [RelayCommand]
        public async Task Tap(int id)
        {
            await Shell.Current.GoToAsync($"{nameof(TenentPage)}?Id={id}");
        }

        public async Task Loaded()
        {
            List<Tenent> tempTenents = await tenentService.GetAllTenents();
            tempTenents.ForEach(t => Tenents.Add(t));
        }
    }
}