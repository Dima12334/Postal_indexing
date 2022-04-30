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
using System.Data.Entity.Validation;

namespace Postal_indexing
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        ApplicationContext db = new ApplicationContext();
        public Register()
        {
            InitializeComponent();            
        }

        private void main_page_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            string name = login.Text.Trim();
            string password = pass.Password.Trim();

            User authUser = null;
            authUser = db.Users.Where(user => user.Name == name && user.Password == password).FirstOrDefault();
            
            if (name.Length>0 && password.Length > 0 && authUser == null)
            {
                User user = new User(name, password);
                db.Users.Add(user);
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Реєстрацація пройшла успішно!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Заповніть пусті поля або поверніться на початкову сторінку");
                }                          
            }
            if(authUser != null)
            {
                MessageBox.Show("Такий адмін уже існує!");
            }
        }

        private void auth_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            Close();
        }
    }
}
