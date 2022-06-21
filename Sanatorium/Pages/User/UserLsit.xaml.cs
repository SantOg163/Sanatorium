using Sanatorium.Models;
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

namespace Sanatorium.Pages.User
{
    /// <summary>
    /// Логика взаимодействия для UserLsit.xaml
    /// </summary>
    public partial class UserLsit : Page
    {
        public UserLsit()
        {
            InitializeComponent();
            DGridUsers.ItemsSource=SanatoriumEntities.GetContext().User.ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = DGridUsers.SelectedItems.Cast<Models.User>().ToList();
            if(usersForRemoving.Contains(Models.User.user) || usersForRemoving.Where(u => u.Role == "Главный врач").Count() != 0)
            {
                MessageBox.Show("Вы не можете удалить себя");
                return;
            }
            if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} кабинеты?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {
                    SanatoriumEntities.GetContext().User.RemoveRange(usersForRemoving);
                    SanatoriumEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridUsers.DataContext = SanatoriumEntities.GetContext().User.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditUser(null)); 
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditUser((sender as Button).DataContext as Models.User));
        }
        private void EmployeeName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EmployeeName.Text == "")
            {
                DGridUsers.ItemsSource = SanatoriumEntities.GetContext().User.ToList();
                return;
            }
            DGridUsers.ItemsSource = SanatoriumEntities.GetContext().User.Where(a => a.Employee.Name.ToLower().Contains(EmployeeName.Text.ToLower())).ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                SanatoriumEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridUsers.ItemsSource = SanatoriumEntities.GetContext().User.ToList();
            }
        }
    }
}
