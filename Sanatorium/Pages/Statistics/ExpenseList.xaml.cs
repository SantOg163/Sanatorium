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
    /// Логика взаимодействия для ExpenseList.xaml
    /// </summary>
    public partial class ExpenseList : Page
    {
        public ExpenseList()
        {
            InitializeComponent();
            DGridExpense.ItemsSource = SanatoriumEntities.GetContext().Statistic.Where(s=>s.Month.Month==DateTime.Now.Month).ToList();

        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditExpenses((sender as Button).DataContext as Models.Statistic));
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditExpenses(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var expenseForRemoving = DGridExpense.SelectedItems.Cast<Models.Statistic>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {expenseForRemoving.Count()} услуги?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SanatoriumEntities.GetContext().Statistic.RemoveRange(expenseForRemoving);
                    SanatoriumEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridExpense.ItemsSource = SanatoriumEntities.GetContext().Service.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                SanatoriumEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridExpense.ItemsSource = SanatoriumEntities.GetContext().Statistic.ToList();
            }
        }
        private void btnStatistic_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.Statistic());
        }
    }
}
