using ExpanderCollectionView.Components;
using ExpanderCollectionView.Models.ExpanderHeader;
using ExpanderCollectionView.Services;
using ExpanderCollectionView.ViewModels;
using Syncfusion.Maui.Toolkit.BottomSheet;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ExpanderCollectionView.Pages;

public partial class ListCollection : ContentPage
{   
	public ListCollection(ObservableCollection<ExpanderHeader> displayItems)
	{
		InitializeComponent();
        BindingContext = new { DisplayItems = displayItems };
        this.Loaded += ListCollection_Loaded;
    }

    private void ListCollection_Loaded(object? sender, EventArgs e)
    {
        //var title = new StringBuilder();
        //title.AppendLine("درحال بارگزاری");
        //title.AppendLine("لطفا منتظر بمانید");
        //_bottomDrawerSheet = new BottomDrawerSheet(title);
    }

    private async void OnPendingIconClicked(object sender, EventArgs e)
    {
        bottomsheet.IsVisible = true;
       await bottomsheet.Show(); 
    }

    private void CollectionView_RemainingItemsThresholdReached(object sender, EventArgs e)
    {

    }

    private void CollectionView_ScrollToRequested(object sender, ScrollToRequestEventArgs e)
    {

    }
}