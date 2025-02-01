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

namespace Пр1_ПИТ_422_Frantsuzov
{
    public partial class MainWindow : Window
    {
        public MainWindow() { InitializeComponent(); }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Вы уверены, что хотите выйти?",
                "Подтверждение выхода",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.No) e.Cancel = true; 
        }

        double F_Check(double x)
        {
            if (Checked_shx.IsChecked == true) return Math.Sinh(x);
            else if (Checked_x_2.IsChecked == true) return Math.Pow(x, 2);
            else return Math.Exp(x);
        }

        double CalculateResult(double f, double b, double x)
        {
            if (1 < x*b && x*b < 10) return Math.Exp(f);
            else if (12 < x*b && x*b < 40) return Math.Sqrt(Math.Abs(f + 4*b));
            else return b * Math.Pow(f, 2);
        }

        private void Calc_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = double.Parse(TextBox_x.Text);
                double b = double.Parse(TextBox_b.Text);
                double f = F_Check(x);
                string res = CalculateResult(f, b, x).ToString();
                TextBox_res.Text = res;
            }
            catch { MessageBox.Show("Ошибка ввода"); }
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox_res.Text = "";
            TextBox_x.Text = "";
            TextBox_b.Text = "";
        }
    }
}
