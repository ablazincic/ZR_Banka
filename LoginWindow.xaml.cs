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
            MessageBox.Show("korisnik ima dobre podatke ");
        }
        else
        {
            lblWarning.Content = "Nešto ne valja! Provjerite lozinku ili username.";
        }

    }

    private void btnRegistracija_Click(object sender, RoutedEventArgs e)
    {
        RegistrationWindow regWindow = new RegistrationWindow();

        this.Hide();
        regWindow.Show(); // prebacivanje na okvir za registraciju
        
    }

    private void Exit_program(object sender, EventArgs e)
    {
        Environment.Exit(0); //exitanje aplikacije putem X gumba
    }

}