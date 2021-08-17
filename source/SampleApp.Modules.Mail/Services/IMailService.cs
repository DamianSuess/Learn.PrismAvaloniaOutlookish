using System.Collections.Generic;
using SampleApp.Modules.Mail.Models;

namespace SampleApp.Modules.Mail.Services
{
  public interface IMailService
  {
    IEnumerable<MailMessage> Messages { get; set; }

    void GetMessages(string folder);

    void Send(MailMessage message);
  }
}