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

        private void main_page_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        public void add_Click(object sender, RoutedEventArgs e)
        {
            string name = login.Text.Trim();
            string password = pass.Password.Trim();

            if (name.Length > 0 && password.Length > 0)
            {
                Add update = new Add();
                update.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Заповніть пусті поля або введіть коректні данні");
            }
        }

        private void auth_Click(object sender, RoutedEventArgs e)
        {
            string name = login.Text.Trim();
            string password = pass.Password.Trim();

            if (name.Length > 0 && password.Length > 0)
            { 
                User authUser = null;
                using(ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(user => user.Name == name && user.Password == password).FirstOrDefault();
                }
                if (authUser != null)
                {
                    MessageBox.Show($"Вітаю, " + name + "!");
                }
                else
                {
                    MessageBox.Show("Такого користувача не існує!");
                }
            }
            else
            {
                MessageBox.Show("Заповніть пусті поля або введіть коректні данні");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            Close();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            Edit ed = new Edit();
            ed.Show();
            Close();
        }
    }
}
