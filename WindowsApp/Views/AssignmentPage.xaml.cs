using WindowsApp.ViewModels;

namespace WindowsApp.Views;

public partial class AssignmentPage : ContentPage
{
	AssignmentPageViewModel vm;
	public AssignmentPage(AssignmentPageViewModel vm)
	{
		InitializeComponent();
		this.vm = vm;
		BindingContext = vm;
	}

	private void Window_Loaded(object sender, EventArgs e)
	{
		await vm.Loaded();
	}
}