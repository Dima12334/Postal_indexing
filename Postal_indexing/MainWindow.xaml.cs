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

            SearchUpdate();
        }

        private void SearchUpdate()
        {
            ApplicationContext db = new ApplicationContext();
            List<Field> fields = db.Fields.ToList();

            fields = fields.Where(p => p.Country.ToLower().Contains(Country.Text.ToLower()) 
            && p.Region.ToLower().Contains(Region.Text.ToLower()) 
            && p.City.ToLower().Contains(City.Text.ToLower()) 
            && p.Code.ToLower().Contains(Code.Text.ToLower())).ToList();

            ListOfPostalDirectory.ItemsSource = fields.OrderBy(p => p.City).ToList();
        }

        private void ChangedTextSearch(object sender, TextChangedEventArgs e)
        {
            SearchUpdate();
        }

        private void ClickRegister(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            Close();
        }

        private void ClickHelp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                Help help_window = new Help();
                if (help_window.IsActive)
                {
                    this.Activate();
                }
                help_window.Show();
            }
        }
    }
}
