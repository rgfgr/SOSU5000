using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApp.Services.Interfaces;

namespace WindowsApp.ViewModels
{
    [QueryProperty("Id", "Id")]
    public partial class TenentPageViewModel : ObservableObject
    {
        IAssignmentService _assignmentService;

        public TenentPageViewModel(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
            Assignments = new();
        }

        [ObservableProperty]
        int id;

        [ObservableProperty]
        ObservableCollection<Assignment> assignments;

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
