using kurs5.DbModel;
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
    /// Логика взаимодействия для AddBuyWin.xaml
    /// </summary>
    public partial class AddBuyWin : Window
    {
        DbModel.Model3 ds3 = new DbModel.Model3();
        public AddBuyWin()
        {
            InitializeComponent();
        }
        BuyTable bt = new BuyTable();
        private void AddDT_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            if (ID.Text == "" || Naz.Text == "" || Cena.Text == "" || Status.Text == "")
            {
                sb.Append("Есть пустые поля");
            }
            int a = int.Parse(ID.Text);
            if (ds3.BuyTable.Where(x => x.id_pok == a).FirstOrDefault() != null)
            {
                sb.Append("Уже есть такой номер");
            }
            string vv = " руб.";
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
            }
            else
            {
                bt.id_pok = int.Parse(ID.Text);
                bt.Nazvanie = Naz.Text;
                bt.Price = Cena.Text + vv;
                bt.Status = Status.Text;
                ds3.BuyTable.Add(bt);
                ds3.SaveChanges();
                MessageBox.Show("Успешно записано");
            }
        }

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
