using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;

namespace ZR_Banka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new HomePage());
        }

        private void Exit_program(object sender, EventArgs e)
        {
            Environment.Exit(0); //exitanje aplikacije putem X gumba
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomePage());
        }

        private void Transakcije_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TransakcijePage());
        }

        private void Postavke_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PostavkePage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
