
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
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
using iText.Layout.Borders;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Font;


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
               .OrderByDescending(u => u.IdUplate)
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
               .OrderByDescending(u => u.IdUplate)
               .Select(u => (decimal?)u.PreostaliDug)
               .FirstOrDefault() ?? selectedKredit.UkupanIznos; // ako nema uplate, vrati cijeli iznos

            UplataWindow uplataWindow = new UplataWindow(this);
            uplataWindow.Show();

        }

        private void btnZahtjev_Click(object sender, RoutedEventArgs e)
        {
            List<int> loggedKrediti = App.context.Kredit
          .Where(k => k.IdKorisnik == App.loggedUser.IdKorisnik)
          .Select(k => k.IdKredit).ToList();

            

            if (loggedKrediti.Count > 3)
            {
                MessageBox.Show("Trenutno imate otvoreno više od 3 kredita, ne zadovoljavate zahtjeve!");
                btnZahtjev.IsEnabled = false;
            }
            else
            {
                ZahtjevWindow zahtjevWindow = new ZahtjevWindow();
                zahtjevWindow.Show();   
            }


        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            var selectedObject = listKrediti.SelectedItem as KreditView;
            if (selectedObject == null)
            {
                MessageBox.Show("Molimo odaberite kredit za uplatu.");
                return;
            }

            Kredit kredit = App.context.Kredit.FirstOrDefault(k => k.IdKredit == selectedObject.IdKredit);

           
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"OtplatniPlan_Kredit_{kredit.IdKredit}.pdf"; 
            bool? result = saveFileDialog.ShowDialog();

            if (result != true)
            {
                return;
            }

            string outputPath = saveFileDialog.FileName; 

            using (PdfWriter writer = new PdfWriter(outputPath))
            using (PdfDocument pdf = new PdfDocument(writer))
            using (Document document = new Document(pdf))
            {
                PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                PdfFont boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
                document.SetFont(font);

                // Naslov
                iText.Layout.Element.Paragraph title = new iText.Layout.Element.Paragraph("Otplatni plan kredita")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetFontSize(18)
                    .SetFont(boldFont);
                document.Add(title);

                // Prazni red
                document.Add(new iText.Layout.Element.Paragraph("\n"));

                // Opći podaci
                document.Add(new iText.Layout.Element.Paragraph($"Vrsta kredita: {kredit.VrstaKredita}"));
                document.Add(new iText.Layout.Element.Paragraph($"Datum pozajmice: {kredit.DatumPozajmice.ToDateTime(new TimeOnly(0, 0)).ToShortDateString()}"));
                document.Add(new iText.Layout.Element.Paragraph($"Glavnica: {kredit.Glavnica} €"));
                document.Add(new iText.Layout.Element.Paragraph($"Kamatna stopa: {kredit.KamatnaStopa}%"));
                document.Add(new iText.Layout.Element.Paragraph($"Vrijeme otplate: {kredit.VrijemeOtplate} mjeseci"));
                document.Add(new iText.Layout.Element.Paragraph($"Ukupan iznos za vratiti: {kredit.UkupanIznos} €"));

                // Prazni red
                document.Add(new iText.Layout.Element.Paragraph("\n"));

                // Tablica
                iText.Layout.Element.Table table = new iText.Layout.Element.Table(3, true);
                table.AddHeaderCell("Rata");
                table.AddHeaderCell("Datum");
                table.AddHeaderCell("Iznos (€)");
                table.SetBorder(new SolidBorder(1));


                decimal rataIznos = Math.Round(kredit.UkupanIznos / kredit.VrijemeOtplate, 2);
                DateTime datumPocetka = kredit.DatumPozajmice.ToDateTime(new TimeOnly(0, 0)).AddMonths(1);

                for (int i = 0; i < kredit.VrijemeOtplate; i++)
                {
                    table.AddCell((i + 1).ToString());
                    table.AddCell(datumPocetka.AddMonths(i).ToString("dd.MM.yyyy"));
                    table.AddCell(rataIznos.ToString("F2"));
                }
               
                document.Add(table);
                table.Complete();
            }

            MessageBox.Show($"PDF uspješno generiran: {outputPath}");

        }
    }
    }


