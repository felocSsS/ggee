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
    /// Логика взаимодействия для PageFindPatient.xaml
    /// </summary>
    public partial class PageFindPatient : Page
    {

        List<dynamic> RightPatients = new List<dynamic>();

        public PageFindPatient()
        {
            InitializeComponent();

        }

        private void btnFindPatient_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text) || !string.IsNullOrEmpty(tbBirthday.Text) || 
                !string.IsNullOrEmpty(tbEmail.Text) || !string.IsNullOrEmpty(tbNumberStrazovania.Text) || 
                !string.IsNullOrEmpty(tbPassport.Text) || !string.IsNullOrEmpty(tbPhone.Text)) 
            {
                CalculateLevenstein();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK);
            }
        }

        private void CalculateLevenstein()
        {
            var Patients = DataBase.db.Patient.ToList();

            foreach (var Patient in Patients)
            {
                int CurrentPatient = levenshtein(tbName.Text, Patient.Name);

                string Date = Patient.Birthday.ToString().Substring(0, Patient.Birthday.ToString().Length - 8);

                if (CurrentPatient <= 3 && Date == tbBirthday.Text && tbEmail.Text == Patient.Email &&
                    Convert.ToInt32(tbNumberStrazovania.Text) == Patient.InsuranceNumber && 
                    Convert.ToInt32(tbPassport.Text) == Patient.Passport && Convert.ToInt32(tbPhone.Text) == Patient.PhoneNumber)
                {
                    RightPatients.Add(Patient);
                }
            }

            dtPatientList.ItemsSource = RightPatients;
        }

        int levenshtein(String a, String b)
        {
            if (string.IsNullOrEmpty(a))
            {
                if (!string.IsNullOrEmpty(b))
                {
                    return b.Length;
                }
                return 0;
            }

            if (string.IsNullOrEmpty(b))
            {
                if (!string.IsNullOrEmpty(a))
                {
                    return a.Length;
                }
                return 0;
            }

            int[,] mas = new int[a.Length + 1, b.Length + 1];
            int min1 = 0;
            int min2 = 0;
            int min3 = 0;

            for (int i = 0; i <= mas.GetUpperBound(0); i += 1)
            {
                mas[i, 0] = i;
            }
            for (int i = 0; i <= mas.GetUpperBound(1); i += 1)
            {
                mas[0, i] = i;
            }
            for (int i = 1; i <= mas.GetUpperBound(0); i += 1)
            {
                for (int j = 1; j <= mas.GetUpperBound(1); j += 1)
                {
                    if (a[i - 1] == b[j - 1])
                    {
                        min3 = mas[i - 1, j - 1];
                    }
                    else
                    {
                        min1 = mas[i - 1, j] + 1;
                        min2 = mas[i, j - 1] + 1;
                        min3 = mas[i - 1, j - 1] + 1;
                    }
                    mas[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return mas[mas.GetUpperBound(0), mas.GetUpperBound(1)];
        }

        private void BtnSelectPatient_Click(object sender, RoutedEventArgs e)
        {
            /*AppFrame.frameMain.Navigate(new PageJournalStudent((sender as Button).DataContext as Student));*/
        }
    }
}
