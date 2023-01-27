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
        List<string> Transfers = new List<string>();
        public List<City> Cities = new List<City>();
        public List<Flights> FlightRoutes = new List<Flights>();
        City helper;
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
            foreach (var item in File.ReadAllLines("CityPopulation.csv", Encoding.Default))
            {
                helper = new City(item);
                Cities.Add(helper);
                StartingCities.Add(helper.Name);
            }
            foreach (var item in File.ReadLines("Flights.csv", Encoding.Default).Skip(1))
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
        //Header for details
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
        //Listing details
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
        //Direct flights
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
        //Data for all flights
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
        //redirect to detailwindow
        public void MoreDetails()
        {
            City targetcity = Cities.Where(x => x.Name == FlightRoutes[currentrow - 1].TargetCity).First();
            int populacio = targetcity.Population;
            DetailedWindow window = new DetailedWindow(FlightRoutes[currentrow-1],populacio);
            window.Show();
        }
        //header for all flights
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
        //listing all flights
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
        //Gets all possible destinations with transfers
        public void GetTransfers()
        {
            Transfers.Clear();
            TargetCity.IsEnabled = false;
            string startingcityname = StartingCity.SelectedValue.ToString();
            foreach (var item in FlightRoutes)
            {
                if (item.StartCity== startingcityname && !Transfers.Contains(item.TargetCity)&&item.TargetCity!= startingcityname)
                {
                    Transfers.Add(item.TargetCity);
                    foreach (var flight in FlightRoutes)
                    {
                        if (flight.StartCity==item.TargetCity && !Transfers.Contains(flight.TargetCity) && flight.TargetCity != startingcityname)
                        {
                            Transfers.Add(flight.TargetCity);
                            foreach (var transfer in FlightRoutes)
                            {
                                if (transfer.StartCity==flight.TargetCity && !Transfers.Contains(transfer.TargetCity) && transfer.TargetCity != startingcityname)
                                {
                                    Transfers.Add(transfer.TargetCity);
                                }
                            }
                        }
                    }
                }
            }
        }
        //Lists all possible destinations with transfers
        public void ListTwoTransfers()
        {
            FlightsGrid.Children.Clear();
            FlightsGrid.RowDefinitions.Clear();
            FlightsGrid.ColumnDefinitions.Clear();
            for (int i = 0; i < Transfers.Count + 1; i++)
            {
                FlightsGrid.RowDefinitions.Add(new RowDefinition());
                FlightsGrid.RowDefinitions[i].Height = new GridLength(50, GridUnitType.Pixel);
            }
            FlightsGrid.ColumnDefinitions.Add(new ColumnDefinition());
            FlightsGrid.ColumnDefinitions[0].Width = new GridLength(130, GridUnitType.Pixel);
            int cols = 0;
            var label = new Label()
            {
                Content = "Lehetséges célpontok:"
            };
            FlightsGrid.Children.Add(label);
            Grid.SetColumn(label, cols);
            Grid.SetRow(label, 0);
            int rows = 1;
            foreach (var item in Transfers)
            {
                label = new Label()
                {
                    Content = item
                };
                FlightsGrid.Children.Add(label);
                Grid.SetColumn(label, 0);
                Grid.SetRow(label, rows);
                rows++;
            }
        }
        private void ShowAllFlights_Click(object sender, RoutedEventArgs e)
        {
            ListAllFlights();
        }
        private void ShowTransfers_Click(object sender, RoutedEventArgs e)
        {
            if (StartingCity.SelectedValue is not null)
            {
                GetTransfers();
                ListTwoTransfers();
            }
            else
            {
                MessageBox.Show("Elöbb válasszon várost!");
            }
        }
    }
}
