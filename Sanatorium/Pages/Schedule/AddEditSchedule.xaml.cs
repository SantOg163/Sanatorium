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

namespace Sanatorium.Pages.Schedule
{
    /// <summary>
    /// Логика взаимодействия для AddEditSchedule.xaml
    /// </summary>
    public partial class AddEditSchedule : Page
    {
        public Models.Schedule _schedule { get; set; } = new Models.Schedule();
        public AddEditSchedule(Models.Schedule schedule)
        {
            InitializeComponent();
            ComboEmployee.ItemsSource = SanatoriumEntities.GetContext().Employee.ToList();
            if(schedule != null)
            {
                _schedule = schedule;
                ComboEmployee.SelectedIndex = schedule.EmployeeId - 1;
            }
            DataContext = _schedule;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            try
            {
                _schedule.Workday = Convert.ToDateTime(Workday.Text);
            }
            catch
            {
                errors.AppendLine("Неверно введена дата");
            }
            if (ComboEmployee.Text == "")
                errors.AppendLine("Выберите специалиста");
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            _schedule.EmployeeId = ComboEmployee.SelectedIndex + 1;
            if(_schedule.Id == 0)
                SanatoriumEntities.GetContext().Schedule.Add(_schedule);
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
