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

        private void HistoryList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HistoryList());
            Manager.MainFrame = MainFrame;
        }

        private void AppointmentistList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AppointmentList());
            Manager.MainFrame = MainFrame;
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if(!(e.Content is Page page))
                return;
            if(page is Pages.AuthPage)
            {
                Stack.Visibility = Visibility.Hidden;
                Titule.Visibility = Visibility.Hidden;
            }
            else
            {
                Stack.Visibility = Visibility.Visible;
                Titule.Visibility = Visibility.Visible;
            }
        }        
    }
}