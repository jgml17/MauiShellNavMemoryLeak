using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MauiAppShellMemoryLeakNavigationRoot;

public partial class NewStackPage : ContentPage, IDisposable
{
    public NewStackPage()
    {
        InitializeComponent();
    }
    
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Dispose();
    }
    
    private void Button_Back_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            // Shell.Current.GoToAsync("//NewRootPage");
            Shell.Current.GoToAsync("//MainPage");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
    
    private void Button_New_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            Shell.Current.GoToAsync("//NewRootPage");
            // Shell.Current.GoToAsync("//MainPage");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
    
    public void Dispose()
    {
        Debug.WriteLine("### DISPOSE NewStackPage ###");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }
    
}