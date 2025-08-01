using CommunityToolkit.Mvvm.ComponentModel;
using ExpanderCollectionView.Models.ExpanderHeader;
using ExpanderCollectionView.Services;
using System.Collections.ObjectModel;
using System.Reflection;

namespace ExpanderCollectionView.ViewModels
{
    public class ListCollectionViewModel<T> : ObservableObject, IListCollectionViewModel
    {
        public ObservableCollection<ExpanderHeader> DisplayItems { get; } = new();

        public ListCollectionViewModel(IEnumerable<T> sourceItems)
        {
            LoadData(sourceItems);
        }

        private void LoadData(IEnumerable<T> sourceItems)
        {
            DisplayItems.Clear();

            foreach (var item in sourceItems)
            {
                var itemType = item.GetType();
                var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                var headerDict = new Dictionary<string, object>();
                foreach (var key in new[] { "ID", "Name", "PendingState" })
                {
                    var prop = props.FirstOrDefault(p => p.Name == key);
                    if (prop != null)
                        headerDict[key] = prop.GetValue(item) ?? "";
                }

                // Lazy delegate برای محتوای داخلی
                Func<Dictionary<string, object>> lazyDetails = () =>
                {
                    var contentDict = props
                        .Where(p => p.Name != "ID" && p.Name != "Name" && p.Name != "PendingState")
                        .ToDictionary(p => p.Name, p => p.GetValue(item) ?? "");
                    return contentDict;
                };

                DisplayItems.Add(new ExpanderHeader
                {
                    HeaderFields = headerDict,
                    LazyDetails = lazyDetails
                });
            }
        }
    }
}
