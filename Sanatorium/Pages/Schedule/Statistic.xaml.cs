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
    /// Логика взаимодействия для Statistic.xaml
    /// </summary>
    public partial class Statistic : Page
    {
        public Statistic()
        {
            InitializeComponent();
            List<string> source = new List<string>();
            source.Add("Все специальности");
            for (int i = 0; i < SanatoriumEntities.GetContext().Position.ToList().Count; i++)
            {
                source.Add(SanatoriumEntities.GetContext().Position.ToList()[i].Title);
            }
            comboPosition.ItemsSource = SanatoriumEntities.GetContext().Position.ToList();
            comboPosition.SelectedIndex = 0;
            int count = SanatoriumEntities.GetContext().Appointment.Count();
            var schedule = SanatoriumEntities.GetContext().Appointment.ToList();
            int monday = schedule.Where(s => s.VisitDate.DayOfWeek == DayOfWeek.Monday).Count();
            int tuesday = schedule.Where(s => s.VisitDate.DayOfWeek == DayOfWeek.Tuesday).Count();
            int thursday = schedule.Where(s => s.VisitDate.DayOfWeek == DayOfWeek.Thursday).Count();
            int wednesday = schedule.Where(s => s.VisitDate.DayOfWeek == DayOfWeek.Wednesday).Count();
            int friday = schedule.Where(s => s.VisitDate.DayOfWeek == DayOfWeek.Friday).Count();
            int saturday = schedule.Where(s => s.VisitDate.DayOfWeek == DayOfWeek.Saturday).Count();
            int sunday = schedule.Where(s => s.VisitDate.DayOfWeek == DayOfWeek.Sunday).Count();
            if(count ==0)
                count = 1;
            if(MondayLabel.Content != "Monday")
            {
            MondayLabel.Content+=$"({monday})";
            TuesdayLabel.Content += $"({tuesday})";
            ThursdayLabel.Content += $"({thursday})";
            WednesdayLabel.Content += $"({wednesday})";
            FridayLabel.Content += $"({friday})";
            SaturdayLabel.Content += $"({saturday})";
            SundayLabel.Content += $"({sunday})";

            }
            Monday.Height = 400 / count * monday;
            Tuesday.Height = 400 /count * tuesday;
            Thursday.Height = 400 / count * thursday;
            Wednesday.Height = 400 / count * wednesday;
            Friday.Height = 400 / count * friday;
            Saturday.Height = 400 / count * saturday;
            Sunday.Height = 400 / count * sunday;
        }

        private void btnSchedule_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ScheduleList());
        }

        private void comboPosition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pos = comboPosition.SelectedValue as Position;
            if (comboPosition.SelectedIndex != 0)
            {
                int count = SanatoriumEntities.GetContext().Appointment.Count();
                var schedule = SanatoriumEntities.GetContext().Appointment.ToList();
                int monday = schedule.Where(s => s.VisitDate.DayOfWeek == DayOfWeek.Monday && s.Employee.Position.Title== pos.Title).Count();
                int tuesday = schedule.Where(s => s.VisitDate.DayOfWeek == DayOfWeek.Tuesday && s.Employee.Position.Title == pos.Title).Count();
                int thursday = schedule.Where(s => s.VisitDate.DayOfWeek == DayOfWeek.Thursday && s.Employee.Position.Title == pos.Title).Count();
                int wednesday = schedule.Where(s => s.VisitDate.DayOfWeek == DayOfWeek.Wednesday && s.Employee.Position.Title == pos.Title).Count();
                int friday = schedule.Where(s => s.VisitDate.DayOfWeek == DayOfWeek.Friday && s.Employee.Position.Title == pos.Title).Count();
                int saturday = schedule.Where(s => s.VisitDate.DayOfWeek == DayOfWeek.Saturday && s.Employee.Position.Title == pos.Title).Count();
                int sunday = schedule.Where(s => s.VisitDate.DayOfWeek == DayOfWeek.Sunday && s.Employee.Position.Title == pos.Title).Count();
                if (count == 0)
                    count = 1;
                Monday.Height = 400 / count * monday;
                Tuesday.Height = 400 / count * tuesday;
                Thursday.Height = 400 / count * thursday;
                Wednesday.Height = 400 / count * wednesday;
                Friday.Height = 400 / count * friday;
                Saturday.Height = 400 / count * saturday;
                Sunday.Height = 400 / count * sunday;
            }
        }
    }
}
