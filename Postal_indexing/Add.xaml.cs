using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        private Field _currentField = new Field();
        ApplicationContext db = new ApplicationContext();
        public Add(Field selectedField)
        {
            InitializeComponent();

            if (selectedField != null)
                _currentField = selectedField;

            DataContext = _currentField;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (_currentField.Country.Length == 0 || _currentField.District.Length == 0 || _currentField.Address.Length == 0 || _currentField.City.Length == 0 || _currentField.Status.Length == 0 || _currentField.Timetable.Length == 0 || _currentField.Region.Length == 0 || _currentField.Code.Length == 0)
            {
                MessageBox.Show("Всі поля повинні бути заповнені!");
                return;
            }

            if (_currentField.Id == 0)
            {
                db.Fields.Add(_currentField);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }                                          

            if (_currentField.Id > 0)
            {
                var field = db.Fields.SingleOrDefault(x => x.Id == _currentField.Id);
                field.Country = countryBox.Text;
                field.Region = regionBox.Text;
                field.District = districtBox.Text;
                field.City = cityBox.Text;
                field.Code = codeBox.Text;
                field.Address = addressBox.Text;
                field.Status = statusBox.Text;
                field.Timetable = timetableBox.Text;
                try
                {                   
                    db.SaveChanges();
                    MessageBox.Show("Дані збережено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сталася помилка!");
                    MessageBox.Show(ex.Message.ToString());
                }
                Edit ed = new Edit();
                ed.Show();
                Close();
            }
            
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            Close();
        }

        private void main_page_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
