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
using Sanatorium.Models;


namespace Sanatorium
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Titule.Visibility = Visibility.Hidden;
            if (User.user.Role != "Главный врач")
            {
                Statistic.Visibility = Visibility.Collapsed;
                ClientList.Visibility = Visibility.Collapsed;
                UserList.Visibility = Visibility.Collapsed;
                ScheduleList.Visibility = Visibility.Collapsed;
                PositionList.Visibility = Visibility.Collapsed;
                ServiceList.Visibility = Visibility.Collapsed;
                CabinetList.Visibility = Visibility.Collapsed;
                EmployeeList.Visibility = Visibility.Collapsed;
                AppointmenList.Visibility = Visibility.Collapsed;
            }
        }
        private void ClientList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientList());
            Manager.MainFrame = MainFrame;
        }

        private void PositionList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PositionList());
            Manager.MainFrame = MainFrame;
        }

        private void ServiceList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ServiceList());
            Manager.MainFrame = MainFrame;
        }

        private void CabineteList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CabinetList());
            Manager.MainFrame = MainFrame;
        }

        private void EmployeeList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EmployeeList());
            Manager.MainFrame = MainFrame;
        }

        private void AppointmentistList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AppointmentList());
            Manager.MainFrame = MainFrame;
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            //if (!(e.Content is Page page))
            //    return;
            //if (page is Pages.AuthPage)
            //{
            //    Stack.Visibility = Visibility.Hidden;
            //    Titule.Visibility = Visibility.Hidden;
            //}
            //else
            //{
            //    Stack.Visibility = Visibility.Visible;
            //    Titule.Visibility = Visibility.Visible;
            //}
        }

        private void ScheduleList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Schedule.ScheduleList());
            Manager.MainFrame = MainFrame;
        }

        private void UserList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.User.UserLsit());
            Manager.MainFrame = MainFrame;
        }

        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Statistics.ExpenseList());
            Manager.MainFrame = MainFrame;
        }

        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxLogin.Text))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }
            using (var db = new SanatoriumEntities())
            {
                Models.User.user = db.User.AsNoTracking().FirstOrDefault(u => u.Login == TextBoxLogin.Text && u.Password == PasswordBox.Password);
                if (Models.User.user == null)
                {
                    MessageBox.Show("Неверно введен логин или пароль");
                    return;
                }
                MessageBox.Show($"Вы вошли как: {Models.User.user.Role}");
                Auth.Visibility=Visibility.Collapsed;
                Titule.Visibility = Visibility.Visible;
                    ClientList.Visibility = Visibility.Visible;
                if (User.user.Role == "Главный врач")
                {
                    Statistic.Visibility = Visibility.Visible;
                    UserList.Visibility = Visibility.Visible;
                    ScheduleList.Visibility = Visibility.Visible;
                    PositionList.Visibility = Visibility.Visible;
                    ServiceList.Visibility = Visibility.Visible;
                    CabinetList.Visibility = Visibility.Visible;
                    EmployeeList.Visibility = Visibility.Visible;
                    AppointmenList.Visibility = Visibility.Visible;
                }
                if (User.user.Role == "Главный врач" || User.user.Role == "Администратор")
                    AppointmenList.Visibility = Visibility.Visible;

            }
        }
    }
}