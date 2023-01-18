using AirlinesPc.DataReaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace AirlinesPc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> StartingCities = new List<string>();
        public List<string> TargetCities = new List<string>();
        public List<CityPopulation> Cities = new List<CityPopulation>();
        public List<Flights> FlightRoutes = new List<Flights>();
        CityPopulation helper;
        public MainWindow()
        {
            ApiReader();
            this.DataContext = this;
            InitializeComponent();
            StartingCity.ItemsSource = StartingCities;
            
        }
        public void ApiReader()
        {
            foreach (var item in File.ReadAllLines("CityPopulation.csv",Encoding.Default))
            {
                helper = new CityPopulation(item);
                Cities.Add(helper);
                StartingCities.Add(helper.CityName);
            }
            foreach (var item in File.ReadLines("Flights.csv",Encoding.Default).Skip(1))
            {
                FlightRoutes.Add(new Flights(item));
            }
        }

        string temp = "";
        private void StartingCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StartingCity.SelectedValue.ToString() !="")
            {
                temp = StartingCity.SelectedValue.ToString();
                TargetCity.IsEnabled = true;
                TargetLabel.IsEnabled = true;
                TargetCities = StartingCities;
                TargetCities.Remove(temp);
                TargetCity.ItemsSource = TargetCities;
            }
            else
            {
                TargetCity.IsEnabled = false;
                TargetLabel.IsEnabled = false;
            }
        }
        public void GridGenerate()
        {
            FlightsGrid.Children.Clear();
            FlightsGrid.RowDefinitions.Clear();
            FlightsGrid.ColumnDefinitions.Clear();
            for (int i = 0; i < 6; i++)
            {
                FlightsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }
            FlightsGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            FlightsGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            int cols = 0;
            int rows = 0;
            foreach (var item in FlightRoutes)
            {
                if (item.StartCity == StartingCity.SelectedValue.ToString() && item.TargetCity == TargetCity.SelectedValue.ToString())
                {
                    var label = new Label()
                    {
                        Content = "Indul: \n" + item.StartCity
                    };
                    FlightsGrid.Children.Add(label);
                    Grid.SetColumn(label, cols);
                    Grid.SetRow(label, rows);
                    cols++;
                    label = new Label()
                    {
                        Content = "Érkezik: \n" + item.TargetCity
                    };
                    FlightsGrid.Children.Add(label);
                    Grid.SetColumn(label, cols);
                    Grid.SetRow(label, rows);
                    cols++;
                    label = new Label()
                    {
                        Content = "Légitársaság neve: \n" + item.AirlineName
                    };
                    FlightsGrid.Children.Add(label);
                    Grid.SetColumn(label, cols);
                    Grid.SetRow(label, rows);
                    cols++;
                    label = new Label()
                    {
                        Content = "Útvonal hossza (km): \n" + item.TravelDistance
                    };
                    FlightsGrid.Children.Add(label);
                    Grid.SetColumn(label, cols);
                    Grid.SetRow(label, rows);
                    cols++;
                    label = new Label()
                    {
                        Content = "Repülési idő: \n" + item.TimeHour + ":"+item.TimeMinute
                    };
                    FlightsGrid.Children.Add(label);
                    Grid.SetColumn(label, cols);
                    Grid.SetRow(label, rows);
                    cols++;
                    label = new Label()
                    {
                        Content = "Km díj Ft-ban \n" + item.KmPrice
                    };
                    FlightsGrid.Children.Add(label);
                    Grid.SetColumn(label, cols);
                    Grid.SetRow(label, rows);
                    cols++;
                    rows++;
                    break;
                }
            }
        }
        static readonly Brush RED = new SolidColorBrush(Color.FromRgb(127, 0, 0));
        public void ListAllFlights()
        {
            FlightsGrid.Children.Clear();
            FlightsGrid.RowDefinitions.Clear();
            FlightsGrid.ColumnDefinitions.Clear();
            for (int i = 0; i < FlightRoutes.Count; i++)
            {
                FlightsGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 0; i <= 6; i++)
            {
                FlightsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 0; i < FlightRoutes.Count; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    var l = new Label()
                    {
                        Content = FlightRoutes[i].StartCity,
                        Background = RED,
                        Margin = new Thickness(1,1,1,1)
                    };
                    FlightsGrid.Children.Add(l);
                    Grid.SetRow(l,i);
                    Grid.SetColumn(l, j);
                }
            }
        }
        private void TargetCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridGenerate();
        }

        private void ShowAllFlights_Click(object sender, RoutedEventArgs e)
        {
            ListAllFlights();
        }
    }
}
