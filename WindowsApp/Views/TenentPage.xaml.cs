using WindowsApp.ViewModels;

namespace WindowsApp.Views;

public partial class TenentPage : ContentPage
{
	public TenentPage(TenentPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}