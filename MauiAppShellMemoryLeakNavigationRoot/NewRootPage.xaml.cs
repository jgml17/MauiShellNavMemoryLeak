using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;

namespace MauiAppShellMemoryLeakNavigationRoot;

public partial class NewRootPage : ContentPage, IDisposable
{
    public NewRootPage()
    {
        InitializeComponent();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Dispose();
    }
    
    private void BtnNextPageStack_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            Shell.Current.GoToAsync("NewStackPage");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }

    public void Dispose()
    {
        Debug.WriteLine("### DISPOSE NewRootPage ###");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }
}