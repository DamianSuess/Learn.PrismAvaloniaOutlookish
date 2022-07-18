using System.Collections.Generic;
using System.Collections.ObjectModel;
using SampleApp.Modules.Mail.Models;

namespace SampleApp.Modules.Mail.Services
{
  public class MailService : IMailService
  {
    public IEnumerable<MailMessage> Messages { get; set; } = new ObservableCollection<MailMessage>()
    {
        new MailMessage()
        {
          From = "sample1.name@SuessLabs.com",
          Subject = "Hello Prism.Avalonia",
          Content = "Lorem ipsum does it thing",
        },
        new MailMessage()
        {
          From = "another2@xenoinc.com",
          Subject = "RE: Hello Prism.Avalonia",
          Content = "Lorem ipsum does it thing"
        },
        new MailMessage()
        {
          From = "sample3@SuessLabs.com",
          Subject = "Hello Prism.Avalonia",
          Content = "RE: Lorem ipsum does it thing",
        },
        new MailMessage()
        {
          From = "another4@xenoinc.com",
          Subject = "RE: Hello Prism.Avalonia",
          Content = "Lorem ipsum does it thing"
        },
      };

    public void GetMessages(int messageId)
    {
      throw new System.NotImplementedException();
    }

    public void Send(MailMessage message)
    {
      throw new System.NotImplementedException();
    }
  }
}