using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Dialogs;

namespace SampleApp.ViewModels;

public class MessageBoxViewModel : BindableBase, IDialogAware
{
  private int _maxHeight;
  private int _maxWidth;
  private string _message = "This feature is not implemented";
  private string _title = "Notice";

  public MessageBoxViewModel()
  {
    Title = "Notice";

    MaxHeight = 800;
    MaxWidth = 600;
  }

  public DialogCloseListener RequestClose { get; }

  public DelegateCommand<string> CmdResult => new((string buttonResult) =>
  {
    // Dialog's ButtonResult types:
    // None = 0
    // OK = 1
    // Cancel = 2
    // Abort = 3
    // Retry = 4
    // Ignore = 5
    // Yes = 6
    // No = 7
    ButtonResult result = ButtonResult.OK;

    if (int.TryParse(buttonResult, out int intResult))
      result = (ButtonResult)intResult;

    RaiseRequestClose(new DialogResult(result));
  });

  public int MaxHeight { get => _maxHeight; set => SetProperty(ref _maxHeight, value); }

  public int MaxWidth { get => _maxWidth; set => SetProperty(ref _maxWidth, value); }

  public string Message { get => _message; set => SetProperty(ref _message, value); }

  public string Title { get => _title; set => SetProperty(ref _title, value); }

  public bool CanCloseDialog()
  {
    return true;
  }

  public void OnDialogClosed()
  {
  }

  public void OnDialogOpened(IDialogParameters parameters)
  {
    var title = parameters.GetValue<string>("title");
    if (!string.IsNullOrEmpty(title))
      Title = title;

    Message = parameters.GetValue<string>("message");
  }

  public virtual void RaiseRequestClose(IDialogResult dialogResult)
  {
    RequestClose.Invoke(dialogResult);
  }
}
