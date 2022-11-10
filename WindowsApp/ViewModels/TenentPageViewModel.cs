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
using WindowsApp.Views;

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

        [RelayCommand]
        async Task Tap(int id)
        {
            await Shell.Current.GoToAsync($"{nameof(AssignmentPage)}?Id={id}");
        }

        internal async Task Loaded()
        {
            var tempAssignments = await _assignmentService.GetAssignmentsByTenent(Id);
            tempAssignments.ForEach(s => Assignments.Add(s));
        }
    }
}
