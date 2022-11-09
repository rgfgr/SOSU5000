using WindowsApp.Views;

namespace WindowsApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TenentPage), typeof(TenentPage));
        }
    }
}