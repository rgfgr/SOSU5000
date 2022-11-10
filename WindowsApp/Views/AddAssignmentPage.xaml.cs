using WindowsApp.ViewModels;

namespace WindowsApp.Views;

public partial class AddAssignmentPage : ContentPage
{
	public AddAssignmentPage(AddAssignmentPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}