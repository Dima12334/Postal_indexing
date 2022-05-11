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
        ApplicationContext db = new ApplicationContext();

        public Edit()
        {
            InitializeComponent();

            List<Field> fields = db.Fields.ToList();
            DGridFields.ItemsSource = fields;
        }

        private void ClickEdit(object sender, RoutedEventArgs e)
        {           
            Add update = new Add((sender as Button).DataContext as Field);
            update.Show();
            Close();
        }

        private void ClickMainPage(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void ClickBack(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            Close();
        }

        private void ClickAdd(object sender, RoutedEventArgs e)
        {
            Add update = new Add(null);
            update.Show();
            Close();
        }

        private void ClickDelete(object sender, RoutedEventArgs e)
        {
            var fieldsForRemoving = DGridFields.SelectedItems.Cast<Field>().ToList();

            if (fieldsForRemoving.Count() > 0)
            {
                if (MessageBox.Show("Ви впевнені, що бажаєте видалати ці дані?", "Увага!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        db.Fields.RemoveRange(fieldsForRemoving);
                        db.SaveChanges();
                        MessageBox.Show("Дані видалено!");

                        DGridFields.ItemsSource = db.Fields.ToList();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Не вдалося видалити дані!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Оберіть дані для видалення");
            }
        }
    }
}
