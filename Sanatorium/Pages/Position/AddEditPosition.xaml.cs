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
    /// Логика взаимодействия для AddEditPosition.xaml
    /// </summary>
    public partial class AddEditPosition : Page
    {
        private Position _currentPosition = new Position();

        public AddEditPosition(Position _selectedPosition)
        {
            InitializeComponent();
            if( _selectedPosition != null )
                _currentPosition = _selectedPosition;
            DataContext = _currentPosition;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentPosition.Title))
                errors.AppendLine("Введите должность");
            if (_currentPosition.Title.Length > 50)
                errors.AppendLine("Название должности слишком длинное");
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if(_currentPosition.Id == 0)
                SanatoriumEntities.GetContext().Position.Add(_currentPosition);
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
