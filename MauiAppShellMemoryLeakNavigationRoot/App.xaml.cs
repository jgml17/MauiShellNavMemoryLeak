using Microsoft.Maui.Controls;

namespace MauiAppShellMemoryLeakNavigationRoot;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}