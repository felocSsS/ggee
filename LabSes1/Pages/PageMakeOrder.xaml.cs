using LabSes1.Classes;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LabSes1.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMakeOrder.xaml
    /// </summary>
    public partial class PageMakeOrder : Page
    {
        public PageMakeOrder()
        {
            InitializeComponent();
            CmbName.SelectedValuePath = "Id";
            CmbName.DisplayMemberPath = "Name";
            CmbName.ItemsSource = DataBase.db.Patient.ToList();

            CmbService.SelectedValuePath = "Id";
            CmbService.DisplayMemberPath = "Name";
            CmbService.ItemsSource = DataBase.db.Service.ToList();
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrmMakeOrder.Navigate(new PageAddPacient());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DB.Order order = new DB.Order()
            {
                IdLaboratoryWorker = (int)UserID.ID,
                IdPatient = (int)CmbName.SelectedValue,
                Status = false,
                IdService = (int)CmbService.SelectedValue,
            };
            DataBase.db.Order.Add(order);
            DataBase.db.SaveChanges();
        }
    }
}
