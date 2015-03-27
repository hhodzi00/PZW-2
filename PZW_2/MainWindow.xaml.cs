using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PZW_2.Controls;
namespace PZW_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            this.AddButton.Click += AddButton_Click;
            
            this.LeftButton.Click += (objSender, eventArgs) => SelectPreviousMediaItem();
            this.RightButton.Click += (objSender, eventArgs) => SelectNextMediaItem();

            foreach (var child in this.MediaItemContainer.Children)
            {
                if (!(child is MediaItem)) { continue; }
            
                var mediaItem = child as MediaItem;//castanje kao i (MediaItem)child
                mediaItem.Delete += OnMediaItem_Delete;
                
            }
        }

        void OnMediaItem_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is MediaItem)) { return; }

            var mediaItem = sender as MediaItem;

            this.MediaItemContainer.Children.Remove(mediaItem);
            
        }

        private int _selectedIndex = 0;

        private void SelectPreviousMediaItem()
        {
            if (_selectedIndex <= 0) { return;  }

            _VisuallyDeselectSelectedMediaItem();

            _selectedIndex--;

            _VisuallySelectSelectedMediaItem();
        }

        private void SelectNextMediaItem()
        {
            if (_selectedIndex >= this.MediaItemContainer.Children.Count - 1) { return; }

            _VisuallyDeselectSelectedMediaItem();

            _selectedIndex++;

            _VisuallySelectSelectedMediaItem();
        }

        private void _VisuallySelectSelectedMediaItem()
        {
            if (_IsNotValidIndex()) { return; }

            var element = this.MediaItemContainer.Children[_selectedIndex];
        }

        private void _VisuallyDeselectSelectedMediaItem()
        {
            if (_IsNotValidIndex()) { return; }

            var element = this.MediaItemContainer.Children[_selectedIndex];
        }

        private bool _IsNotValidIndex()
        {
            return _selectedIndex < 0 || _selectedIndex >= this.MediaItemContainer.Children.Count;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
