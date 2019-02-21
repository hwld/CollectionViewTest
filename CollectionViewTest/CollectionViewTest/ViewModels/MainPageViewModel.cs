using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CollectionViewTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public ObservableCollection<string> Items { get; } = new ObservableCollection<string>();
        public ICommand AddItemCommand { get; }
        public ICommand DeleteItemCommand { get; }

        private Random RandomGenerator { get; set; } = new Random();

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            AddItemCommand = new Command(_ =>
            {
                Items.Add(Guid.NewGuid().ToString("N").Substring(0, RandomGenerator.Next(1, 30)));
            });

            DeleteItemCommand = new Command(_ =>
            {
                if (Items.Count > 0)
                    Items.RemoveAt(Items.Count - 1);
            });
        }
    }
}
