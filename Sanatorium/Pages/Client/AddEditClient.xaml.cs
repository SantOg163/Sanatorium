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
    /// Логика взаимодействия для AddEditClient.xaml
    /// </summary>
    public partial class AddEditClient : Page
    {
        private Client  _currentClient = new Client();
        public AddEditClient(Client selectedClient)
        {
            InitializeComponent();
            if(selectedClient != null)
                _currentClient = selectedClient;
            DataContext = _currentClient;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentClient.Name))
                errors.AppendLine("Введите имя клиента");
            if (_currentClient.Name.Length > 50)
                errors.AppendLine("Слишком длинное имя");
            if (_currentClient.PhoneNumber.Length != 18)
                errors.AppendLine("Неверно введен номер телефона");
            if (_currentClient.BloodType.Length > 3)
                errors.AppendLine("Неверно введена группа крови");
            if (_currentClient.PolicyNumber.Length != 12)
                errors.AppendLine("Неверно введен полис");
            if (string.IsNullOrWhiteSpace(_currentClient.Adress))
                errors.AppendLine("Введите адрес");
            if (_currentClient.Adress.Length > 100)
                errors.AppendLine("Слишком длинный адрес");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if(_currentClient.Id == 0)
                SanatoriumEntities.GetContext().Client.Add(_currentClient);
            try
            {
                SanatoriumEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
