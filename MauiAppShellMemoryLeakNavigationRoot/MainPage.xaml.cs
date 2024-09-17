using System;
using System.Diagnostics;
using Microsoft.Maui.Accessibility;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;

namespace MauiAppShellMemoryLeakNavigationRoot;

public partial class MainPage : ContentPage , IDisposable
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Dispose();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void BtnNextRoot_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            //Shell.Current.GoToAsync("//NewRootPage");
            Shell.Current.GoToAsync("NewStackPage");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }

    public void Dispose()
    {
        Debug.WriteLine("### DISPOSE MainPage ###");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }
}