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
    /// Логика взаимодействия для PositionList.xaml
    /// </summary>
    public partial class PositionList : Page
    {
        public PositionList()
        {
            InitializeComponent();
            DGridPositions.ItemsSource = SanatoriumEntities.GetContext().Position.ToList();

            if (User.user.Role != "Главный врач")
            {
                Delete.Visibility = Visibility.Hidden;
                Add.Visibility = Visibility.Hidden;
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPosition((sender as Button).DataContext as Position));
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPosition(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var positionForRemoving = DGridPositions.SelectedItems.Cast<Position>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {positionForRemoving.Count()} должности?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SanatoriumEntities.GetContext().Position.RemoveRange(positionForRemoving);
                    SanatoriumEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridPositions.ItemsSource = SanatoriumEntities.GetContext().Position.ToList();

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
                DGridPositions.ItemsSource = SanatoriumEntities.GetContext().Position.ToList();
            }
        }
    }
}
