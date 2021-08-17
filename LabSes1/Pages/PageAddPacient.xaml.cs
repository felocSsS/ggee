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
                IdTypeOfInsuranceNumber = 1
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
