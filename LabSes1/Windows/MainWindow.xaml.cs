using LabSes1.Classes;
using LabSes1.DB;
using LabSes1.Pages;
using System;
using System.Windows;
using System.Windows.Input;

namespace LabSes1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Classes.FrameClass.frm = Frm;
            Frm.Navigate(new LoginPage());
            DataBase.db = new Entities();
        }

        private void BtnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnHideApp_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
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
