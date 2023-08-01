using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SampleApp.Modules.Mail.Views;

public partial class MailOtherView : UserControl
{
  public MailOtherView()
  {
    InitializeComponent();
  }

  private void InitializeComponent()
  {
    AvaloniaXamlLoader.Load(this);
  }
}
