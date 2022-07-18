using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SampleApp.Views
{
  public partial class NoticeDialogView : UserControl
  {
    public NoticeDialogView()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
