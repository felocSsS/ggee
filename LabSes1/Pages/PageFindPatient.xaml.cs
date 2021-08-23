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
        public PageFindPatient()
        {
            InitializeComponent();
            tbSlovo1.Text = "Арестант";
            tbSlovo2.Text = "Дагестан";
        }

        private void BtnGetLevenshtein_Click(object sender, RoutedEventArgs e)
        {
            string Slovo1 = tbSlovo1.Text;
            string Slovo2 = tbSlovo2.Text;

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
                        if (a[i-1] == b[j-1])
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
            MessageBox.Show(levenshtein(Slovo1, Slovo2).ToString()); 
        }
    }
}
