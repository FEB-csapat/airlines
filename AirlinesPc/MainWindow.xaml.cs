using AirlinesPc.DataReaders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
        int currentrow = 0;
        Button[] buttons = new Button[350];
        int buttoncounter = 0;
        public MainWindow()
        {
            ApiReader();
            this.DataContext = this;
            InitializeComponent();
            StartingCity.ItemsSource = StartingCities;
            TargetCity.ItemsSource = TargetCities;
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
            StartingCities = StartingCities.OrderBy(x => x).ToList();
            TargetCities = StartingCities;
        }
        private void StartingCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StartingCity.SelectedValue.ToString() !=""&& StartingCity.SelectedValue is not null)
            {
                TargetCity.IsEnabled = true;
                TargetLabel.IsEnabled = true;
            }
            else
            {
                TargetCity.IsEnabled = false;
                TargetLabel.IsEnabled = false;
            }
        }
        private void TargetCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowFlights();
            StartingCity.ItemsSource = StartingCities;
            if (StartingCity.SelectedValue.ToString()==TargetCity.SelectedValue.ToString())
            {
                MessageBox.Show("Nem lehet megegyező az indulóváros, és a célváros!");
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
            buttoncounter = 0;
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
            buttoncounter++;
            cols++;
            rows++;
        }
        public void MoreDetails()
        {
            buttoncounter = 0;
            FlightsGrid.Children.Clear();
            FlightsGrid.RowDefinitions.Clear();
            FlightsGrid.ColumnDefinitions.Clear();
            for (int i = 0; i < FlightRoutes.Count+3; i++)
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
            int currentdetails = 0;
            for (int i = 0; i < FlightRoutes.Count; i++)
            {
                if (i!=currentrow||i+1!=currentrow+1)
                {
                    Details(FlightRoutes[i], i + 1+currentdetails);
                }
                else
                {
                    HeaderGenerate(currentrow + 1);
                    FlightContent(FlightRoutes[currentrow - 1], currentrow + 2);
                    i++;
                    Details(FlightRoutes[i-1], i + 2);
                    Details(FlightRoutes[i], i+3);
                    currentdetails += 2;
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
        public void GetPosition(Button button)
        {
            currentrow = Grid.GetRow(button);
        }
        private void Bt_Click(object sender, RoutedEventArgs e)
        {
            GetPosition(sender as Button);
            Button currentButton = buttons[currentrow-1];
            MoreDetails();
        }
        public void ListAllFlights()
        {
            FlightsGrid.Children.Clear();
            FlightsGrid.RowDefinitions.Clear();
            FlightsGrid.ColumnDefinitions.Clear();
            for (int i = 0; i < FlightRoutes.Count+1; i++)
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
        private void ShowAllFlights_Click(object sender, RoutedEventArgs e)
        {
            ListAllFlights();
        }
    }
}
