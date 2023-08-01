using System.Collections.ObjectModel;
using SampleApp.Common.Models;

namespace SampleApp.Services;

public class MailService : IMailService
{
  public IEnumerable<MailMessage> Messages { get; set; } = new ObservableCollection<MailMessage>()
  {
      new MailMessage()
      {
        MailId = 1,
        From = "sample1.name@SuessLabs.com",
        Subject = "Hello Prism.Avalonia",
        Content = "Lorem ipsum does it thing",
      },
      new MailMessage()
      {
        MailId = 2,
        From = "another2@xenoinc.com",
        Subject = "RE: Hello Prism.Avalonia",
        Content = $"Lorem ipsum does it thing.{Environment.NewLine}Reply From: another2{Environment.NewLine}I'm replying back"
      },
      new MailMessage()
      {
        MailId = 3,
        From = "sample3@SuessLabs.com",
        Subject = "Hello Prism.Avalonia",
        Content = "Lovely day using Prism.Avalonia isn't it?",
      },
      new MailMessage()
      {
        MailId = 4,
        From = "another4@xenoinc.com",
        Subject = "RE: Hello Prism.Avalonia",
        Content = $"Lovely day using Prism.Avalonia isn't it?{Environment.NewLine}Reply From: another4{Environment.NewLine}I'm replying back"
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
