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
using System.Windows.Shapes;

namespace kurs5
{
    /// <summary>
    /// Логика взаимодействия для AvWindow.xaml
    /// </summary>
    public partial class AvWindow : Window
    {
        public AvWindow()
        {
            InitializeComponent();
            FRFR.Navigate(new MP());
        }
        private void BT1_Click(object sender, RoutedEventArgs e)
        {
            FRFR.Navigate(new ABP());
        }
        private void BT2_Click(object sender, RoutedEventArgs e)
        {

            FRFR.Navigate(new BuyPage());
        }
        private void BT4_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }
}
