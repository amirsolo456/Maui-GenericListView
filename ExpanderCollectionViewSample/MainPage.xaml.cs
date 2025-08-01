using CommunityToolkit.Maui.Core.Extensions;
using ExpanderCollectionView.Pages;
using ExpanderCollectionView.ViewModels;

namespace ExpanderCollectionViewSample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object? sender, EventArgs e)
        {
            var source = await GetItemsAsync(); // IEnumerable<T> ناشناس
            var vm = new ListCollectionViewModel<FakeItem>(source.ToObservableCollection());
            var page = new ListCollection(vm.DisplayItems);
            await Navigation.PushAsync(page);
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        public static Task<IEnumerable<FakeItem>> GetItemsAsync()
        {
            var list = new List<FakeItem>();
            for (int i = 1; i <= 40; i++)
            {
                list.Add(new FakeItem
                {
                    ID = i,
                    Name = $"کاربر {i}",
                    PendingState = i % 2 == 0 ? "در انتظار" : "تأیید شده",
                    Email = $"user{i}@example.com",
                    Phone = $"0912{i:D7}",
                    CreatedAt = DateTime.Now.AddDays(-i)
                });
            }

            return Task.FromResult<IEnumerable<FakeItem>>(list);
        }
        public class FakeItem
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string PendingState { get; set; }

            public string Email { get; set; }
            public string Phone { get; set; }
            public DateTime CreatedAt { get; set; }
        }
    }
}
