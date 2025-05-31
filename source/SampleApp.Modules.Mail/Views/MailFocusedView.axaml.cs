using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SampleApp.Modules.Mail.Views;

public partial class MailFocusedView : UserControl
{
  public MailFocusedView()
  {
    InitializeComponent();
  }

  private void InitializeComponent()
  {
    AvaloniaXamlLoader.Load(this);
  }
}
