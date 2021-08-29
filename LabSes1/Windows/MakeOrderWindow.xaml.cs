using LabSes1.Pages;
using System;
using System.Windows;
using System.Windows.Controls;

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

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
