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
    /// Логика взаимодействия для EmployeeList.xaml
    /// </summary>
    public partial class EmployeeList : Page
    {
        public EmployeeList()
        {
            InitializeComponent();
            DGridEmployee.ItemsSource = SanatoriumEntities.GetContext().Employee.ToList();
            if (User.user.Role != "Главный врач")
            {
                Delete.Visibility = Visibility.Hidden;
                Add.Visibility = Visibility.Hidden;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditEmployee((sender as Button).DataContext as Employee));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditEmployee(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var employeeForRemoving = DGridEmployee.SelectedItems.Cast<Employee>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующих {employeeForRemoving.Count()} сотрудников?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SanatoriumEntities.GetContext().Employee.RemoveRange(employeeForRemoving);
                    SanatoriumEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridEmployee.ItemsSource = SanatoriumEntities.GetContext().Employee.ToList();
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
                DGridEmployee.ItemsSource = SanatoriumEntities.GetContext().Employee.ToList();
            }
        }
    }
}
