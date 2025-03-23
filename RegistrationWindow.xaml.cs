using Microsoft.Extensions.DependencyInjection;
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
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();


        }

        private void Window_Closed(object sender, EventArgs e)
        {
            LoginWindow loginWin = new LoginWindow();

            this.Hide();
            loginWin.Show();
        }

        private void btnKreiraj_Click(object sender, RoutedEventArgs e)
        {
            var inputMail = App.context.Korisnik.FirstOrDefault(x => x.Mail == txtMail.Text);
     
            if (inputMail == null && txtMail.Text.Contains("@") && txtPassword.Password.Any(char.IsDigit))
            {
                Korisnik korisnik = new Korisnik(txtIme.Text, txtPrezime.Text, txtUsername.Text, txtPassword.Password, txtMail.Text, "klijent");
                App.context.Add(korisnik);
                App.context.SaveChanges();
                lblWarning.Content = "";

                Window_Closed(1,e);
               
            }
            else if(inputMail == null && !(txtMail.Text.Contains("@")) && txtPassword.Password.Any(char.IsDigit))
            {
                lblWarning.Content = "Neuspješna registracija, vaša e-mail adresa ne sadrži @!";
            }
            else if(inputMail == null && txtMail.Text.Contains("@") && !(txtPassword.Password.Any(char.IsDigit)))
            {
                lblWarning.Content = "Neuspješna registracija, vaša zaporka ne sadrži brojke!";
            }

        }
    }
}
