using kurs5.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace kurs5
{
    /// <summary>
    /// Логика взаимодействия для ABP.xaml
    /// </summary>
    public partial class ABP : Page
    {
        DbModel.Model2 zxc = new DbModel.Model2();
        public ABP()
        {
            zxc.Knigi.Load();
            InitializeComponent();
            dtgBook.ItemsSource = zxc.Knigi.Local;
            if (Manager.manager == true)
            {
                DBT.Visibility = Visibility.Visible;
                YBT.Visibility = Visibility.Visible;
                OBT.Visibility = Visibility.Visible;
            }
            else
            {
                DBT.Visibility = Visibility.Hidden;
                YBT.Visibility = Visibility.Hidden;
                OBT.Visibility = Visibility.Hidden;
            }
        }

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            MP mP = new MP();
            this.NavigationService.Navigate(mP);
        }

        private void DBT_Click(object sender, RoutedEventArgs e)
        {
            ManagerBookAdd managerBookAdd = new ManagerBookAdd();
            managerBookAdd.Show();
        }

        Knigi kn = new Knigi();
        private void YBT_Click(object sender, RoutedEventArgs e)
        {
            kn = (Knigi)dtgBook.SelectedItem;
            if (kn != null)
            {
                if (MessageBox.Show("Вы действительно хотите убрать запись ?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    zxc.Knigi.Remove(kn);
                    zxc.SaveChanges();
                }
            }
            else { MessageBox.Show("Вы ничего не выбрали"); }
        }

        private void OBT_Click(object sender, RoutedEventArgs e)
        {
            zxc.Knigi.Load();
            dtgBook.ItemsSource = zxc.Knigi.Local;
        }

    }
}
