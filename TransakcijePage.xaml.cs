using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
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
    /// Interaction logic for TransakcijePage.xaml
    /// </summary>
    public partial class TransakcijePage : Page
    {
        public ISeries[] MySeries { get; set; }
        public List<decimal> Labels { get; set; }
        public TransakcijePage()
        {
            InitializeComponent();
            MySeries = new ISeries[]
          {
                new ColumnSeries<double>
                {
                    Name = "Uplate",
                    Values = App.context.Uplata.Select(x => (double)x.Uplata_novac).ToArray()
                }
          };

            Labels = App.context.Uplata.Select(u => u.Uplata_novac).ToList();

            DataContext = this;
        }
    }
    }


