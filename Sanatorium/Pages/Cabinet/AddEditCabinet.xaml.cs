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
    /// Логика взаимодействия для AddEditCabinet.xaml
    /// </summary>
    public partial class AddEditCabinet : Page
    {
        private Cabinet _currentCabinet = new Cabinet();
        public AddEditCabinet(Cabinet _selectedCabinets)
        {
            InitializeComponent();
            if( _selectedCabinets != null )
                _currentCabinet = _selectedCabinets;    
            DataContext = _currentCabinet;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentCabinet.Appointment))
                errors.AppendLine("Введите назначение");
            if (_currentCabinet.Appointment.Length > 50)
                errors.AppendLine("Слишком длинное назначение");
            if (errors.Length > 0)
                MessageBox.Show(errors.ToString());
            if (_currentCabinet.Id == 0)
                SanatoriumEntities.GetContext().Cabinet.Add(_currentCabinet);
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
