using WindowsApp.Services;
using WindowsApp.Services.Interfaces;
using WindowsApp.Sevices;
using WindowsApp.ViewModels;
using WindowsApp.Views;

namespace WindowsApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ITenentService, TenentService>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();

            builder.Services.AddTransient<IAssignmentService, AssignmentService>();
            builder.Services.AddTransient<TenentPage>();
            builder.Services.AddTransient<TenentPageViewModel>();

            return builder.Build();
        }
    }
}