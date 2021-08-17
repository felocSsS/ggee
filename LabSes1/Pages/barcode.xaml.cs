using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LabSes1.Pages
{
    /// <summary>
    /// Логика взаимодействия для barcode.xaml
    /// </summary>
    public partial class barcode : Page
    {
        public barcode()
        {
            InitializeComponent();
            TbNumber.Text = "123456789012";
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

        private int[] StartAndEndРatch = new int[] {1, 0, 1};

        private void BtnGenerateBarCode_Click(object sender, RoutedEventArgs e)
        {
            Sp.Children.Clear();
            string code = TbNumber.Text;
            code = TbNumber.Text;
            char[] codeInCharAMassiv = new char[12];
            codeInCharAMassiv = code.ToCharArray(0, code.Length);

            for (int i = 0; i < 15; i++)
            {
                GenerateBarCode(i, codeInCharAMassiv);
            }
        }
        void GenerateBarCode(int step, char[] numbers)
        {
            if (step == 0 || step == 7 || step == 14) //генерация начала, середины и конца штрих кода
            {
                int number = 3;
                int width = 2;
                int height = 100;

                for (int i = 0; i < number; i++)
                {
                    if (StartAndEndРatch[i] == 1)
                    {
                        Rectangle rec = new Rectangle()
                        {
                            Width = width,
                            Height = height,
                            Fill = Brushes.Black,
                        };
                        Sp.Children.Add(rec);
                    }
                    else
                    {
                        Rectangle rec = new Rectangle()
                        {
                            Width = width,
                            Height = height,
                            Fill = Brushes.White,
                        };
                        Sp.Children.Add(rec);
                    }
                }
            }
           
            if (step > 0 && step < 7)
            {
                int number = 7;
                int width = 2;
                int height = 100;
                for (int i = 0; i < number; i++)
                {
                    string CurrentSet = sets[(int)(numbers[step] - '0'), 0].ToString();
                    if ((int)(CurrentSet[i] + 1  - '0') == 1)
                    {
                        Rectangle rec = new Rectangle()
                        {
                            Width = width,
                            Height = height - 20,
                            Fill = Brushes.Black,
                        };
                        Sp.Children.Add(rec);
                    }
                    else
                    {
                        Rectangle rec = new Rectangle()
                        {
                            Width = width,
                            Height = height - 20,
                            Fill = Brushes.White,
                        };
                        Sp.Children.Add(rec);
                    }
                }
            }

            if (step > 7 && step < 14)
            {
                int number = 7;
                int width = 2;
                int height = 100;

                for (int i = 0; i < number; i++)
                {
                    int test = (int)(numbers[step - 2] - '0');
                    string CurrentSet = sets[(int)(numbers[step - 2] - '0'), 1].ToString();
                    if ((int)(CurrentSet[i] + 1 - '0') == 1)
                    {
                        Rectangle rec = new Rectangle()
                        {
                            Width = width,
                            Height = height - 20,
                            Fill = Brushes.Black,
                        };
                        Sp.Children.Add(rec);
                    }
                    else
                    {
                        Rectangle rec = new Rectangle()
                        {
                            Width = width,
                            Height = height - 20,
                            Fill = Brushes.White,
                        };
                        Sp.Children.Add(rec);
                    }
                }
            }
        }

    }
}
