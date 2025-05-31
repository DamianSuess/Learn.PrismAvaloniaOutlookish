# Learn Prism.Avalonia with Outlookish

Cross-platform Prism.Avalonia Outlookish sample application featuring a 4-panel application using external modules, and Avalonia Notifications.  This app helps get your feet wet using AvaloniaUI with [Prism.Avalonia](https://github.com/AvaloniaCommunity/Prism.Avalonia) v8.1.97!

To enjoy more Prism samples, check out my [Learn Prism](https://github.com/DamianSuess/Learn.PrismLibrary) repository to expore more about using Prism with Xamarin.Forms, MAUI, UNO, WPF, and Avalonia.

Author: [Damian Suess](https://www.linkedin.com/in/damiansuess/)<br />
Website: [suesslabs.com](https://suesslabs.com)

The screenshot below shows usage of the Prism's Region Manager, Modules, Dialogs and Notifications in action!

![Screen Shot](Sample-Outlookish-Annotated.png)

## Tech Stack

This project uses the following technologies:

* .NET 6
* [Avalonia](https://github.com/AvaloniaUI/Avalonia)
* [Prism.Avalonia](https://github.com/AvaloniaCommunity/Prism.Avalonia)
  * **Dialog Service** as a Message Box
  * **Notification** pop-ups
  * **Prism Modules**
  * **TabControlAdapter** - _Register a View as a TabItem using Prism's Region Navigation_
    * The `UserControl` `Tag` property is used as the _TabItem's Header_
  * Exiting the main window in 2 flavors
* WSL 2 - _with X11 rendering on Windows_
  * Execute using either Windows or Linux via WSL
* [CodeDevOps](https://github.com/xenoinc/CodeDevOps) - _.NET code styling ruleset_.

### Special Thanks

First off, I'd like to give a shout out to the following folks for taking the time to put together the basis for this exercise.

* [PrismLibrary](https://prismlibrary.com/) - Forged from from Microsoft PnP "Patterns and practices" team.
* [Prism.Avalonia](https://github.com/AvaloniaCommunity/Prism.Avalonia)
* [Prism Outlook](https://github.com/brianlagunas/PrismOutlook)
* [AvaloniaMvvm](https://github.com/mouadcherkaoui/AvaloniaMvvm-prism)

## Avalonia Notifications

To access Avalonia's Notification pop-ups, there are currently 2 methods used in this sample codebase. 1st one is Dependency Inejection and the 2nd is to use a `static class`.

You can't use the notification window right away. Ref: [https://github.com/AvaloniaUI/Avalonia/issues/5442]

Another methodology (_not outlined here_) is to create a View `Behavior` so that the `WindowNotificationManager` can be registered via XAML in our View, `MainWindow.axml`. This method is currently being used by [Wasabi Wallett](https://github.com/zkSNACKs/WalletWasabi/blob/master/WalletWasabi.Fluent/Views/MainWindow.axaml).

### Method 1 - ViewModel Dependency Injection

To enhance this in the future we could create a `NotificationService` service via Prism DI.

1. Wire-up the INotificationService in the `App.axml.cs`
2. Configure notifications in the `MainWindow.axml.cs`'s constructor.
   1. all our `NotificationService.SetHostWindow(this);`
   2. This can be done via accessing Prism's IContainerRegistry from the `MainWindow.axml.cs` file
3. Next, add `INotificationService` to the desired ViewModel's constructor
4. Finally, call the service
   1. `_notificationService.Show("title", "message here");`
   2. `_notificationService.Show("title", "message here", () => { ... });`

Step 2) `MainWindow.axml.cs`

```cs
public MainWindow()
{
    InitializeComponent();

    // Access the Container's INotificationService and configure our Host Window
    var notifyService = ContainerLocator.Current.Resolve<INotificationService>();
    notifyService.SetHostWindow(this);
}
```

Step 3) `DashboardViewModel.cs`

```cs
  public class DashboardViewModel : ViewModelBase
  {
    private readonly INotificationService _notificationService;

    public DashboardViewModel(INotificationService notifyService)
    {
      _notificationService = notifyService;
    }

    public DelegateCommand CmdTestNotification => new DelegateCommand(() =>
    {
      _notificationService.Show("Hello 2", "I'm from DI Service!");
    });
  }
```

Interface:

```cs
// INotificationService.cs
public interface INotificationService
{
    int NotificationTimeout { get; set; }
    void SetHostWindow(Window window);
    void Show(string title, string message, Action? onClick = null);
}
```

### Method 2 - Static Class

In the `static class` methodology, you can access the Notification pop-ups via the `NotificationHelpers` class. This way, you don't have wire up any DI Services. Simply configure in the MainWindow's constructor and call it from anywhere.

```cs
// MainWindow.axml.cs
public MainWindow()
{
    InitializeComponent();
    NotificationHelpers.SetNotificationManager(this);
}
```

To call the pop-up notifications in your ViewModel simple perform the following:

```cs
// DashboardViewModel.cs
public DelegateCommand CmdTestNotification => new DelegateCommand(() =>
{
  NotificationHelpers.Show("Hello", "Im a message", () =>
  {
    // Some action to take when the Notification is clicked
    //  i.e.
    // _dialogService.ShowDialog(nameof(MessageBoxView));
  });
});
```

## AvaloniaUI

Avalonia-ui is a library that gives WPFs like features designed to run cross platform by using platform detection and switching to use platform specific apis to be able to render the ui and its components, for example at startup the project detects if the application is running in a linux environment with a X Window System X11 "graphic protocol" at a low level and for example GTK+ or QT "graphical components libraries" at a higher level, the avalonia switch to using the X11 apis to render its components.

### Avalonia Deep-Dive

Lets take a look to the code for integrating avalonia in a dotnet project:

```csharp
public static AppBuilder BuildAvaloniaApp()
    => AppBuilder.Configure<App>()
        .UsePlatformDetect()
        .LogToTrace()
        .UseReactiveUI();
```

This method simply uses the app builder extension methods to configure the application, and one of the extensions method is `.UsePlatformDetect()` if we check the code of this method on github:

```csharp
public static TAppBuilder UsePlatformDetect<TAppBuilder>(this TAppBuilder builder)
    where TAppBuilder : AppBuilderBase<TAppBuilder>, new()
{
    var os = builder.RuntimePlatform.GetRuntimeInfo().OperatingSystem;

    // We don't have the ability to load every assembly right now, so we are
    // stuck with manual configuration  here
    // Helpers are extracted to separate methods to take the advantage of the fact
    // that CLR doesn't try to load dependencies before referencing method is jitted
    // Additionally, by having a hard reference to each assembly,
    // we verify that the assemblies are in the final .deps.json file
    //  so .NET Core knows where to load the assemblies from,.
    if (os == OperatingSystemType.WinNT)
    {
        LoadWin32(builder);
        LoadSkia(builder);
    }
    else if(os==OperatingSystemType.OSX)
    {
        LoadAvaloniaNative(builder);
        LoadSkia(builder);
    }
    else
    {
        LoadX11(builder);
        LoadSkia(builder);
    }
    return builder;
}
```

The code checks the current operating system and based on the result loads the specific libraries for the detected platform.

```csharp
static void LoadAvaloniaNative<TAppBuilder>(TAppBuilder builder)
    where TAppBuilder : AppBuilderBase<TAppBuilder>, new()
        => builder.UseAvaloniaNative();

static void LoadWin32<TAppBuilder>(TAppBuilder builder)
    where TAppBuilder : AppBuilderBase<TAppBuilder>, new()
        => builder.UseWin32();

static void LoadX11<TAppBuilder>(TAppBuilder builder)
    where TAppBuilder : AppBuilderBase<TAppBuilder>, new()
        => builder.UseX11();

static void LoadDirect2D1<TAppBuilder>(TAppBuilder builder)
    where TAppBuilder : AppBuilderBase<TAppBuilder>, new()
        => builder.UseDirect2D1();

static void LoadSkia<TAppBuilder>(TAppBuilder builder)
    where TAppBuilder : AppBuilderBase<TAppBuilder>, new()
        => builder.UseSkia();
```

In our previous example the builder detects that it is not running under Windows or macOS and then switch to load X11 and Skia libraries, from here the program will use the exposed apis from the Avalonia.X11.dll assembly:

```csharp
public static void InitializeX11Platform(X11PlatformOptions options = null)
{
    (new AvaloniaX11Platform()).Initialize(options ?? new X11PlatformOptions());
}

public static T UseX11<T>(this T builder)
where T : AppBuilderBase<T>, new()
{
    builder.UseWindowingSubsystem(() => (new AvaloniaX11Platform()).Initialize(AvaloniaLocator.Current.GetService<X11PlatformOptions>() ?? new X11PlatformOptions()), "");
    return builder;
}
```

The same way the Avalonia framework allows us to use specific UI mechanisms based on the detected platform.

## Upcoming Releases

* Upgrade to Avalonia v11.1 with Prism v9.0-pre

### Future Considerations

* Demonstrate page navigation with parameters - _use a `MockEmails` class to pass in EmailId and `OnNavigatedTo()` get email from `MailService`_
  * Include successful navigation
  * Include failed navigation (i.e. invalid EmailId)
  * Use Prism's 'Navigation Journaling
* Populate the footer using Prism Events
* Add icon glyphs via Styles
* Sidebar Panel - Simple sidebar with stages
* Flyout menu -  Alternative sidebar using Grids
