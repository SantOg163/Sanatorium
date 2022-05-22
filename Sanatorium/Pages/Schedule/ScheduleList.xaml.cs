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

namespace Sanatorium.Pages.Schedule
{
    /// <summary>
    /// Логика взаимодействия для ScheduleList.xaml
    /// </summary>
    public partial class ScheduleList : Page
    {
        public ScheduleList()
        {
            InitializeComponent();
            DGridSchedule.ItemsSource = SanatoriumEntities.GetContext().Schedule.ToList();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                SanatoriumEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridSchedule.ItemsSource = SanatoriumEntities.GetContext().Schedule.ToList();
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSchedule(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var scheduleForRemoving = DGridSchedule.SelectedItems.Cast<Models.Schedule>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {scheduleForRemoving.Count()} расписания?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SanatoriumEntities.GetContext().Schedule.RemoveRange(scheduleForRemoving);
                    SanatoriumEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridSchedule.ItemsSource = SanatoriumEntities.GetContext().Schedule.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate((sender as Button).DataContext as Models.Schedule);        }

    }
}
