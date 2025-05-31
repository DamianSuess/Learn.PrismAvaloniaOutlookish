using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Prism.Commands;
//using Prism.Services.Dialogs;
using Prism.Dialogs;
using SampleApp.Common;
using SampleApp.Views;
using MenuItem = SampleApp.Main.Models.MenuItem;

namespace SampleApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
  private readonly IDialogService _dialogService;

  public MainWindowViewModel(IDialogService dialogService)
  {
    _dialogService = dialogService;
  }

  /// <summary>Shutdown classic desktop application.</summary>
  public DelegateCommand<Window> CmdMenuExitAppLifetime => new((Window win) =>
  {
    // NOTE:
    //  We configured the app as a Classic Desktop Lifetime
    //    `public static void Main(string[] args) => BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);`
    if (Avalonia.Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
    {
      desktopLifetime.Shutdown();
    }
    else
    {
      System.Console.WriteLine("Shut down application issue..");
      System.Diagnostics.Debugger.Break();
    }
  });

  /// <summary>Close app by closing window.</summary>
  public DelegateCommand<Window> CmdMenuExitWindow => new((Window win) =>
  {
    // Configuration:
    //  In the `.axml` set the window name ` x:Name="MainShellWindow"`
    //  and pass the Window in as a CommandParameter
    //
    // NOTE:
    //  This doesn't take into account other opened windows
    //  Ideally, you should check for other opened windows and close them all out.
    //
    //  One method is to perform a Prism Event Notification to all the views to 'CloseWindow'
    //  and perform the same action below.

    win?.Close();
  });

  public DelegateCommand<string> CmdShowDialog => new((string param) =>
  {
    var title = "Menu Item Clicked";
    var messg = $"You clicked the {param} button";

    _dialogService.ShowDialog(
      nameof(MessageBoxView),
      new DialogParameters($"title={title}&message={messg}"),
      result => { });
  });

  public string Greeting => "Welcome to Avalonia!";

  public ObservableCollection<MenuItem> MenuItems { get; } = new ObservableCollection<MenuItem>();
}
