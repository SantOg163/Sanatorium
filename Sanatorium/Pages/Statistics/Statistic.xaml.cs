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

namespace Sanatorium.Pages
{
    /// <summary>
    /// Логика взаимодействия для Statistic.xaml
    /// </summary>
    public partial class Statistic : Page
    {
        public Statistic()
        {
            InitializeComponent();
            var context = SanatoriumEntities.GetContext().Appointment.ToList();
            var stat = SanatoriumEntities.GetContext().Statistic.ToList();
            Incpude.Content = context.Where(a => a.VisitDate.Month == DateTime.Now.Month && a.VisitDate.Year == DateTime.Now.Year).Select(a=>a.Service.Price).Sum();
            expense.Content = stat.Where(a => a.Month.Month == DateTime.Now.Month && a.Month.Year == DateTime.Now.Year).Select(a=>a.expenses).Sum();
            Total.Content = (int)Incpude.Content - (int)expense.Content;
            if (JanuaryLabel.Content.ToString() == "Январь")
            {
                January.Height = 0.002 *(context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 1).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year&& a.Month.Month == 1).Select(a => a.expenses).Sum());
                JanuaryLabel.Content = JanuaryLabel.Content + $"({context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 1).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 1).Select(a => a.expenses).Sum()})";
                February.Height = 0.002 *(context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 2).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 2).Select(a => a.expenses).Sum()) ;
                FebruaryLabel.Content = FebruaryLabel.Content + $"({context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 2).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 2).Select(a => a.expenses).Sum()})";
                March.Height = 0.002 *(context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 3).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 3).Select(a => a.expenses).Sum() );
                MarchLabel.Content = MarchLabel.Content + $"({context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 3).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 3).Select(a => a.expenses).Sum()})";
                April.Height = 0.002 *(context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 4).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 4).Select(a => a.expenses).Sum()) ;
                AprilLabel.Content = AprilLabel.Content + $"({context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 4).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 4).Select(a => a.expenses).Sum()})";
                try
                {
                May.Height = 0.002*(context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 5).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 5).Select(a => a.expenses).Sum());

                }
                catch { May.Height = 0; }
                MayLabel.Content = MayLabel.Content + $"({context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 5).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 5).Select(a => a.expenses).Sum()})";
                June.Height = 0.002 *(context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 6).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 6).Select(a => a.expenses).Sum()) ;
                JuneLabel.Content = JuneLabel.Content + $"({context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 6).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 6).Select(a => a.expenses).Sum()})";
                July.Height = 0.002 *(context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 7).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 7).Select(a => a.expenses).Sum()) ;
                JulyLabel.Content = JulyLabel.Content + $"({context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 7).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 7).Select(a => a.expenses).Sum()})";
                August.Height = 0.002 *(context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 8).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 8).Select(a => a.expenses).Sum()) ;
                AugustLabel.Content = AugustLabel.Content + $"({context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 8).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Month == 8).Select(a => a.expenses).Sum()})";
                September.Height = 0.002 *(context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 9).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 9).Select(a => a.expenses).Sum()) ;
                SeptemberLabel.Content = SeptemberLabel.Content + $"({context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 9).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 9).Select(a => a.expenses).Sum()})";
                October.Height = 0.002 *(context.Where(a => a.VisitDate.Month == 10).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 10).Select(a => a.expenses).Sum()) ;
                OctoberLabel.Content = OctoberLabel.Content + $"({context.Where(a => a.VisitDate.Month == 10).Select(a => a.Service.Price).Sum() - stat.Where(a=> a.Month.Year == DateTime.Now.Year && a.Month.Month == 10).Select(a => a.expenses).Sum()})";
                November.Height = 0.002 *(context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 11).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 11).Select(a => a.expenses).Sum()) ;
                NovemberLabel.Content = NovemberLabel.Content + $"({context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 11).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 11).Select(a => a.expenses).Sum()})";
                December.Height = 0.002 *(context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 1).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 12).Select(a => a.expenses).Sum()) ;
                DecemberLabel.Content = DecemberLabel.Content + $"({context.Where(a => a.VisitDate.Year == DateTime.Now.Year && a.VisitDate.Month == 12).Select(a => a.Service.Price).Sum() - stat.Where(a => a.Month.Year == DateTime.Now.Year && a.Month.Month == 12).Select(a => a.expenses).Sum()})";
            }
            }
    }
}
