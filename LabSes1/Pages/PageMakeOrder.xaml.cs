using LabSes1.Classes;
using LabSes1.DB;
using LabSes1.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LabSes1.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMakeOrder.xaml
    /// </summary>
    public partial class PageMakeOrder : Page
    {
        private int NumberOfOrder = 0;
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MakeOrder(true);
/*            tbProbirka.Text = "";
            CmbName.SelectedValue = null;
            CmbService.SelectedValue = null;*/
            FrameClass.FrmMakeOrder.Navigate(new GeneratedOrder(NumberOfOrder));
        }

        private void BtnAddOneMoreService_Click(object sender, RoutedEventArgs e)
        {
            MakeOrder(false);
            CmbService.SelectedValue = null;
        }

        private void MakeOrder(bool NotOneMoreService)
        {
            var LastOrderFromThisPatient = DataBase.db.Order.Where(x => x.IdPatient == (int)CmbName.SelectedValue).ToList().LastOrDefault();

            int NumberOfOrder = LastOrderFromThisPatient == null ? (NumberOfOrder = 1) : (NumberOfOrder = (Convert.ToInt32(LastOrderFromThisPatient.NumberOfOrder) + Convert.ToInt32(NotOneMoreService)));

            try
            {
                DB.Order order = new DB.Order()
                {
                    IdLaboratoryWorker = (int)UserID.ID,
                    IdPatient = (int)CmbName.SelectedValue,
                    IdStatus = 1,
                    IdService = (int)CmbService.SelectedValue,
                    NumberOfTestTube = Convert.ToInt32(tbProbirka.Text),
                    NumberOfOrder = NumberOfOrder
                };
                DataBase.db.Order.Add(order);
                DataBase.db.SaveChanges();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnMakeBarCode_Click(object sender, RoutedEventArgs e)
        {
            Sp.Children.Clear();
            SpNumbers.Children.Clear();

            string code = tbProbirka.Text;

            for (int i = 0; i < 15; i++)
            {
                GenerateBarCode(i, code);
            }

            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(card, "Штрих-код");
            }
        }

        private int[,] sets = new int[10, 2] { { 10001101, 10100111}, //0
                                               { 10011001, 10110011}, //1
                                               { 10010011, 10011011}, //2
                                               { 10111101, 10100001}, //3
                                               { 10100011, 10011101}, //4
                                               { 10110001, 10111001}, //5
                                               { 10101111, 10000101}, //6
                                               { 10111011, 10010001}, //7
                                               { 10110111, 10001001}, //8
                                               { 10001011, 10010111} }; //9

        private int[] StartAndEndРatch = new int[] { 0, 1, 0, 1, 0 };


        void GenerateBarCode(int step, string numbers)
        {
            if (step == 0 || step == 7 || step == 14) //генерация начала, середины и конца штрих кода
            {
                int number = 5;

                if (step < 13 && step != 7)
                {
                    TextBlock tb = new TextBlock()
                    {
                        FontSize = 12,
                        Text = (numbers[step] - '0').ToString() + "    ",
                        VerticalAlignment = VerticalAlignment.Bottom,
                    };
                    SpNumbers.Children.Add(tb);
                }

                if (step == 7)
                {
                    TextBlock tb = new TextBlock()
                    {
                        FontSize = 12,
                        Text = " ",
                        VerticalAlignment = VerticalAlignment.Bottom,
                    };
                    SpNumbers.Children.Add(tb);
                }

                for (int i = 0; i < number; i++)
                {
                    if (StartAndEndРatch[i] == 1)
                    {
                        rectangle(true, 0);
                    }
                    else
                    {
                        rectangle(false, 0);
                    }
                }
            }

            if (step > 0 && step < 7)
            {
                int number = 7;

                for (int i = 0; i < number; i++)
                {
                    if (i == 4)
                    {
                        TextBlock tb = new TextBlock()
                        {
                            FontSize = 11,
                            Text = (numbers[step] - '0').ToString() + "   ",
                            VerticalAlignment = VerticalAlignment.Bottom,
                        };
                        SpNumbers.Children.Add(tb);
                    }
                    string CurrentSet = sets[(int)(numbers[step] - '0'), 0].ToString();
                    if ((int)(CurrentSet[i] + 1 - '0') == 1)
                    {
                        rectangle(true, 6);
                    }
                    else
                    {
                        rectangle(false, 6);
                    }
                }
            }

            if (step > 7 && step < 14)
            {
                int number = 7;

                for (int i = 0; i < number; i++)
                {
                    if (i == 4)
                    {
                        TextBlock tb = new TextBlock()
                        {
                            FontSize = 12,
                            Text = (numbers[step - 1] - '0').ToString() + "   ",
                            VerticalAlignment = VerticalAlignment.Bottom,
                        };
                        SpNumbers.Children.Add(tb);
                    }
                    string CurrentSet = sets[(int)(numbers[step - 2] - '0'), 1].ToString();
                    if ((int)(CurrentSet[i] + 1 - '0') == 1)
                    {
                        rectangle(true, 6);
                    }
                    else
                    {
                        rectangle(false, 6);
                    }
                }
            }
        }

        void rectangle(bool result, int LongStroke)
        {
            int width = 2;
            int height = 86;

            switch (result)
            {
                case true:
                    Rectangle rec = new Rectangle()
                    {
                        Width = width,
                        Height = height - LongStroke,
                        Fill = Brushes.Black,
                        VerticalAlignment = VerticalAlignment.Top
                    };
                    Sp.Children.Add(rec);
                    break;
                case false:
                    Rectangle rec1 = new Rectangle()
                    {
                        Width = width,
                        Height = height - LongStroke,
                        Fill = Brushes.White,
                        VerticalAlignment = VerticalAlignment.Top
                    };
                    Sp.Children.Add(rec1);
                    break;
            }
        }
        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrmMakeOrder.Navigate(new PageAddPacient());
        }
    }
}
