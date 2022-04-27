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

        }
    }
}
