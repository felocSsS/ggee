using LabSes1.Classes;
using LabSes1.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LabSes1.Pages
{
    /// <summary>
    /// Логика взаимодействия для LaborantForm.xaml
    /// </summary>
    public partial class LaborantForm : Page
    {
        public LaborantForm()
        {
            InitializeComponent();
            var NameAndAge = DataBase.db.User.FirstOrDefault(
                x => x.Id == UserID.ID);
            string ThisYear = DateTime.Now.ToString();
            string YearOfBirthday = NameAndAge.Birthday.ToString();
            string test = (Convert.ToInt32(ThisYear.Substring(6, ThisYear.Length - 15)) - Convert.ToInt32(YearOfBirthday.Substring(6, ThisYear.Length - 15))).ToString();
            TbName.Text = NameAndAge.Name + "   Возраст: " + test;
            if(UserID.ID == 1)
            {
                BtnUseAnalyzer.Visibility = Visibility.Collapsed;
            }
            else if(UserID.ID == 2)
            {
                BtnUseAnalyzer.Visibility = Visibility.Visible;
            }
            else
            {
                FrameClass.frm.Navigate(new LoginPage());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frm.GoBack();
        }

        private void BtnUseAnalyzer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMakeOrder_Click(object sender, RoutedEventArgs e)
        {
            MakeOrderWindow newWindow = new MakeOrderWindow();
            newWindow.Show();
        }

        private void BtnFindPatient_Click(object sender, RoutedEventArgs e)
        {
            MakeOrderWindow newWindow = new MakeOrderWindow();
            newWindow.Show();
        }
    }
}
