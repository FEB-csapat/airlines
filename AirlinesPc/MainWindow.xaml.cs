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
        public void HeaderGenerate(int row)
        { 
            int cols=0;
            var label = new Label()
            {
                Content = "Indul:"
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, row);
            cols++;
            label = new Label()
            {
                Content = "Érkezik:"
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, row);
            cols++;
            label = new Label()
            {
                Content = "Légitársaság neve:"
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, row);
            cols++;
            label = new Label()
            {
                Content = "Útvonal hossza (km):" 
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, row);
            cols++;
            label = new Label()
            {
                Content = "Repülési idő:"
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, row);
            cols++;
            label = new Label()
            {
                Content = "Km díj Ft-ban:"
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, row);
            cols++;
        }
        public void FlightContent(Flights item,int rows)
        {
            int cols = 0;
            var label = new Label()
            {
                Content = item.StartCity
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, rows);
            cols++;
            label = new Label()
            {
                Content = item.TargetCity
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, rows);
            cols++;
            label = new Label()
            {
                Content = item.AirlineName
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, rows);
            cols++;
            label = new Label()
            {
                Content = item.TravelDistance
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, rows);
            cols++;
            label = new Label()
            {
                Content = item.TimeHour + ":" + item.TimeMinute
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, rows);
            cols++;
            label = new Label()
            {
                Content = item.KmPrice
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, rows);
            cols++;
            rows++;
        }
        public void ShowFlights()
        {
            FlightsGrid.Children.Clear();
            FlightsGrid.RowDefinitions.Clear();
            FlightsGrid.ColumnDefinitions.Clear();
            for (int i = 0; i < 6; i++)
            {
                FlightsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(130, GridUnitType.Pixel) });
            }
            FlightsGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(35, GridUnitType.Pixel) });
            FlightsGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(35, GridUnitType.Pixel) });
            HeaderGenerate(0);
            foreach (var item in FlightRoutes)
            {
                if (item.StartCity == StartingCity.SelectedValue.ToString() && item.TargetCity == TargetCity.SelectedValue.ToString())
                {
                    FlightContent(item,1);
                    break;
                }
            }
        }
        public void Details(Flights item, int rows)
        {
            int buttoncounter = 0;
            int cols = 0;
            var label = new Label()
            {
                Content = item.StartCity
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, rows);
            cols++;
            label = new Label()
            {
                Content = item.TargetCity
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, rows);
            cols++;
            label = new Label()
            {
                Content = item.AirlineName
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, rows);
            cols++;
            var bt = new Button()
            {
                Content = "Bővebb infó",
                Margin = new Thickness(1,1,1,1),
                Height = 20,
                Width = 100,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            FlightsGrid.Children.Add(bt);
            Grid.SetColumn(bt, cols);
            Grid.SetRow(bt, rows);
            bt.Click += Bt_Click;
            buttons[buttoncounter] = bt;
            cols++;
            rows++;
        }
        public void MoreDetails()
        {
            FlightsGrid.Children.Clear();
            FlightsGrid.RowDefinitions.Clear();
            FlightsGrid.ColumnDefinitions.Clear();
            FlightsGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(35, GridUnitType.Pixel) });
            for (int i = 0; i < FlightRoutes.Count; i++)
            {
                FlightsGrid.RowDefinitions.Add(new RowDefinition());
                FlightsGrid.RowDefinitions[i].Height = new GridLength(50, GridUnitType.Pixel);
            }
            for (int i = 0; i <= 6; i++)
            {
                FlightsGrid.ColumnDefinitions.Add(new ColumnDefinition());
                FlightsGrid.ColumnDefinitions[i].Width = new GridLength(130, GridUnitType.Pixel);
            }
            DetailHeader();
            for (int i = 0; i < FlightRoutes.Count; i++)
            {
                
                if (i!=currentrow||i+1!=currentrow+1)
                {
                    Details(FlightRoutes[i], i + 1);
                    //TODO:Push list down by two from currentrow, than insert whats in else tree
                }
                else
                {
                    HeaderGenerate(currentrow + 1);

                    FlightContent(FlightRoutes[currentrow-1], currentrow + 2);
                }
            }

        }
        public void DetailHeader()
        {
            int cols = 0;
            var label = new Label()
            {
                Content = "Indul:"
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, 0);
            cols++;
            label = new Label()
            {
                Content = "Érkezik:"
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, 0);
            cols++;
            label = new Label()
            {
                Content = "Légitársaság neve:"
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, 0);
            cols++;
        }
        Button[] buttons = new Button[100];
        static readonly Brush RED = new SolidColorBrush(Color.FromRgb(127, 0, 0));

        int currentrow = 0;
        public void GetPosition(Button button)
        {
            currentrow = Grid.GetRow(button);
        }
        private void Bt_Click(object sender, RoutedEventArgs e)
        {
            GetPosition(sender as Button);
            Button currentButton = buttons[currentrow];
            MoreDetails();
        }
        public void ListAllFlights()
        {
            FlightsGrid.Children.Clear();
            FlightsGrid.RowDefinitions.Clear();
            FlightsGrid.ColumnDefinitions.Clear();
            for (int i = 0; i < FlightRoutes.Count; i++)
            {
                FlightsGrid.RowDefinitions.Add(new RowDefinition());
                FlightsGrid.RowDefinitions[i].Height = new GridLength(50,GridUnitType.Pixel);
            }
            for (int i = 0; i <= 6; i++)
            {
                FlightsGrid.ColumnDefinitions.Add(new ColumnDefinition());
                FlightsGrid.ColumnDefinitions[i].Width = new GridLength(130, GridUnitType.Pixel);
            }
            DetailHeader();
            for (int i = 0; i < FlightRoutes.Count; i++)
            {
                Details(FlightRoutes[i], i + 1);
            }
        }
        private void TargetCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowFlights();
        }

        private void ShowAllFlights_Click(object sender, RoutedEventArgs e)
        {
            ListAllFlights();
        }
    }
}
