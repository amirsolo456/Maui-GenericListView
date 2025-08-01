using System.Timers;
using Timer = System.Timers.Timer;

namespace ExpanderCollectionView.Components;

public partial class PendingStateIconView : ContentView
{
    public PendingStateIconView()
    {
        InitializeComponent();
        UpdateIcon();
    }

    public static readonly BindableProperty PendingStateProperty =
        BindableProperty.Create(nameof(PendingState), typeof(bool), typeof(PendingStateIconView), false,
            propertyChanged: (bindable, oldVal, newVal) =>
            {
                ((PendingStateIconView)bindable).UpdateIcon();
            });

    public bool PendingState
    {
        get => (bool)GetValue(PendingStateProperty);
        set => SetValue(PendingStateProperty, value);
    }

    public event EventHandler Clicked;

    private void OnTapped(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, EventArgs.Empty);
    }

    private void UpdateIcon()
    {
        IconImage.Source = PendingState ? "dotnet_bot.png" : "dotnet_bot.png";
    }
}