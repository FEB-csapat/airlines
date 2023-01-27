using AirlinesPc.DataReaders;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
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
        int populacio;
        private int[] db = new int[20];
        private int[] childdb;
        public int[] Ticketdb
        {
            get { return db; }
            set { db = value; }
        }
        public DetailedWindow(Flights item,int population)
        {
            this.DataContext = this;
            towrite = item;
            populacio = population;
            for (int i = 0; i < 20; i++)
            {
                db[i] = i+1;
            }
            InitializeComponent();
            DetailData();
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
            this.Close();
        }
        int passengers;
        double netto;
        double brutto;
        double TourismTax=0;
        public void SetVariabletoDefault()
        {
            passengers = 1;
            netto = 1;
            brutto = 1;
            TourismTax = 0;
            passengers = int.Parse(Passengers.SelectedValue.ToString());
        }
        public void Calculations()
        {
            netto = towrite.TravelDistance * towrite.KmPrice * passengers;
            brutto = netto * 1.27;
            brutto += (towrite.TravelDistance * 0.1) * towrite.KmPrice;
            if (passengers > 10)
            {
                brutto = brutto * 0.9;
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetVariabletoDefault();
            if (0<=populacio&&populacio<2000000)
            {
                TourismTax = 0.05;
            }
            else if (2000000<=populacio&&populacio<10000000)
            {
                TourismTax = 0.075;
            }
            else if(10000000<=populacio)
            {
                TourismTax = 0.1;
            }
            Children.IsEnabled=true;
                Children.SelectedValue = 0;
            childdb = new int[passengers + 1];
            for (int i = 0; i < passengers + 1; i++)
            {
                childdb[i] = i;
            }
            Children.ItemsSource = childdb;
            Calculations();
            brutto += brutto * TourismTax;
            NettoPrice.Content = Math.Round(netto) + " Ft";
            BruttoPrice.Content = Math.Round(brutto) + " Ft";
        }

        private void Children_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetVariabletoDefault();
            int childrencount = int.Parse(Children.SelectedValue.ToString());
            if (passengers>0)
            {
                if (childrencount == 0)
                {
                    Calculations();
                }
                else
                {
                    if (passengers== childrencount)
                    {
                        netto = towrite.TravelDistance * towrite.KmPrice* childrencount;
                        brutto = netto * 1.27 * 0.8;
                        brutto += (towrite.TravelDistance * 0.1) * towrite.KmPrice;
                    }
                    else
                    {
                        netto = towrite.TravelDistance * towrite.KmPrice * passengers;
                        passengers -= childrencount;
                        brutto = towrite.TravelDistance * towrite.KmPrice * 1.27 *passengers+ towrite.TravelDistance * towrite.KmPrice * 1.27* 0.8 * childrencount;
                        brutto += (towrite.TravelDistance * 0.1) * towrite.KmPrice;
                        passengers += childrencount;
                    }
                }
            }
            if (passengers > 10)
            {
                brutto = brutto * 0.9;
            }
            brutto += brutto * TourismTax;
            NettoPrice.Content = Math.Round(netto) + " Ft";
            BruttoPrice.Content = Math.Round(brutto) + " Ft";
        }
    }
}
