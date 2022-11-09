using WindowsApp.ViewModels;

namespace WindowsApp.Views
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm;
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;

            BindingContext = this.vm;
        }

        private async void Window_Loaded(object sender, EventArgs e)
        {
            await vm.Loaded();
        }
    }
}