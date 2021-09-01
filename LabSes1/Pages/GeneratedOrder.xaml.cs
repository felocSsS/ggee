using LabSes1.Classes;
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

            var Services = DataBase.db.Order.Where(x => x.NumberOfOrder == NumberOfOrder.ToString()).ToList();
            var OneService = DataBase.db.Order.FirstOrDefault(x => x.NumberOfOrder == NumberOfOrder.ToString());

            TbBirthday.Text = OneService.Patient.Birthday.ToString().Substring(0, OneService.Patient.Birthday.ToString().Length - 8);
            TbDateOfOrder.Text = DateTime.Now.ToString();
            TbName.Text = OneService.Patient.Name;
            TbNumberOfInsuranceNumber.Text = "Номер соц. страхования: " + OneService.Patient.InsuranceNumber.ToString();
            TbNumberOfTestTube.Text = "Номер пробирки: " + OneService.NumberOfTestTube.ToString();
            TbOrder.Text = "Заказ № " + OneService.NumberOfOrder.ToString();

            int TotalPrice = 0;
            int SerialNumber = 1;

            foreach (var Service in Services)
            {
                TotalPrice += Convert.ToInt32(Service.Service.Price);
                GenerateTextBlock(SerialNumber.ToString(), new Thickness(0, 30 * SerialNumber, 0, 0), 18, VerticalAlignment.Top, HorizontalAlignment.Left);
                GenerateTextBlock("| " + Service.Service.Name, new Thickness(20, 30 * SerialNumber, 0, 0), 18, VerticalAlignment.Top, HorizontalAlignment.Left);
                GenerateTextBlock("| "+ Service.Service.Price + "   ", new Thickness(260, 30 * SerialNumber, 0, 0), 18, VerticalAlignment.Top, HorizontalAlignment.Left);
                SerialNumber += 1;
            }
            TbDateOfOrder.Margin = new Thickness(0, 60 + 20 * SerialNumber, 0, 20);
            TbTotalPrice.Text = "Итого: " + TotalPrice.ToString() + "Руб.";
        }

        private void GenerateTextBlock(string text, Thickness margin, double fontSize, VerticalAlignment verticalAlignment, HorizontalAlignment horizontalAlignment)
        {
            TextBlock tb = new TextBlock()
            {
                Text = text,
                Margin = margin,
                FontSize = fontSize,
                VerticalAlignment = verticalAlignment,
                HorizontalAlignment = horizontalAlignment
            };
            GridServices.Children.Add(tb);
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            BtnPrint.Visibility = Visibility.Hidden;
            PrintDialog dialog = new PrintDialog();
            SV.ScrollToTop();
            Grid.Height = SV.ExtentHeight;
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(Grid, "");
            }
            BtnPrint.Visibility = Visibility.Visible;
        }
    }
}
