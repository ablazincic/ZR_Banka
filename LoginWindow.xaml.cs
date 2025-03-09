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

    private readonly ZrBankaDbContext context;

    public LoginWindow()
    {
        InitializeComponent();

        context = App.ServiceProvider.GetService<ZrBankaDbContext>();




    


    }

    private void btnLogin_Click(object sender, RoutedEventArgs e)
    {

    }
}