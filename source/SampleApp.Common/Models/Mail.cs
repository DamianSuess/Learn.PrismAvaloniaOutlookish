using System;
using Prism.Mvvm;

namespace SampleApp.Common.Models;

public class MailMessage : BindableBase
{
  private string _body = string.Empty;
  private DateTime _dateSent = DateTime.Now;
  private string _from = string.Empty;
  private string _subject = string.Empty;
  private string _to = string.Empty;

  public string Content { get => _body; set => SetProperty(ref _body, value); }

  public string From { get => _from; set => SetProperty(ref _from, value); }

  public int MailId { get; set; }

  public DateTime ReceivedOn { get => _dateSent; set => SetProperty(ref _dateSent, value); }

  public string Subject { get => _subject; set => SetProperty(ref _subject, value); }
}