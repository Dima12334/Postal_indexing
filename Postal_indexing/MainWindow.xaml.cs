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

namespace Postal_indexing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UpdateSearch();
        }

        private void UpdateSearch()
        {
            ApplicationContext db = new ApplicationContext();
            List<Field> fields = db.Fields.ToList();

            fields = fields.Where(p => p.Country.ToLower().Contains(country.Text.ToLower()) && p.Region.ToLower().Contains(region.Text.ToLower()) && p.City.ToLower().Contains(city.Text.ToLower()) && p.Code.ToLower().Contains(code.Text.ToLower())).ToList();
            ListOfPostalDirectory.ItemsSource = fields.OrderBy(p => p.City).ToList();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSearch();
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            Close();
        }
    }
}
