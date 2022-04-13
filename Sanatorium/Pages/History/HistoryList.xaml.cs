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
    /// Логика взаимодействия для HistoryList.xaml
    /// </summary>
    public partial class HistoryList : Page
    {
        public HistoryList()
        {
            InitializeComponent();
            DGridHistory.ItemsSource = SanatoriumEntities.GetContext().History.ToList();

            if (User.user.Role != "Главный врач")
            {
                Delete.Visibility = Visibility.Hidden;
                Add.Visibility = Visibility.Hidden;

            }
            if (User.user.Role == "Врач" )
            {
                Delete.Visibility = Visibility.Visible;
                Add.Visibility = Visibility.Visible;
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditHistory((sender as Button).DataContext as History));
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditHistory(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                SanatoriumEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridHistory.ItemsSource = SanatoriumEntities.GetContext().History.ToList();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var historyForRemoving = DGridHistory.SelectedItems.Cast<History>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {historyForRemoving.Count()} истории?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SanatoriumEntities.GetContext().History.RemoveRange(historyForRemoving);
                    SanatoriumEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridHistory.ItemsSource = SanatoriumEntities.GetContext().History.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
