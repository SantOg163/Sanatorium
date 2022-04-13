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
    /// Логика взаимодействия для AddEditService.xaml
    /// </summary>
    public partial class AddEditService : Page
    {
        private Service _currentService = new Service();
        public AddEditService(Service _selectedService)
        {
            InitializeComponent();
            if( _selectedService != null )
                _currentService = _selectedService;
            DataContext = _currentService;
            ComboPositions.ItemsSource = SanatoriumEntities.GetContext().Position.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentService.Appointment))
                errors.AppendLine("Введите назначение");
            if (_currentService.Appointment.Length > 50)
                errors.AppendLine("Слишком длинное назначение");
            if(errors.Length > 0)
                MessageBox.Show(errors.ToString());
            SanatoriumEntities.GetContext().Service.Add(_currentService);
            try
            {
                SanatoriumEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
