using LabSes1.Classes;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LabSes1.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            TbLogin.Text = 1.ToString();
            PbPassword.Password = 1.ToString();
        }

        private void BtnSingIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Login = DataBase.db.User.FirstOrDefault(
                    x => x.Login == TbLogin.Text && x.Password == PbPassword.Password);
                if (Login != null && TbLogin.Text.Length != 0 && PbPassword.Password.Length != 0)
                {
                    UserID.ID = Login.Id;
                    switch (Login.RoleId)
                    {
                        case 1:
                            FrameClass.frm.Navigate(new LaborantForm());
                            break;
                        case 2:
                            FrameClass.frm.Navigate(new LaborantForm());
                            break;
                    }
                    DB.Activity activity = new DB.Activity()
                    {
                        Login = Login.Login,
                        SuccessLogin = true,
                        TimeLogin = DateTime.Now,
                    };
                    DataBase.db.Activity.Add(activity);
                    DataBase.db.SaveChanges();
                }
                else
                {
                    if (Login == null)
                    {
                        MessageBox.Show("Введите правильный логин и пароль", "Ошибка", MessageBoxButton.OK);
                        DB.Activity activity = new DB.Activity()
                        {
                            Login = TbLogin.Text,
                            SuccessLogin = false,
                            TimeLogin = DateTime.Now,
                        };
                    }
                    else if (TbLogin.Text.Length != 0 || PbPassword.Password.Length != 0)
                    {
                        MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK);
                    }
                }

            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnSeeHistory_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frm.Navigate(new HistoryaPage());
        }

        private void BtnSeebarcode_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frm.Navigate(new barcode());
        }
    }
}
