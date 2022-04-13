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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(TextBoxLogin.Text))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }
            using(var db = new SanatoriumEntities())
            {
                User.user = db.User.AsNoTracking().FirstOrDefault(u=>u.Login == TextBoxLogin.Text && u.Password == PasswordBox.Password);
                if(User.user == null)
                {
                    MessageBox.Show("Неверно введен логин или пароль");
                    return;
                }
                MessageBox.Show($"Вы вошли как: {User.user.Role}");
                switch(User.user.Role)
                {
                    case "Главный врач":
                        NavigationService?.Navigate(new VisiblePage());
                        break;
                    case "Администратор":
                        NavigationService?.Navigate(new VisiblePage());
                        break;
                    case "Врач":
                        NavigationService?.Navigate(new VisiblePage());
                        break;
                }
            }
        }
    }
}
