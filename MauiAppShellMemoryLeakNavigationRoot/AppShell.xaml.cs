using Microsoft.Maui.Controls;

namespace MauiAppShellMemoryLeakNavigationRoot;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute("MainPage", typeof(MainPage));
        Routing.RegisterRoute("NewRootPage", typeof(NewRootPage));
        Routing.RegisterRoute("NewStackPage", typeof(NewStackPage));
    }
}