using System;
using System.Collections.Generic;
using System.Linq;
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

namespace MineSweeperVisual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int meret = 10;
        Random r = new Random();
        char[,] mezo = new char[10, 10];
        char[,] mezof = new char[10, 10];
        public char aknakereses(int meret, int elso, int masodik)
        {
            return mezof[elso, masodik];
        }

        public void kezdesMethod()
        {
            MainGrid.Children.Clear();
            MainGrid.RowDefinitions.Clear();
            MainGrid.ColumnDefinitions.Clear();
            int count = 0;
            meret = 10;
            if (meretT.Text != "")
            {
                meret = int.Parse(meretT.Text);
            }
            mezo = new char[meret, meret];
            mezof = new char[meret, meret];
            for (int i = 0; i < meret; i++)
            {
                int v = r.Next(0, meret);
                for (int j = 0; j < meret; j++)
                {
                    if (j == v)
                    {
                        mezo[i, j] = 'X';
                        mezof[i, j] = 'X';
                    }
                    else
                    {
                        mezo[i, j] = ' ';
                        mezof[i, j] = ' ';
                    }
                }
            }
            for (int i = 0; i < meret; i++)
            {
                for (int j = 0; j < meret; j++)
                {
                    int osszeg = 0;
                    if (mezo[i, j] != 'X')
                    {
                        if (i != 0 && mezo[i - 1, j] == 'X') osszeg++;
                        if (i != meret - 1 && mezo[i + 1, j] == 'X') osszeg++;
                        if (i != 0 && j != 0 && mezo[i - 1, j - 1] == 'X') osszeg++;
                        if (i != 0 && j != meret - 1 && mezo[i - 1, j + 1] == 'X') osszeg++;
                        if (i != meret - 1 && j != 0 && mezo[i + 1, j - 1] == 'X') osszeg++;
                        if (i != meret - 1 && j != meret - 1 && mezo[i + 1, j + 1] == 'X') osszeg++;
                        if (j != meret - 1 && mezo[i, j + 1] == 'X') osszeg++;
                        if (j != 0 && mezo[i, j - 1] == 'X') osszeg++;
                        mezof[i, j] = Convert.ToChar((Convert.ToString(osszeg)));
                    }
                }
            }

            for (int i = 0; i < meret; i++)
            {
                for (int j = 0; j < meret; j++)
                {
                    Button b = new Button();
                    b.MinWidth = i;
                    b.MinHeight = j;
                    b.Width = MainGrid.Width / meret;
                    b.Height = MainGrid.Height / meret;
                    b.Click += Button_Click;

                    MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(MainGrid.Height / meret) });
                    MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(MainGrid.Height / meret) });
                    MainGrid.Children.Add(b);
                    Grid.SetColumn(b, j);
                    Grid.SetRow(b, i);
                    count++;
                }
            }
            meretL.Content = $"Mezők száma: {count} \n Bombák száma: {meret}";

        }
        private void kezdes_Click(object sender, RoutedEventArgs e)
            {
            kezdesMethod();
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            b.Content = aknakereses(meret,Convert.ToInt32(b.MinWidth), Convert.ToInt32(b.MinHeight));
            if (Convert.ToString(b.Content) == "X")
            {
                MessageBox.Show("Veszítettél");
                kezdesMethod();
            }
        }
    }
}
