using System.Collections.ObjectModel;
using SampleApp.Common;
using SampleApp.Main.Models;

namespace SampleApp.ViewModels
{
  public class MainWindowViewModel : ViewModelBase
  {
    public MainWindowViewModel()
    {
    }

    public string Greeting => "Welcome to Avalonia!";

    public ObservableCollection<MenuItem> MenuItems { get; } = new ObservableCollection<MenuItem>();
  }
}
