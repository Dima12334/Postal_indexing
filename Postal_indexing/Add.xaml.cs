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

        public Add()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            string country_txt = countryBox.Text.Trim();
            string region_txt = regionBox.Text.Trim();
            string district_txt = districtBox.Text.Trim();
            string city_txt = cityBox.Text.Trim();
            string code_txt = codeBox.Text.Trim();
            string address_txt = addressBox.Text.Trim();
            string status_txt = statusBox.Text.Trim();
            string timetable_txt = timetableBox.Text.Trim();

            if (country_txt.Length > 0 && region_txt.Length > 0 && district_txt.Length > 0 && city_txt.Length > 0 && code_txt.Length > 0 && address_txt.Length > 0 && status_txt.Length > 0 && timetable_txt.Length > 0)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Field field = new Field(country_txt, region_txt, district_txt, city_txt, code_txt, address_txt, status_txt, timetable_txt);
                    db.Fields.Add(field);
                    db.SaveChanges();
                }

                MessageBox.Show("Дані збережено!");
            }
            else
            {
                MessageBox.Show("Всі поля повинні бути заповнені!");
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
