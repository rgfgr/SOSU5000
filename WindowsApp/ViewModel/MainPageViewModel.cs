using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Entities;
using Services.Interfaces;
using System.Collections.ObjectModel;
using Microsoft.Maui.Graphics

namespace ViewModel
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
        public async Task Tap(Tenent tenent)
        {
            await Shell.Current.GoToAsync($"{nameof(TenentPage)}?Tenent={tenent}");
        }

        public async Task Window_Loaded()
        {
            List<Tenent> tempTenents = await tenentService.GetAllTenents();
            tempTenents.ForEach(t => Tenents.Add(t));
        }
    }
}