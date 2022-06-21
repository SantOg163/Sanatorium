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
    /// Логика взаимодействия для AddEditHistory.xaml
    /// </summary>
    public partial class AddEditHistory : Page
    {
        private History _currentHistory = new History();

        public AddEditHistory(History _selectedHistory, Client client)
        {
            InitializeComponent();
            ComboEmployee.ItemsSource = SanatoriumEntities.GetContext().Employee.ToList();
            if( _selectedHistory != null)
            {
                _currentHistory = _selectedHistory;
                ComboEmployee.SelectedIndex=_selectedHistory.EmployeeId - 1;

            }
            DataContext = _currentHistory;
            Name.Content=client.Name;
            _currentHistory.ClientId = client.Id;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (ComboEmployee.Text == "")
                errors.AppendLine("Выберите врача");
            if (string.IsNullOrWhiteSpace(_currentHistory.Symptoms))
                errors.AppendLine("Введите симптомы");
            if (_currentHistory.Symptoms.Length > 50)
                errors.AppendLine("Слишком длинный список симптомов");
            if (string.IsNullOrWhiteSpace(_currentHistory.Diagnosis))
                errors.AppendLine("Введите диагноз");
            if (_currentHistory.Diagnosis.Length > 50)
                errors.AppendLine("Слишком длинный диагноз");
            if (string.IsNullOrWhiteSpace(_currentHistory.Medicine))
                errors.AppendLine("Введите лекарство");
            if (_currentHistory.Medicine.Length > 50)
                errors.AppendLine("Слишком длинный список лекарств");
            if(errors.Length > 0)
                MessageBox.Show(errors.ToString());
            _currentHistory.EmployeeId = SanatoriumEntities.GetContext().Employee.Find(ComboEmployee.SelectedIndex + 1).Id;
            _currentHistory.DischargeDate = Convert.ToDateTime(DD.Text);
            _currentHistory.DischargeDate = Convert.ToDateTime(DD.Text);
            SanatoriumEntities.GetContext().History.Add(_currentHistory);
            try
            {
                SanatoriumEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
