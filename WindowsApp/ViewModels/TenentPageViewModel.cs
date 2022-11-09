﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp.ViewModels
{
    [QueryProperty("Tenent", "Tenent")]
    public partial class TenentPageViewModel : ObservableObject
    {
        [ObservableProperty]
        Tenent tenent;

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
