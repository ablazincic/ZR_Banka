using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZR_Banka.Models;
using System.Diagnostics;
using System.Windows.Media.Animation;

namespace ZR_Banka;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class LoginWindow : Window
{

    public LoginWindow()
    {
        InitializeComponent();
          
       
    }

    private void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        var provjeraUsername = App.context.Korisnik.FirstOrDefault(x => x.Username.ToLower() == txtUsername.Text.ToLower());
        var provjeraPassworda = App.context.Korisnik.FirstOrDefault(x => x.Password == txtPassword.Password);

        if (provjeraPassworda != null && provjeraUsername != null)
        {
            lblWarning.Content = " ";
            App.loggedUser = App.context.Korisnik.FirstOrDefault(x => x.Username == txtUsername.Text) as Korisnik;
            
      
            MainWindow main = new MainWindow();
            this.Hide();
            main.Show();
        }
        else if(provjeraPassworda == null || provjeraUsername == null)
        {
            
            this.RegisterName("lblWarning", lblWarning);
            this.RegisterName("WarningTransform", lblWarning.RenderTransform);
            lblWarning.Content = "Neuspješna prijava, provjerite username ili zaporku!";
       
            Storyboard sb = (Storyboard)FindResource("ShakeAnimation");
            sb.Begin(this);

        }


    }

    private void btnRegistracija_Click(object sender, RoutedEventArgs e)
    {
        RegistrationWindow regWindow = new RegistrationWindow();

        this.Hide();
        regWindow.Show(); 
        
    }

    private void Exit_program(object sender, EventArgs e)
    {
        Environment.Exit(0);
    }

}