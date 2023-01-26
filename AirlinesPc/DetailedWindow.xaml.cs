using AirlinesPc.DataReaders;
using System.Windows;
using System.Windows.Controls;

namespace AirlinesPc
{
    /// <summary>
    /// Interaction logic for DetailedWindow.xaml
    /// </summary>
    public partial class DetailedWindow : Window
    { 
        Flights towrite;
        public DetailedWindow(Flights item)
        {
            towrite = item;
            InitializeComponent();
            DetailData();
        }
        public DetailedWindow()
        {
        }
        public void DetailData()
        {
            this.WindowStyle = WindowStyle.None;
            Label label = new Label()
            {
                Content = towrite.AirlineName,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            DetailGrid.Children.Add(label);
            Grid.SetRow(label, 1);
            Grid.SetColumn(label, 0);
            label = new Label()
            {
                Content = towrite.StartCity,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            DetailGrid.Children.Add(label);
            Grid.SetRow(label, 1);
            Grid.SetColumn(label, 1);
            label = new Label()
            {
                Content = towrite.TargetCity,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            DetailGrid.Children.Add(label);
            Grid.SetRow(label, 1);
            Grid.SetColumn(label, 2);
            label = new Label()
            {
                Content = towrite.TravelDistance,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            DetailGrid.Children.Add(label);
            Grid.SetRow(label, 1);
            Grid.SetColumn(label, 3);
            label = new Label()
            {
                Content = towrite.TravelTime,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            DetailGrid.Children.Add(label);
            Grid.SetRow(label, 1);
            Grid.SetColumn(label, 4);
            label = new Label()
            {
                Content = towrite.KmPrice,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            DetailGrid.Children.Add(label);
            Grid.SetRow(label, 1);
            Grid.SetColumn(label, 5);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DetailGrid.Children.Clear();
            this.Close();
        }
    }
}
