using System.Collections.ObjectModel;
using SampleApp.Modules.Mail.Models;
using SampleApp.Modules.Mail.Services;

namespace SampleApp.Modules.Mail.ViewModels
{
  public class MailViewViewModel : ViewModelBase
  {
    private IMailService _mailService;

    public MailViewViewModel()
    {
      _mailService = new MailService();
      MailMessages = new ObservableCollection<MailMessage>(_mailService.Messages);
    }

    public string Greeting => "Mail Region";

    public ObservableCollection<MailMessage> MailMessages { get; private set; }
  }
}
