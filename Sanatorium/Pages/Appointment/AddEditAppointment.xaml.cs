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
            ComboClient.ItemsSource = SanatoriumEntities.GetContext().Client.ToList();
            ComboEmployee.ItemsSource = SanatoriumEntities.GetContext().Employee.ToList();
            VisitDate.ItemsSource = SanatoriumEntities.GetContext().Schedule.Where(s => s.Employee.Name == ComboEmployee.Text).ToList();
            if (_selectedAppointment != null)
            {
                _currentAppointment = _selectedAppointment;
                ComboClient.SelectedIndex = _selectedAppointment.ClientId - 1;
                ComboEmployee.SelectedIndex = _selectedAppointment.EmployeeId - 1;
                ComboService.SelectedIndex = _selectedAppointment.ServiceId - 1;
                ComboCabinet.SelectedIndex = _selectedAppointment.CabinetId - 1;
                VisitDate.Text = $"{_selectedAppointment.VisitDate}";
            }  
            DataContext = _currentAppointment;
            _currentAppointment.DateRegistration = DateTime.Now;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            try
            {
                var time = VisitTime.Text.Split(':');
                _currentAppointment.VisitDate = Convert.ToDateTime(VisitDate.Text).AddHours(Convert.ToInt32(time[0])).AddMinutes(Convert.ToInt32(time[1]));
            }
            catch
            {
                errors.AppendLine("Неверно введена дата или время визита");
            }
            if (ComboCabinet.Text == "")
                errors.AppendLine("Выберите кабинет");
            if (ComboClient.Text == "")
                errors.AppendLine("Выберите клиента");
            if (ComboEmployee.Text == "")
                errors.AppendLine("Выберите врача");
            if (ComboService.Text == "")
                errors.AppendLine("Выберите процедуру");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            _currentAppointment.ServiceId = ComboService.SelectedIndex + 1;
            _currentAppointment.CabinetId = ComboCabinet.SelectedIndex + 1;
            _currentAppointment.ClientId = ComboClient.SelectedIndex + 1;
            _currentAppointment.EmployeeId = ComboEmployee.SelectedIndex + 1;
            if(_currentAppointment.Id == 0)
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

        private void ComboEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var strin = ComboEmployee.SelectedValue as Employee;
            if (ComboEmployee.SelectedValue != null)
            {
                VisitDate.ItemsSource = SanatoriumEntities.GetContext().Schedule.Where(s=>s.Employee.Name==strin.Name).ToList();
                ComboService.ItemsSource = SanatoriumEntities.GetContext().Service.Where(p => p.PositionId == strin.PositionId).ToList();
                ComboCabinet.ItemsSource = SanatoriumEntities.GetContext().Cabinet.Where(p => p.PositionId == strin.PositionId).ToList();
            }
            
        }
    }
}
