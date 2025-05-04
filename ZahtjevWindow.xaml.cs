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
    /// Interaction logic for ZahtjevWindow.xaml
    /// </summary>
    public partial class ZahtjevWindow : Window
    {
        public ZahtjevWindow()
        {
            InitializeComponent();
        }

        private void btnPredaj_Click(object sender, RoutedEventArgs e)
        {
            if (txtVrsta.Text != null && txtGlavnica.Text != null)
            {
                Zahtjev zahtjev = new Zahtjev();
                zahtjev.vrsta_kredita = txtVrsta.Text;
                zahtjev.iznos = decimal.Parse(txtGlavnica.Text);
                zahtjev.datum_zahtjeva = DateTime.Now;
                zahtjev.id_korisnik = App.loggedUser.IdKorisnik;
                
                App.context.Add(zahtjev);
                App.context.SaveChanges();
                MessageBox.Show("Predali ste zahtjev za kredit!");
                this.Close();



            }
            else
            {
                MessageBox.Show("Provjerite unos!");
            }
        }
    }
}
