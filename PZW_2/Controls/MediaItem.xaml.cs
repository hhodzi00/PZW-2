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

namespace PZW_2.Controls
{
    /// <summary>
    /// Interaction logic for MediaItem.xaml
    /// </summary>
    public partial class MediaItem : UserControl
    {
        public MediaItem()
        {
            InitializeComponent();
        }

        //propd pa tab tab

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                "Title",
                typeof(string), 
                typeof(MediaItem),
                new UIPropertyMetadata("Title")
           );

        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
        (
           "Delete", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(MediaItem) //tip elementa koji posjeduje event
        );

        public event RoutedEventHandler Delete //za registraciju/deregistraciju 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MediaItem.DeleteEvent);
            RaiseEvent(newEventArgs);
        }

        private void OnControlLoaded(object sender, RoutedEventArgs e)
        {
            this.DeleteIcon.MouseDown += new MouseButtonEventHandler(DeleteIcon_MouseDown);
        }        

        void DeleteIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseDeleteEvent();
        }

    }
}
