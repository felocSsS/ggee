/*using System;
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
    /// Логика взаимодействия для barcode.xaml
    /// </summary>
    public partial class barcode : Page
    {
        public barcode()
        {
            InitializeComponent();
        }

        private int[,] sets = new int[10, 3] { { 10001101, 10100111, 1110010 }, //0
{ 10011001, 10110011, 1100110 }, //1
{ 10010011, 10011011, 1101100 }, //2
{ 10111101, 10100001, 1000010 }, //3
{ 10100011, 10011101, 1011100 }, //4
{ 10110001, 10111001, 1001110 }, //5
{ 10101111, 10000101, 1010000 }, //6
{ 10111011, 10010001, 1000100 }, //7
{ 10110111, 10001001, 1001000 }, //8
{ 10001011, 10010111, 1110100 } }; //9

        private int[,] first6digits = new int[10, 6] { { 1, 1, 1, 1, 1, 1 }, //0
{ 1, 1, 2, 1, 2, 2 }, //1
{ 1, 1, 2, 2, 1, 2 }, //2
{ 1, 2, 2, 2, 2, 1 }, //3
{ 1, 2, 1, 1, 2, 2 }, //4
{ 1, 2, 2, 1, 1, 2 }, //5
{ 1, 2, 2, 2, 1, 1 }, //6
{ 1, 2, 1, 2, 1, 2 }, //7
{ 1, 2, 1, 2, 2, 1 }, //8
{ 1, 2, 2, 1, 2, 1 } }; //9

        private int[] StartAndEndРatch = new int[] { 0, 1, 0, 1, 0 };

        private void BtnGenerateBarCode_Click(object sender, RoutedEventArgs e)
        {
            string code;
            code = TbNumber.Text;
            char[] codeInCharAMassiv = new char[12];
            codeInCharAMassiv = code.ToCharArray(0, code.Length);

            for (int i = 0; i < 15; i++)
            {
                GenerateBarCode(i, (int)(codeInCharAMassiv[0] - '0'), codeInCharAMassiv);
            }
        }
        void GenerateBarCode(int step, int firstNumber, char[] test)
        {
            if (step == 0 || step == 7 || step == 14) //генерация начала и конца штрих кода
            {
                int number = 5;
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

            *//*if(step > 0 && step < 7)
            {
            int number = 5;
            int width = 2;
            int height = 100;

            for (int i = 0; i < number; i++)
            {
            if (sets[(int)(test[step]-'0'), first6digits[firstNumber, number]] == 1)
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
            Fill = Brushes.Black,
            };
            Sp.Children.Add(rec);
            }
            }
            }

            if (step > 7 && step < 14)
            {
            int number = 5;
            int width = 2;
            int height = 100;

            for (int i = 0; i < number; i++)
            {
            if (*//*sets[(int)(test[step - 1-'0']), 2] == 1*//*true)
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
            }*//*

            if (step > 0 && step < 7)
            {
                int number = 5;
                int width = 2;
                int height = 100;

                int cheak = sets[(int)(test[step] - '0'), first6digits[firstNumber, number] - 1];
                string wihge = cheak.ToString();
                char[] wefgw = wihge.ToCharArray(0, wihge.Length);

                for (int i = 1; i < 8; i++)
                {
                    int cheak2 = (int)(wefgw[i] - '0');
                    if ((int)(wefgw[i] - '0') == 1)
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
*/