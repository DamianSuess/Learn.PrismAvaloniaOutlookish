using System;
using System.Collections.Specialized;
using System.Linq;
using Avalonia.Controls;
using Prism.Regions;

namespace SampleApp.Common;

/// <summary>
/// Adapts TabControl's TabItem (content control) to a Prism Region.
/// Tab Control Adapter for hooking tabs to regions. a UserControl as a TabItem
///   * Tab Header: UserControl's `Tag` property
/// </summary>
public class TabControlAdapter : RegionAdapterBase<TabControl>
{
  public TabControlAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
  {
  }

  protected override void Adapt(IRegion region, TabControl regionTarget)
  {
    if (region == null)
      throw new ArgumentNullException(nameof(region));

    if (regionTarget == null)
      throw new ArgumentNullException(nameof(regionTarget));

    regionTarget.SelectionChanged += (object s, SelectionChangedEventArgs e) =>
    {
      // The view navigating away from
      foreach (var item in e.RemovedItems)
      {
        // NOTE: The selected item isn't always a TabItem, if the region contains
        //       a ListBox, it's SelecitonChange gets picked up.
        TargetSelectionChanged("Deactivating", item);
        //// region.Deactivate(item);
      }

      // The view navigating to
      foreach (var item in e.AddedItems)
      {
        TargetSelectionChanged("Activating", item);
        ////region.Activate(item);
      }
    };

    region.Views.CollectionChanged += (s, e) =>
    {
      if (e.Action == NotifyCollectionChangedAction.Add)
      {
        foreach (UserControl item in e.NewItems)
        {
          var items = regionTarget.Items.Cast<TabItem>().ToList();
          items.Add(new TabItem { Header = item.Tag, Content = item });
          regionTarget.Items = items;           // Avalonia v0.10.x
          //// regionTarget.Items.Set(items);   // Avalonia v11
        }
      }
      else if (e.Action == NotifyCollectionChangedAction.Remove)
      {
        foreach (UserControl item in e.OldItems)
        {
          var tabToDelete = regionTarget.Items.OfType<TabItem>().FirstOrDefault(n => n.Content == item);
          // regionTarget.Items.Remove(tabToDelete);  // WPF

          var items = regionTarget.Items.Cast<TabItem>().ToList();
          items.Remove(tabToDelete);
          regionTarget.Items = items;
          //// regionTarget.Items.Set(items);   // Avalonia v11
        }
      }
    };
  }

  protected override IRegion CreateRegion() => new SingleActiveRegion();

  private void TargetSelectionChanged(string changeAction, object itemChanged)
  {
    // The selected item isn't always a TabItem.
    // In some cases, it could be the Region's ListBox item

    TabItem item = itemChanged as TabItem;
    if (item is null)
      return;

    System.Diagnostics.Debug.WriteLine($"Tab {changeAction} (Header):    " + item.Header);
    System.Diagnostics.Debug.WriteLine($"Tab {changeAction} (View):      " + item.Content);
    System.Diagnostics.Debug.WriteLine($"Tab {changeAction} (ViewModel): " + item.DataContext);
  }
}
