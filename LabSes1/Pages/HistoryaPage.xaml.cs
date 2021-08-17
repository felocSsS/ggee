using LabSes1.Classes;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LabSes1.Pages
{
    /// <summary>
    /// Логика взаимодействия для HistoryaPage.xaml
    /// </summary>
    public partial class HistoryaPage : Page
    {
        public HistoryaPage()
        {
            InitializeComponent();
            HistoryDataGrid.ItemsSource = DataBase.db.Activity.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frm.GoBack();
        }
    }
}
