using Syncfusion.Maui.Toolkit.BottomSheet;
using System.Text;

namespace ExpanderCollectionView.Components;

public partial class BottomDrawerSheet : ContentView
{
    TaskCompletionSource<bool> _taskCompletionSource { get; set; }
    public BottomDrawerSheet()
    {
        InitializeComponent();
    }

    public BottomDrawerSheet(StringBuilder stringBuilder)
    {
        InitializeComponent();
        StringBuilder = stringBuilder;
        ContentText = stringBuilder.ToString();
    }

    public async Task<bool> Show()
    {
        _taskCompletionSource = new TaskCompletionSource<bool>();
        bottomsheet.IsOpen = true;
        return  await _taskCompletionSource.Task;
    }

    private StringBuilder StringBuilder { get; set; }

    public static readonly BindableProperty ContentTextProperty =
    BindableProperty.Create(nameof(ContentText), typeof(string), typeof(BottomDrawerSheet),  "test");

    public string ContentText
    {
        get => (string)GetValue(ContentTextProperty);
        set => SetValue(ContentTextProperty, value);
    }

    private void bottomsheet_StateChanged(object sender, Syncfusion.Maui.Toolkit.BottomSheet.StateChangedEventArgs e)
    {
        if(sender is SfBottomSheet sf)
        {
            if(sf.State == BottomSheetState.Collapsed)
            {
                _taskCompletionSource.SetResult(false);
            }
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        bottomsheet.IsOpen = false;
    }
}