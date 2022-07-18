using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace SampleApp.ViewModels
{
  public class NoticeDialogViewModel : BindableBase, IDialogAware
  {
    private string _title = "";
    private string _message = "This feature is not implemented";

    public NoticeDialogViewModel()
    {
      Title = "Notice";
    }

    public event Action<IDialogResult>? RequestClose;

    public DelegateCommand<string> CmdResult => new DelegateCommand<string>((param) =>
    {
      RaiseRequestClose(new DialogResult(ButtonResult.OK));
    });

    public string Message
    {
      get => _message;
      set => SetProperty(ref _message, value);
    }

    public string Title
    {
      get => _title;
      set => SetProperty(ref _title, value);
    }

    public bool CanCloseDialog()
    {
      return true;
    }

    public void OnDialogClosed()
    {
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
      // Title = parameters.GetValue<string>("title");
      Message = parameters.GetValue<string>("message");
    }

    public virtual void RaiseRequestClose(IDialogResult dialogResult)
    {
      RequestClose?.Invoke(dialogResult);
    }
  }
}
