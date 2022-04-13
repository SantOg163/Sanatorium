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
using Sanatorium.Properties;
using Sanatorium.Models;

namespace Sanatorium
{
    /// <summary>
    /// Логика взаимодействия для AppointmentList.xaml
    /// </summary>
    public partial class AppointmentList : Page
    {
        public AppointmentList()
        {
            InitializeComponent();
            DGridAppointment.ItemsSource = SanatoriumEntities.GetContext().Appointment.ToList();

            if (User.user.Role != "Главный врач")
            {
                Delete.Visibility = Visibility.Hidden;
                Add.Visibility = Visibility.Hidden;
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditAppointment((sender as Button).DataContext as Appointment));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditAppointment(null));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var appointmentForRemoving = DGridAppointment.SelectedItems.Cast<Appointment>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {appointmentForRemoving.Count()} записи?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SanatoriumEntities.GetContext().Appointment.RemoveRange(appointmentForRemoving);
                    SanatoriumEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridAppointment.ItemsSource = SanatoriumEntities.GetContext().Appointment.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                SanatoriumEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridAppointment.ItemsSource = SanatoriumEntities.GetContext().Appointment.ToList();
            }
        }
    }
}
