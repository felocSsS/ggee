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

namespace LabSes1.Pages
{
    /// <summary>
    /// Логика взаимодействия для GeneratedOrder.xaml
    /// </summary>
    public partial class GeneratedOrder : Page
    {
        public GeneratedOrder(int NumberOfOrder)
        {
            InitializeComponent();
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        { 
            PrintDialog dialog = new PrintDialog();
            SV.ScrollToTop();
            Grid.Height = SV.ExtentHeight;
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(Grid, "");
            }
        }
    }
}
