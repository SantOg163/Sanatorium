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
    /// Логика взаимодействия для AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : Page
    {
        private Employee _currentEmployee = new Employee();
        public AddEditEmployee(Employee _selectedEmployee)
        {
            InitializeComponent();

            if (_selectedEmployee != null)
                _currentEmployee = _selectedEmployee;
            DataContext = _currentEmployee;
            ComboPositions.ItemsSource = SanatoriumEntities.GetContext().Position.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentEmployee.Name))
                errors.AppendLine("Введите имя клиента");
            if (_currentEmployee.Name.Length > 50)
                errors.AppendLine("Слишком длинное имя");
            if (_currentEmployee.PhoneNumber.Length != 18)
                errors.AppendLine("Неверно введен номер телефона");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Adress))
                errors.AppendLine("Введите адрес");
            if (_currentEmployee.Adress.Length > 100)
                errors.AppendLine("Слишком длинный адрес");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentEmployee.Id == 0)
                SanatoriumEntities.GetContext().Employee.Add(_currentEmployee);
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
