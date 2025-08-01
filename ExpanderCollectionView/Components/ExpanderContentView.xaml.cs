namespace ExpanderCollectionView.Components;

public partial class ExpanderContentView : ContentView
{
	public ExpanderContentView()
	{
		InitializeComponent();
	}
    public void BuildFrom(Dictionary<string, object> dict)
    {
        ContentLayout.Children.Clear();

        foreach (var item in dict)
        {
            var row = new HorizontalStackLayout
            {
                Children =
                {
                    new Label { Text = item.Key + ":", FontAttributes = FontAttributes.Bold },
                    new Label { Text = item.Value?.ToString(), LineBreakMode = LineBreakMode.WordWrap }
                }
            };

            ContentLayout.Children.Add(row);
        }
    }
}