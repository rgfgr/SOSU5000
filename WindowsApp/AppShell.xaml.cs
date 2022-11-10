using WindowsApp.Views;

namespace WindowsApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TenentPage), typeof(TenentPage));
            Routing.RegisterRoute(nameof(AssignmentPage), typeof(AssignmentPage));
            Routing.RegisterRoute(nameof(AddAssignmentPage), typeof(AddAssignmentPage));
        }
    }
}