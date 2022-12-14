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
    public partial class AssignmentPageViewModel : ObservableObject
    {
        IAssignmentService assignmentService;

        public AssignmentPageViewModel(IAssignmentService assignmentService)
        {
            this.assignmentService = assignmentService;
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
        async Task Save(string comp)
        {
            if (bool.Parse(comp))
            {
                if (SosuId.Length != 4)
                {
                    return;
                }
                Assignment.Completed = true;
                Assignment.SosuId = SosuId;
            }
            await assignmentService.SaveAssignment(Assignment);
            await GoBack();
        }

        internal async Task Loaded()
        {
            Assignment = await assignmentService.GetAssignment(Id);
        }
    }
}
