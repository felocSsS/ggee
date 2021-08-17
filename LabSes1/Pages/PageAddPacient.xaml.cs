using LabSes1.Classes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LabSes1.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddPacient.xaml
    /// </summary>
    public partial class PageAddPacient : Page
    {
        public PageAddPacient()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DB.Patient patient = new DB.Patient()
            {
                Name = tbName.Text,
                Passport = Convert.ToInt32(tbPassport.Text),
                PhoneNumber = Convert.ToInt32(tbPhone.Text),
                Email = tbEmail.Text,
                InsuranceNumber = Convert.ToInt32(tbNumberStrazovania.Text),
                IdTypeOfInsuranceNumber = 1,
                Birthday = Convert.ToDateTime(tbAge.Text)
            };
            try
            {
                DataBase.db.Patient.Add(patient);
                DataBase.db.SaveChanges();
                MessageBox.Show("Пациент добавлен", "Успех", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrmMakeOrder.GoBack();
        }
    }
}
