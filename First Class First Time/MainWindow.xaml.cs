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

namespace First_Class_First_Time
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string combin, temp;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InPut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Convert.ToChar(e.Text) < 60 || Convert.ToChar(e.Text) > 62) 
                e.Handled = true;
        }

        private void ConvertThis_Click(object sender, RoutedEventArgs e)
        {
            OutPut.Text = null;

            string[] alf = new string[3] {"A","B","C"};
            char[] sign = new char[3];
            char[] alfCheck = new char[4] { (char)65, (char)66, (char)67, (char)65};
            int limit = 0;

            combin = Convert.ToString(InPut.Text);

            for (int i = 0; i < 3; i++)
                sign[i] = (char)combin[i];

            for (int j = 0; j < 3; j++)
            {
                if (sign[j] == 62)
                    if(limit != 2)
                        Bigger(j);
                if (sign[j] == 61)
                    if (limit != 2)
                        Balance(j);
            }
            void Bigger(int num)
            {
                if(num < 2)
                {
                    temp = alf[num];
                    alf[num] = alf[num + 1];
                    alf[num + 1] = temp;
                }
                
                if(num - 1 >= 0)
                {
                    temp = alf[num - 1];
                    alf[num - 1] = alf[num];
                    alf[num] = temp;
                }
                limit++;
            }
            void Balance(int vari)
            {
                if (alfCheck[vari] < alfCheck[vari + 1])
                    Bigger(vari);
            }
            OutPut.Text = String.Join(null, alf);
        }
    }
}
