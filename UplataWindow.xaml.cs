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
    /// Interaction logic for UplataWindow.xaml
    /// </summary>
    public partial class UplataWindow : Window
    {
        private TransakcijePage transakcijePage;
        public UplataWindow(TransakcijePage transakcije)
        {
            InitializeComponent();
            transakcijePage = transakcije;
            lblKredit.Content += TransakcijePage.selectedKredit.IdKredit.ToString();
        }

        private void btnPotvrda_Click(object sender, RoutedEventArgs e)
        {
            Uplata uplata = new Uplata();

            uplata.IdKredit = TransakcijePage.selectedKredit.IdKredit;
            uplata.Uplata_novac = decimal.Parse(txtIznos.Text);
            uplata.DatumUplate = DateOnly.FromDateTime(datePickerDatum.SelectedDate.Value);

            if (uplata.Uplata_novac > TransakcijePage.preostaliDug)
            {
                MessageBox.Show("Uplata je veća od preostalog duga!");
                return;
            }
            else
            {
                uplata.PreostaliDug = TransakcijePage.preostaliDug - uplata.Uplata_novac;
            }

            App.context.Add(uplata);
            App.context.SaveChanges();
            MessageBox.Show("Poštovani, vaša uplata od "+ uplata.Uplata_novac + "€ je uspješno izvršena!");
            transakcijePage.RefreshKrediti();
            this.Close();


        }
    }
}
