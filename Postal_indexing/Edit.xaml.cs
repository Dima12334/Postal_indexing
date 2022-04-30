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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit()
        {
            InitializeComponent();

            ApplicationContext db = new ApplicationContext();
            List<Field> fields = db.Fields.ToList();
            DGridFields.ItemsSource = fields;
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {           
            Add update = new Add((sender as Button).DataContext as Field);
            update.Show();
            Close();
        }

        private void main_page_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            Close();
        }

        //private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    if (Visibility == Visibility.Visible)
        //    {
        //        using (ApplicationContext db = new ApplicationContext())
        //        {
        //            db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
        //            DGridFields.ItemsSource = db.Fields.ToList();
        //        }
        //    }
        //}

        //IsVisibleChanged="Window_IsVisibleChanged" (xaml)
    }
}
