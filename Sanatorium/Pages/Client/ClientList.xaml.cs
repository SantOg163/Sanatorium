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
    /// Логика взаимодействия для ClientList.xaml
    /// </summary>
    public partial class ClientList : Page
    {
        public ClientList()
        {
            InitializeComponent();
            DGridClients.ItemsSource = SanatoriumEntities.GetContext().Client.ToList();

            if (User.user.Role != "Главный врач")
            {
                Delete.Visibility = Visibility.Hidden;
                Add.Visibility = Visibility.Hidden;
            }
            if (User.user.Role == "Администратор")
            {
                Delete.Visibility = Visibility.Visible;
                Add.Visibility = Visibility.Visible;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditClient((sender as Button).DataContext as Client));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var clientForRemoving = DGridClients.SelectedItems.Cast<Client>().ToList();

            if(MessageBox.Show($"Вы точно хотите удалить следующих {clientForRemoving.Count()} пациентов?","Внимание",
                MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SanatoriumEntities.GetContext().Client.RemoveRange(clientForRemoving);
                    SanatoriumEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridClients.ItemsSource = SanatoriumEntities.GetContext().Client.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditClient(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                SanatoriumEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p =>p.Reload());
                DGridClients.ItemsSource = SanatoriumEntities.GetContext().Client.ToList();
            }
        }
    }
}
