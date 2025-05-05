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
    /// Interaction logic for PostavkePage.xaml
    /// </summary>
    public partial class PostavkePage : Page
    {
        public PostavkePage()
        {
            InitializeComponent();
            if (App.loggedUser.Uloga.ToLower() == "administrator")
            {
                btnAdministrator.Visibility = Visibility.Visible;
                btnBankar.Visibility = Visibility.Visible;
            }
            else if(App.loggedUser.Uloga.ToLower() == "bankar")
            {
                btnAdministrator.IsEnabled = false;
                btnAdministrator.Background = Brushes.Gray;
                btnAdministrator.BorderBrush = Brushes.Gray;
                btnBankar.Visibility = Visibility.Visible;
            }
            else
            {
                btnAdministrator.IsEnabled = false;
                btnAdministrator.Background = Brushes.Gray;
                btnAdministrator.BorderBrush = Brushes.Gray;
               
                btnBankar.IsEnabled = false;
                btnBankar.Background = Brushes.Gray;
                btnBankar.BorderBrush = Brushes.Gray;
            }
          
        }

        private void btnPromijeni_Click(object sender, RoutedEventArgs e)
        {
            if (txtCurrentPassword.Password == App.loggedUser.Password && txtNewPassword.Password.Any(char.IsDigit))
            {
                App.context.Korisnik.FirstOrDefault(x => x.IdKorisnik == App.loggedUser.IdKorisnik).Password = txtNewPassword.Password;
                App.context.SaveChanges();

                MessageBox.Show("Lozinka uspješno promijenjena!");
                txtCurrentPassword.Clear();
                txtNewPassword.Clear();

            }
            else
            {
                MessageBox.Show("Pogrešan unos!");
            }
        }

        private void btnAdministrator_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
        }
    }
}
