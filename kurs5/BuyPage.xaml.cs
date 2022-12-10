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
    /// Логика взаимодействия для BuyPage.xaml
    /// </summary>
    public partial class BuyPage : Page
    {
        DbModel.Model2 bd2 = new DbModel.Model2();
        DbModel.Model3 ds3 = new DbModel.Model3();
        public BuyPage()
        {
            InitializeComponent();
            bd2.Knigi.Load();
            dtgBook.ItemsSource = bd2.Knigi.Local;
            ds3.BuyTable.Load();
            dtgBuy.ItemsSource = ds3.BuyTable.Local;
            if (Manager.manager == true)
            {
                ABT.Visibility = Visibility.Visible;
                DeleteBT.Visibility = Visibility.Visible;
                RefBT.Visibility = Visibility.Visible;
            }
            else
            {
                ABT.Visibility = Visibility.Hidden;
                DeleteBT.Visibility = Visibility.Hidden;
                RefBT.Visibility = Visibility.Hidden;
            }
        }

        Knigi kn = new Knigi();
        BuyTable bt = new BuyTable();
        private void BuyBT_Click(object sender, RoutedEventArgs e)
        {
            string rr = "Отложено";
            kn = (Knigi)dtgBook.SelectedItem;
            int a = int.Parse(VID.Text);
            if (kn != null)
            {
                if (ds3.BuyTable.Where(x => x.id_pok == a).FirstOrDefault() != null)
                {
                    MessageBox.Show("Уже есть такой номер");
                }
                else
                {
                    bt.id_pok = int.Parse(VID.Text);
                    bt.Nazvanie = kn.Kniga;
                    bt.Price = kn.Cena;
                    bt.Status = rr;
                    ds3.BuyTable.Add(bt);
                    ds3.SaveChanges();
                    MessageBox.Show("Успешно");
                }
            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            MP mP = new MP();
            this.NavigationService.Navigate(mP);
        }

        private void ABT_Click(object sender, RoutedEventArgs e)
        {
            AddBuyWin addByuWin = new AddBuyWin();
            addByuWin.Show();
        }

        BuyTable buy = new BuyTable();
        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            buy = (BuyTable)dtgBuy.SelectedItem;
            if (buy != null)
            {
                if (MessageBox.Show("Вы действительно хотите убрать запись ?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ds3.BuyTable.Remove(buy);
                    ds3.SaveChanges();
                }
            }
            else { MessageBox.Show("Вы ничего не выбрали"); }
        }

        private void RefBT_Click(object sender, RoutedEventArgs e)
        {
            bd2.Knigi.Load();
            dtgBook.ItemsSource = bd2.Knigi.Local;
            ds3.BuyTable.Load();
            dtgBuy.ItemsSource = ds3.BuyTable.Local;
        }

    }
}
