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
    /// Логика взаимодействия для AddEditCabinet.xaml
    /// </summary>
    public partial class AddEditCabinet : Page
    {
        private Cabinet _currentCabinet = new Cabinet();
        public AddEditCabinet(Cabinet _selectedCabinets)
        {
            InitializeComponent();
            ComboPosition.ItemsSource = SanatoriumEntities.GetContext().Position.ToList();
            if( _selectedCabinets != null )
            {
                _currentCabinet = _selectedCabinets;
                ComboPosition.SelectedIndex = _selectedCabinets.PositionId - 1;
            }  

            DataContext = _currentCabinet;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (ComboPosition.Text=="")
                errors.AppendLine("Выберите специализацию");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            _currentCabinet.PositionId = ComboPosition.SelectedIndex + 1;
            if (_currentCabinet.Id == 0)
                SanatoriumEntities.GetContext().Cabinet.Add(_currentCabinet);
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
