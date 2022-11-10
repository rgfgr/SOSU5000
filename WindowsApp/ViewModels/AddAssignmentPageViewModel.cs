using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApp.Services.Interfaces;

namespace WindowsApp.ViewModels
{
    [QueryProperty("Id", "Id")]
    public partial class AddAssignmentPageViewModel : ObservableObject
    {
        IAssignmentService assignmentService;

        public AddAssignmentPageViewModel(IAssignmentService assignmentService)
        {
            this.assignmentService = assignmentService;
            Assignment = new();
        }

        [ObservableProperty]
        Assignment assignment;

        [ObservableProperty]
        int id;

        [ObservableProperty]
        string sosuId;

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task Save()
        {
            Assignment.TenentId = Id;
            await assignmentService.AddAssignment(Assignment);
            await GoBack();
        }
    }
}
