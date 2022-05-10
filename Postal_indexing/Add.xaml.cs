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
            {
                _currentField = selectedField;
            }

            DataContext = _currentField;
        }

        private void ClickSave(object sender, RoutedEventArgs e)
        {
            if (_currentField.Country.Length == 0 || _currentField.District.Length == 0 
                || _currentField.Address.Length == 0 || _currentField.City.Length == 0 
                || _currentField.Status.Length == 0 || _currentField.Timetable.Length == 0 
                || _currentField.Region.Length == 0 || _currentField.Code.Length == 0)
            {
                MessageBox.Show("Всі поля повинні бути заповнені!");
                return;
            }

            if (_currentField.Country.Length <= 30 && _currentField.District.Length <= 30 && _currentField.Address.Length <= 30 && _currentField.City.Length <= 30 && _currentField.Status.Length <= 30 && _currentField.Timetable.Length <= 30 && _currentField.Region.Length <= 30 && _currentField.Code.Length <= 30)
            {
                if (_currentField.Id == 0)
                {
                    db.Fields.Add(_currentField);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message.ToString());
                    }
                }

                if (_currentField.Id > 0)
                {
                    var field = db.Fields.SingleOrDefault(x => x.Id == _currentField.Id);
                    field.Country = CountryBox.Text;
                    field.Region = RegionBox.Text;
                    field.District = DistrictBox.Text;
                    field.City = CityBox.Text;
                    field.Code = CodeBox.Text;
                    field.Address = AddressBox.Text;
                    field.Status = StatusBox.Text;
                    field.Timetable = TimetableBox.Text;
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Дані збережено!");
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Сталася помилка!");
                        MessageBox.Show(exc.Message.ToString());
                    }

                    Edit edit = new Edit();
                    edit.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Кільскість символів у полі повинна будти від 0 до 30!");
            }
        }

        private void ClickBack(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            Close();
        }

        private void ClickMainPage(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
