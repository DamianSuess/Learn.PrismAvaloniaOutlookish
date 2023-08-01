using SampleApp.Common.Models;

namespace SampleApp.Services;

public interface IMailService
{
  IEnumerable<MailMessage> Messages { get; set; }

  void GetMessages(int messageId);

  void Send(MailMessage message);
}
