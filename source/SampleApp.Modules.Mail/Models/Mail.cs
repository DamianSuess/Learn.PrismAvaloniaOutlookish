using System;

namespace SampleApp.Modules.Mail.Models
{
  public class MailMessage
  {
    public string Content { get; set; } = string.Empty;

    public string From { get; set; } = string.Empty;

    public int MailId { get; set; }

    public DateTime ReceivedOn { get; set; } = DateTime.Now;

    public string Subject { get; set; } = string.Empty;
  }
}