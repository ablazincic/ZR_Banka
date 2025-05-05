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
using System.Windows.Shapes;
using ZR_Banka.Models;

namespace ZR_Banka
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            Refresh();

            txtID.IsEnabled = false;
            txtUsername.IsEnabled = false;
        }

        public void Refresh()
        {
            var Korisnici = App.context.Korisnik.ToList();

            lbKorisnici.ItemsSource = Korisnici;
        }

      

        private void lbKorisnici_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var odabraniKorisnik = lbKorisnici.SelectedItem as Korisnik;

            if (odabraniKorisnik != null)
            {
                txtID.Text = odabraniKorisnik.IdKorisnik.ToString();
                txtUsername.Text = odabraniKorisnik.Username;
                txtUloga.Text = odabraniKorisnik.Uloga;
            }
        }

        private void btnUloga_Click(object sender, RoutedEventArgs e)
        {
            List<string> Uloge = new List<string>()
            {
                "administrator",
                "korisnik",
                "bankar"
            };
            var odabraniKorisnik = lbKorisnici.SelectedItem as Korisnik;

            var uloga = Uloge.FirstOrDefault(u => u == txtUloga.Text.ToLower());
            
                if (uloga != null)
                {
                    App.context.Korisnik.Find(odabraniKorisnik.IdKorisnik).Uloga = txtUloga.Text;
                    App.context.SaveChanges();
                    MessageBox.Show("Uloga je promijenjena");
                }
                else
                MessageBox.Show("Unesite ispravnu ulogu");
                
            Refresh();




        }

        private void btnBrisi_Click(object sender, RoutedEventArgs e)
        {
            var dialog = MessageBox.Show("Želite li sigurno izbrisati korisnika?", "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question);
            var odabraniKorisnik = lbKorisnici.SelectedItem as Korisnik;

            bool imaKredita = App.context.Kredit.Any(k => k.IdKorisnik == odabraniKorisnik.IdKorisnik);

            if (dialog == MessageBoxResult.Yes)
            {
                if (imaKredita)
                {
                    MessageBox.Show("Korisnik ima aktivne kredite, ne može se obrisati račun!");
                }
                else
                {
                    App.context.Korisnik.Remove(odabraniKorisnik);
                    App.context.SaveChanges();
                    MessageBox.Show("Korisnik je uspješno obrisan");
                    txtID.Clear();
                    txtUloga.Clear();
                    txtUsername.Clear();
                    Refresh();
                  
                }
                
            }
           
        }
    }
}
