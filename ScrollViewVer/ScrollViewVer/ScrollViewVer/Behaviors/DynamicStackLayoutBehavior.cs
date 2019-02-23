using Prism.Behaviors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ScrollViewVer.Behaviors
{
    class DynamicStackLayoutBehavior : BehaviorBase<StackLayout>
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            "ItemsSource", typeof(ObservableCollection<string>), typeof(DynamicStackLayoutBehavior));

        private bool IsInit = false;

        public ObservableCollection<string> ItemsSource
        {
            get { return (ObservableCollection<string>)this.GetValue(ItemsSourceProperty); }
            set { this.SetValue(ItemsSourceProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (!IsInit)
            {
                ItemsSource.CollectionChanged += CollectionChange;
                IsInit = true;
            }
        }

        private void CollectionChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                AssociatedObject.Children.Add(new Label {
                    Text = ItemsSource[e.NewStartingIndex],
                    BackgroundColor = Color.Red,
                    VerticalOptions = LayoutOptions.Center,
                });
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                AssociatedObject.Children.RemoveAt(e.OldStartingIndex);
            }
        }
    }
}
