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

namespace Sanatorium.Pages.User
{
    /// <summary>
    /// Логика взаимодействия для AddEditUser.xaml
    /// </summary>
    public partial class AddEditUser : Page
    {
        public Models.User _currentUser { get; set; } = new Models.User();
        public AddEditUser(Models.User selectedUser)
        {
            InitializeComponent();
            List<string> roles = new List<string> { "Врач", "Администратор", "Главный врач" };
            comboRole.ItemsSource = roles;
            comboEmployee.ItemsSource = SanatoriumEntities.GetContext().Employee.ToList();
            if (selectedUser != null)
            {
                _currentUser = selectedUser;
                comboEmployee.SelectedIndex = selectedUser.EmployeeId - 1;
                comboRole.SelectedIndex = roles.FindIndex(s=>s==selectedUser.Role);
            }
            DataContext = _currentUser;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (comboEmployee.Text == "")
                errors.AppendLine("Выберите сотрудника");
            if (comboRole.Text == "")
                errors.AppendLine("Выберите Роль");
            if (_currentUser.Login == "")
                errors.AppendLine("Введите логин");
            if (_currentUser.Password == "")
                errors.AppendLine("Введите пароль");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if(_currentUser.EmployeeId==0)
            _currentUser.EmployeeId = comboEmployee.SelectedIndex + 1;
            if (_currentUser.Id == 0)
                SanatoriumEntities.GetContext().User.Add(_currentUser);
            try
            {
                SanatoriumEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
