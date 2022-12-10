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
using System.Windows.Shapes;

namespace kurs5
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        DbModel.Model1 qw = new DbModel.Model1();
        public RegWindow()
        {
            InitializeComponent();
        }

        private void BT2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BT1_Click(object sender, RoutedEventArgs e)
        {
            qw.Users.Load();
            int z = int.Parse(ID.Text);
            StringBuilder st = new StringBuilder();
            if (Surname.Text == "" || Name.Text == "" || Telefon.Text == "" || Email.Text == "" || Login.Text == "" || Parol.Password == "")
            {
                st.Append("Есть пустые поля\n");
            }
            if (qw.Users.Where(x => x.Id == z).FirstOrDefault() != null)
            {
                st.Append("Уже есть такое ID");
            }
            string lg = Login.Text;
            string ps = Parol.Password;
            if (qw.Users.Where(x => x.Login == lg || x.Password == ps).FirstOrDefault() != null)
            {
                st.Append("Уже ест такие пароль или логин");
            }
            if (st.Length > 0)
            {
                MessageBox.Show(st.ToString());
            }
            else
            {
                Users us = new Users();
                us.Id = int.Parse(ID.Text);
                us.Surname = Surname.Text;
                us.Name = Name.Text;
                us.Phone = Telefon.Text;
                us.Mail = Email.Text;
                us.Login = Login.Text;
                us.Password = Parol.Password;
                qw.Users.Add(us);
                qw.SaveChanges();
                MessageBox.Show("++++++++++++++++");
            }
        }

    }
}
