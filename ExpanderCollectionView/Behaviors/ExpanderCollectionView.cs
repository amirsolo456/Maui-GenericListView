using CommunityToolkit.Maui.Views;
using ExpanderCollectionView.Components;
using ExpanderCollectionView.Models.ExpanderHeader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpanderCollectionView.Behavior
{
    public class ExpanderLazyLoadBehavior : Behavior<Expander>
    {
        private Expander _expander;
        private ContentView _container;

        private const uint AnimationDuration = 1000; // 1 second
        private const double ExpandedHeight = 100;
        protected override void OnAttachedTo(Expander bindable)
        {
            base.OnAttachedTo(bindable);
            _expander = bindable;
            _container = bindable.FindByName<ContentView>("LazyContainer");

            bindable.ExpandedChanged += OnExpanded;
        }

        protected override void OnDetachingFrom(Expander bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ExpandedChanged -= OnExpanded;
        }

        private void OnExpanded(object sender, EventArgs e)
        {
            if (sender is Expander expander && expander.Content is ContentView container)
            {
                if (expander.BindingContext is ExpanderHeader model)
                {
                    var view = new ExpanderContentView();
                    var content = model.LazyDetails.Invoke();
                    view.BuildFrom(content);
                    container.Content = view;
                }

                ExpandAnimation(expander);
            }
        }

        private void ExpandAnimation(Expander _expander)
        {
            if (_container == null || _expander == null) return;

            if (_expander.IsExpanded)
            {
                _container.IsVisible = true;
                AnimateHeight(_container, 0, ExpandedHeight);
            }
            else
            {
                AnimateHeight(_container, _container.Height, 0, () =>
                {
                    _container.IsVisible = false;
                });
            }
        }

        private void AnimateHeight(VisualElement view, double from, double to, Action onComplete = null)
        {
            var animation = new Animation(v => view.HeightRequest = v, from, to, Easing.CubicInOut);
            animation.Commit(view, "HeightAnimation", 16, AnimationDuration, finished: (v, c) => onComplete?.Invoke());
        }

    }
}
