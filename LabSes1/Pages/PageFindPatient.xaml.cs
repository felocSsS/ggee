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
        }

        private void BtnGetLevenshtein_Click(object sender, RoutedEventArgs e)
        {
            string Slovo1 = tbSlovo1.Text;
            string Slovo2 = tbSlovo2.Text;

            int Levenshtein = 0;
            /*for (int i = 0; i < tbSlovo1.Text.Length; i++)
            {
                if(Slovo1[i] == Slovo2[i])
                {
                    Levenshtein = Levenshtein + 0;
                }
                else
                {
                    Levenshtein = Levenshtein + 1;
                }
            }
            MessageBox.Show(Levenshtein.ToString());*/
            Int32 levenshtein(String a, String b)
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
                Int32 cost;
                Int32[,] d = new int[a.Length + 1, b.Length + 1];
                Int32 min1;
                Int32 min2;
                Int32 min3;
                for (Int32 i = 0; i <= d.GetUpperBound(0); i += 1)
                {
                    d[i, 0] = i;
                }
                for (Int32 i = 0; i <= d.GetUpperBound(1); i += 1)
                {
                    d[0, i] = i;
                }
                for (Int32 i = 1; i <= d.GetUpperBound(0); i += 1)
                {
                    for (Int32 j = 1; j <= d.GetUpperBound(1); j += 1)
                    {
                        cost = Convert.ToInt32(!(a[i - 1] == b[j - 1]));

                        min1 = d[i - 1, j] + 1;
                        min2 = d[i, j - 1] + 1;
                        min3 = d[i - 1, j - 1] + cost;
                        d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                    }
                }
                return d[d.GetUpperBound(0), d.GetUpperBound(1)];
            }
            MessageBox.Show(levenshtein(Slovo1, Slovo2).ToString()); 
        }
    }
}
