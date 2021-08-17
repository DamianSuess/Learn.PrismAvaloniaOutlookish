using System.Collections.ObjectModel;
using SampleApp.Common;
using SampleApp.Modules.Mail.Models;
using SampleApp.Modules.Mail.Services;

namespace SampleApp.Modules.Mail.ViewModels
{
  public class MailViewModel : ViewModelBase
  {
    private IMailService _mailService;

    public MailViewModel(IMailService mailService)
    {
      _mailService = new MailService();
      // _mailService = mailService;
      MailMessages = new ObservableCollection<MailMessage>(_mailService.Messages);
    }

    public string Greeting => "Mail Region";

    public ObservableCollection<MailMessage> MailMessages { get; private set; }
  }
}
