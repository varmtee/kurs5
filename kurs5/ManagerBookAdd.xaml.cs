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
    /// Логика взаимодействия для ManagerBookAdd.xaml
    /// </summary>
    public partial class ManagerBookAdd : Window
    {
        DbModel.Model2 gg = new DbModel.Model2();
        public ManagerBookAdd()
        {
            InitializeComponent();
        }
        private void AddDT_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder qq = new StringBuilder();
            int a = int.Parse(ID.Text);
            string ff = Naz.Text;
            if (gg.Knigi.Where(x => x.id_book == a).FirstOrDefault() != null)
            {
                qq.Append("Уже есть такой номер");
            }
            if (gg.Knigi.Where(x => x.Kniga == ff).FirstOrDefault() != null)
            {
                qq.Append("Уже есть такая книга");
            }
            if (ID.Text == "" || Naz.Text == "" || Avtor.Text == "" || Price.Text == "")
            {
                qq.Append("Есть пустые поля");
            }
            if (qq.Length > 0)
            {
                MessageBox.Show(qq.ToString());
            }
            else
            {
                string rub = " руб.";
                Knigi kn = new Knigi();
                kn.id_book = int.Parse(ID.Text);
                kn.Kniga = Naz.Text;
                kn.Avtor = Avtor.Text;
                kn.Cena = Price.Text + rub;
                gg.Knigi.Add(kn);
                gg.SaveChanges();
                MessageBox.Show("Книга записана");
            }
        }

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
