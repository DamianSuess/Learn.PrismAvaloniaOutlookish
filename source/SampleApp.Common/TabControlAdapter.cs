using System;
using System.Collections.Specialized;
using System.Linq;
using Avalonia.Controls;
using Prism.Regions;

namespace SampleApp.Common;

/// <summary>
///   Tab Control Adapter for hooking a UserControl as a TabItem
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
      ////// The view navigating away from
      ////foreach (TabItem item in e.RemovedItems)
      ////{
      ////  System.Diagnostics.Debug.WriteLine("Tab Deactivating (View) " + item.Content);
      ////  System.Diagnostics.Debug.WriteLine("Tab Deactivating (ViMd) " + item.DataContext);
      ////  System.Diagnostics.Debug.WriteLine("Tab Deactivating (Tag)  " + item.Tag);
      ////  System.Diagnostics.Debug.WriteLine("Tab Deactivating (Name) " + item.Name);
      ////  //// region.Deactivate(item);
      ////}
      ////
      ////// The view navigating to
      ////// NOTE: Fails when a ListBox item is selected.. it's not a TabItem
      ////foreach (TabItem item in e.AddedItems)
      ////{
      ////  System.Diagnostics.Debug.WriteLine("Tab Activating (View) " + item.Content);
      ////  System.Diagnostics.Debug.WriteLine("Tab Activating (ViMd) " + item.DataContext);
      ////  System.Diagnostics.Debug.WriteLine("Tab Activating (Tag)  " + item.Tag);
      ////  System.Diagnostics.Debug.WriteLine("Tab Activating (Name) " + item.Name);        ////region.Activate(item);
      ////}
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
}
