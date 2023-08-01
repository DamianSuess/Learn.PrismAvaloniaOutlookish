using SampleApp.Common;
using SampleApp.Services;

namespace SampleApp.Modules.Mail.ViewModels;

public class MailOtherViewModel : ViewModelBase
{
  private IMailService _mailService;

  public MailOtherViewModel(IMailService mailService)
  {
    _mailService = mailService;
  }
}
