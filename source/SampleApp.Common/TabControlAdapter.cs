using System.Collections.Specialized;
using System.Linq;
using Avalonia.Controls;
using Prism.Regions;

namespace SampleApp.Common;

public class TabControlAdapter : RegionAdapterBase<TabControl>
{
  public TabControlAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
  {
  }

  protected override void Adapt(IRegion region, TabControl regionTarget)
  {
    region.Views.CollectionChanged += (s, e) =>
    {
      if (e.Action == NotifyCollectionChangedAction.Add)
      {
        foreach (IControl item in e.NewItems)
        {
          // TODO: Use 'Title' from the View.
          var items = regionTarget.Items.Cast<TabItem>().ToList();
          items.Add(new TabItem { Header = item.Name, Content = item });
          regionTarget.Items = items;           // Avalonia v0.10.x
          //// regionTarget.Items.Set(items);   // Avalonia v11
        }
      }
      else if (e.Action == NotifyCollectionChangedAction.Remove)
      {
        foreach (IControl item in e.OldItems)
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
