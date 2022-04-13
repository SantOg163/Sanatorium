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
    /// Логика взаимодействия для AddEditAppointment.xaml
    /// </summary>
    public partial class AddEditAppointment : Page
    {
        private Appointment _currentAppointment = new Appointment();
        public AddEditAppointment(Appointment _selectedAppointment)
        {
            InitializeComponent();
            if( _selectedAppointment != null )
                _currentAppointment = _selectedAppointment;
            DataContext = _currentAppointment;
            _currentAppointment.DateRegistration = DateTime.Now;

            ComboClient.ItemsSource = SanatoriumEntities.GetContext().Client.ToList();
            ComboEmployee.ItemsSource = SanatoriumEntities.GetContext().Employee.ToList();
            ComboService.ItemsSource = SanatoriumEntities.GetContext().Service.ToList();
            ComboCabinet.ItemsSource = SanatoriumEntities.GetContext().Cabinet.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentAppointment.VisitDate.GetType().Name != "DateTime")
                errors.AppendLine("Неверно введена дата визита");
            if(errors.Length > 0)
                MessageBox.Show(errors.ToString());
            SanatoriumEntities.GetContext().Appointment.Add(_currentAppointment);
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
