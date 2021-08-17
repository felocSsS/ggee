using LabSes1.Pages;
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

namespace LabSes1.Windows
{
    /// <summary>
    /// Логика взаимодействия для MakeOrderWindow.xaml
    /// </summary>
    public partial class MakeOrderWindow : Window
    {
        public MakeOrderWindow()
        {
            InitializeComponent();
            Classes.FrameClass.FrmMakeOrder = Frm;
            Classes.FrameClass.FrmMakeOrder.Navigate(new PageMakeOrder());
        }

        private void BtnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnHideApp_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
