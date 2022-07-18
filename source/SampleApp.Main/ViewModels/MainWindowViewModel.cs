using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Prism.Commands;
using SampleApp.Common;
using SampleApp.Main.Models;
using MenuItem = SampleApp.Main.Models.MenuItem;

namespace SampleApp.ViewModels
{
  public class MainWindowViewModel : ViewModelBase
  {
    public MainWindowViewModel()
    {
    }

    public string Greeting => "Welcome to Avalonia!";

    public ObservableCollection<MenuItem> MenuItems { get; } = new ObservableCollection<MenuItem>();

    /// <summary>Shutdown classic desktop application.</summary>
    public DelegateCommand<Window> CmdMenuExitAppLifetime => new DelegateCommand<Window>((win) =>
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
    public DelegateCommand<Window> CmdMenuExitWindow => new DelegateCommand<Window>((win) =>
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
  }
}
