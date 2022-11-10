using CommunityToolkit.Mvvm.ComponentModel;
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

        internal async Task Loaded()
        {
            Assignment = await assignmentService.GetAssignment(Id);
        }
    }
}
