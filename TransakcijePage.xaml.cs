
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
using ZR_Banka.Classes;
using ZR_Banka.Models;

namespace ZR_Banka
{
    /// <summary>
    /// Interaction logic for TransakcijePage.xaml
    /// </summary>
    public partial class TransakcijePage : Page
    {
       
        public TransakcijePage()
        {
            InitializeComponent();

            RefreshKrediti();
        }

        public void RefreshKrediti()
        {
            List<int> loggedKrediti = App.context.Kredit
          .Where(k => k.IdKorisnik == App.loggedUser.IdKorisnik)
          .Select(k => k.IdKredit).ToList();

            var krediti = App.context.Kredit
       .Where(k => k.IdKorisnik == App.loggedUser.IdKorisnik)
       .Select(k => new KreditView
       {
           IdKredit = k.IdKredit,
           VrstaKredita = k.VrstaKredita,
           DatumPozajmice = k.DatumPozajmice.ToDateTime(new TimeOnly(0, 0)),
           UkupanIznos = k.UkupanIznos,

           PreostaliDug = App.context.Uplata
               .Where(u => u.IdKredit == k.IdKredit)
               .OrderByDescending(u => u.DatumUplate)
               .Select(u => (decimal?)u.PreostaliDug)
               .FirstOrDefault() ?? k.UkupanIznos // ako nema uplate, vrati cijeli iznos
       })
       .ToList();




            listKrediti.ItemsSource = krediti;


        }

        public static Kredit selectedKredit;
        public static decimal preostaliDug;
        private void btnPlacanje_Click(object sender, RoutedEventArgs e)
        {
           var selectedObject = listKrediti.SelectedItem as KreditView;
            if (selectedObject == null)
            {
                MessageBox.Show("Molimo odaberite kredit za uplatu.");
                return;
            }

            selectedKredit = App.context.Kredit.FirstOrDefault(k => k.IdKredit == selectedObject.IdKredit);

            preostaliDug = App.context.Uplata
               .Where(u => u.IdKredit == selectedObject.IdKredit)
               .OrderByDescending(u => u.DatumUplate)
               .Select(u => (decimal?)u.PreostaliDug)
               .FirstOrDefault() ?? selectedKredit.UkupanIznos; // ako nema uplate, vrati cijeli iznos

            UplataWindow uplataWindow = new UplataWindow(this);
            uplataWindow.Show();

        }
    }
    }


