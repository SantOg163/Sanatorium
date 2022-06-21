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

namespace Sanatorium.Pages.Statistics
{
    /// <summary>
    /// Логика взаимодействия для AddEditExpenses.xaml
    /// </summary>
    public partial class AddEditExpenses : Page
    {
        public Models.Statistic _currentExpense { get; set; } = new Models.Statistic();
        public AddEditExpenses(Models.Statistic selectedExpense)
        {
            InitializeComponent();
            if(selectedExpense != null)
                _currentExpense = selectedExpense;
            DataContext = _currentExpense;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentExpense.Title == "")
                errors.AppendLine("Введите название траты");
            if (_currentExpense.expenses == 0)
                errors.AppendLine("Введите сумму траты");
            if (DatePick.Text == "")
                errors.AppendLine("Введите дату траты");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            _currentExpense.Month = Convert.ToDateTime(DatePick.Text);
            if (_currentExpense.Id == 0)
                SanatoriumEntities.GetContext().Statistic.Add(_currentExpense);
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
