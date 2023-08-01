using System.Collections.ObjectModel;
using SampleApp.Common;
using SampleApp.Common.Models;
using SampleApp.Services;

namespace SampleApp.Modules.Mail.ViewModels;

public class MailFocusedViewModel : ViewModelBase
{
  private IMailService _mailService;

  public MailFocusedViewModel(IMailService mailService)
  {
    _mailService = mailService;

    MailMessages = new ObservableCollection<MailMessage>(_mailService.Messages);
  }

  public ObservableCollection<MailMessage> MailMessages { get; private set; }
}
