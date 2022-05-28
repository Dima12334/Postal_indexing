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

        private void ClickMainPage(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void ClickRegister(object sender, RoutedEventArgs e)
        {
            string name = LoginBox.Text.Trim();
            string password = PassBox.Password.Trim();

            User authUser = null;
            authUser = db.Users.Where(user => user.Name == name 
            && user.Password == password).FirstOrDefault();
            
            if (name.Length > 0 && name.Length <= 30 && password.Length > 0 
                && password.Length <= 30 && authUser == null)
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
            else if (authUser != null)
            {
                MessageBox.Show("Такий адмін уже існує!");
            }
            else
            {
                MessageBox.Show("Кільскість символів у полі повинна будти від 0 до 30!");
            }
        }

        private void ClickAuth(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            Close();
        }
    }
}
