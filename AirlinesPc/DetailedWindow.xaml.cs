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
        private int[] gyerekdb;
        public int[] GyerekekDB
        {
            get { return gyerekdb; }
            set
            {
                gyerekdb = value;
            }
        }
        public int[] Jegydb
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
        int utasszam;
        double alapdij;
        double bruttodij;
        double idegenforgalmi=0;
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int utasszam=1;
            double alapdij=1;
            double bruttodij = 1;
            double idegenforgalmi = 0;
            if (0<=populacio&&populacio<2000000)
            {
                idegenforgalmi = 0.05;
            }
            else if (2000000<=populacio&&populacio<10000000)
            {
                idegenforgalmi = 0.075;
            }
            else if(10000000<=populacio)
            {
                idegenforgalmi = 0.1;
            }
                Gyermekek.IsEnabled=true;
                Gyermekek.SelectedValue = 0;
                utasszam = int.Parse(Utasszam.SelectedValue.ToString());
                alapdij = towrite.TravelDistance * towrite.KmPrice * utasszam;
            Lalapdij.Content = Math.Round(alapdij) + " Ft";
            gyerekdb = new int[utasszam+1];
                for (int i = 0; i < utasszam+1; i++)
                    {
                        gyerekdb[i] = i;
                    }
                Gyermekek.ItemsSource = gyerekdb;
                bruttodij = alapdij * 1.27;
                bruttodij += (towrite.TravelDistance * 0.1) * towrite.KmPrice;
                if (utasszam > 10)
                {
                    bruttodij = bruttodij * 0.9;
                }
            bruttodij += bruttodij * idegenforgalmi;
            Lbruttodij.Content = Math.Round(bruttodij) + " Ft";
        }

        private void Gyermekek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int utasszam = 1;
            double alapdij = 1;
            double bruttodij = 1;
            double idegenforgalmi = 0;
            int gyermekek = int.Parse(Gyermekek.SelectedValue.ToString());
            utasszam = int.Parse(Utasszam.SelectedValue.ToString());
            if (utasszam>0)
            {
                if (gyermekek==0)
                {
                    alapdij = towrite.TravelDistance * towrite.KmPrice * utasszam;
                    bruttodij = alapdij * 1.27;
                    bruttodij += (towrite.TravelDistance * 0.1) * towrite.KmPrice;
                    if (utasszam > 10)
                    {
                        bruttodij = bruttodij * 0.9;
                    }
                }
                else
                {
                    if (utasszam==gyermekek)
                    {
                        alapdij = towrite.TravelDistance * towrite.KmPrice*gyermekek;
                        bruttodij = alapdij * 1.27 * 0.8;
                        bruttodij += (towrite.TravelDistance * 0.1) * towrite.KmPrice;
                    }
                    else
                    {
                        alapdij = towrite.TravelDistance * towrite.KmPrice * utasszam;
                        utasszam -= gyermekek;
                        bruttodij = towrite.TravelDistance * towrite.KmPrice * 1.27 *utasszam+ towrite.TravelDistance * towrite.KmPrice * 1.27* 0.8 * gyermekek;
                        bruttodij += (towrite.TravelDistance * 0.1) * towrite.KmPrice;
                        utasszam += gyermekek;
                    }
                }
            }
            if (utasszam > 10)
            {
                bruttodij = bruttodij * 0.9;
            }
            bruttodij += bruttodij * idegenforgalmi;
            Lalapdij.Content = Math.Round(alapdij) + " Ft";
            Lbruttodij.Content = Math.Round(bruttodij) + " Ft";
        }
    }
}
