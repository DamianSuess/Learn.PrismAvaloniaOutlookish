using System;
using System.Reactive.Concurrency;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using ReactiveUI;

namespace SampleApp.Helpers
{
  /// <summary>Notification Helper</summary>
  /// <remarks>
  ///   Reference: https://github.com/zkSNACKs/WalletWasabi/blob/master/WalletWasabi.Fluent/Helpers/NotificationHelpers.cs
  /// </remarks>
  public static class NotificationHelpers
  {
    private const int DefaultNotificationTimeout = 10;
    private static WindowNotificationManager? _notificationManager;

    public static void SetNotificationManager(Window host)
    {
      var notificationManager = new WindowNotificationManager(host)
      {
        Position = NotificationPosition.BottomRight,
        MaxItems = 4,
        Margin = new Thickness(0, 0, 15, 40)
      };

      _notificationManager = notificationManager;
    }

    public static void Show(string title, string message, Action? onClick = null)
    {
      if (_notificationManager is { } nm)
      {
        RxApp.MainThreadScheduler.Schedule(() =>
        {
          nm.Show(
            new Notification(
              title,
              message,
              NotificationType.Information,
              TimeSpan.FromSeconds(DefaultNotificationTimeout),
              onClick));
        });
      }
    }

    public static void Show(object viewModel)
    {
      _notificationManager?.Show(viewModel);
    }
  }
}
