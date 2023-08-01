using System;
using System.Collections.ObjectModel;
using Prism;
using Prism.Regions;
using SampleApp.Common;
using SampleApp.Common.Models;
using SampleApp.Services;

namespace SampleApp.Modules.Mail.ViewModels;

public class MailFocusedViewModel : ViewModelBase, IActiveAware
{
  private bool _isActive;
  private IMailService _mailService;

  public MailFocusedViewModel(IMailService mailService)
  {
    _mailService = mailService;
    MailMessages = new ObservableCollection<MailMessage>(_mailService.Messages);
  }

  public event EventHandler IsActiveChanged;

  /// <summary>This never gets hit, Xamarin.Forms only..</summary>
  public bool IsActive
  {
    get => _isActive;
    set => SetProperty(ref _isActive, value, RaiseIsActiveChanged);
  }

  public ObservableCollection<MailMessage> MailMessages { get; private set; }

  protected virtual void RaiseIsActiveChanged()
  {
    IsActiveChanged?.Invoke(this, EventArgs.Empty);
  }
}
