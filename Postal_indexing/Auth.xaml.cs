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
using System.Windows.Shapes;

namespace Postal_indexing
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();            
        }

        private void ClickMainPage(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        public void ClickAdd(object sender, RoutedEventArgs e)
        {
            Add update = new Add(null);
            update.Show();
            Close();
        }

        private void ClickAuth(object sender, RoutedEventArgs e)
        {
            string name = LoginBox.Text.Trim();
            string password = PassBox.Password.Trim();

            if (name.Length > 0 && name.Length <= 30 
                && password.Length > 0 && password.Length <= 30)
            { 
                User authUser = null;
                using(ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(user => user.Name == name && user.Password == password).FirstOrDefault();
                }
                if (authUser != null)
                {
                    MessageBox.Show($"Вітаю, " + name + "!");
                    EditButton.Visibility = Visibility.Visible;
                    AddButton.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Такого користувача не існує!");
                }
            }
            else
            {
                MessageBox.Show("Кільскість символів у полі повинна будти від 0 до 30!");
            }
        }

        private void ClickBack(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            Close();
        }

        private void ClickEdit(object sender, RoutedEventArgs e)
        {
            Edit edit = new Edit();
            edit.Show();
            Close();
        }
    }
}
