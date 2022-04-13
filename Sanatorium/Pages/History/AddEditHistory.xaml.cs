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

        public AddEditHistory(History _selectedHistory)
        {
            InitializeComponent();
            if( _selectedHistory != null )
                _currentHistory = _selectedHistory;
            DataContext = _currentHistory;

            ComboClient.ItemsSource = SanatoriumEntities.GetContext().Client.ToList();
            ComboEmployee.ItemsSource = SanatoriumEntities.GetContext().Employee.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
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
