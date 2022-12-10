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
using System.Windows.Threading;

namespace kurs5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbModel.Model1 ew = new DbModel.Model1();
        public MainWindow()
        {
            InitializeComponent();
        }
        int qwe = 0;
        DispatcherTimer timer = new DispatcherTimer();
        private void BT1_Click(object sender, RoutedEventArgs e)
        {
            ew.Users.Load();
            if (ew.Users.Where(x => Log.Text == x.Login && Parol.Password == x.Password).FirstOrDefault() != null)
            {
                if (ew.Users.Where(x => Log.Text == x.Login && Parol.Password == x.Password && x.Manager == true).FirstOrDefault() != null)
                {
                    Manager.manager = true;
                }
                else { Manager.manager = false; }
                MessageBox.Show("Вход выполнен успешно");
                AvWindow avWindow = new AvWindow();
                avWindow.Show();
                this.Close();
            }
            else if (ew.Users.Where(x => Log.Text != x.Login || Parol.Password != x.Password).FirstOrDefault() != null)
            {
                qwe++;
                MessageBox.Show("Пароль или логин не верен");
            }
            if (qwe >= 3)
            {
                MessageBox.Show("Вход заблокирован на 1 минуту");
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = new TimeSpan(0, 0, 60);
                BT1.Visibility = Visibility.Hidden;
                timer.Start();
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            BT1.Visibility = Visibility.Visible;
        }
        private void BT2_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
        private void BT3_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
            regWindow.Show();
            this.Close();
        }
    }

}
