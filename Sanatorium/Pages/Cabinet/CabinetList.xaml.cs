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
    /// Логика взаимодействия для CabinetList.xaml
    /// </summary>
    public partial class CabinetList : Page
    {
        public CabinetList()
        {
            InitializeComponent();
            DGridCabinet.ItemsSource = SanatoriumEntities.GetContext().Cabinet.ToList();

            if (User.user.Role != "Главный врач")
            { 
                Delete.Visibility = Visibility.Hidden;
                Add.Visibility = Visibility.Hidden;
                //Template.Visibility = Visibility.Hidden; узкиет столбцы
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditCabinet((sender as Button).DataContext as Cabinet));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditCabinet(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

            var cabinetForRemoving = DGridCabinet.SelectedItems.Cast<Cabinet>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {cabinetForRemoving.Count()} кабинеты?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SanatoriumEntities.GetContext().Cabinet.RemoveRange(cabinetForRemoving);
                    SanatoriumEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridCabinet.ItemsSource = SanatoriumEntities.GetContext().Cabinet.ToList();
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
                DGridCabinet.ItemsSource = SanatoriumEntities.GetContext().Cabinet.ToList();
            }
        }

    }
}
