using LiveCharts;
using LiveCharts.Wpf;
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

namespace ZR_Banka
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
     
        public HomePage()
        {
            InitializeComponent();
            lblUser.Content += App.loggedUser.Ime.ToString() + "!";

             List<int> loggedKrediti = App.context.Kredit
    .Where(k => k.IdKorisnik == App.loggedUser.IdKorisnik)
    .Select(k => k.IdKredit).ToList();


        var uplate = App.context.Uplata
        .Where(u => u.IdKredit.HasValue && loggedKrediti.Contains(u.IdKredit.Value))  // Provjera da nije null i usporedba s listom
        .OrderBy(u => u.DatumUplate)  // Sortiraj po datumu
        .ToList();  // Dohvati sve uplate



            listUplate.ItemsSource = uplate;

        }
    }
}
