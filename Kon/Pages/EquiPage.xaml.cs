using Kon.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using static Kon.ClassHalper.EFClass;


namespace Kon.Pages
{
    /// <summary>
    /// Логика взаимодействия для EquiPage.xaml
    /// </summary>
    public partial class EquiPage : Page
    {
        public EquiPage()
        {
            InitializeComponent();
            dgEqui.ItemsSource = context.Equipment.ToList();
            if (post == 0)
            {
                btnAdd.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
                btnEdit.Visibility = Visibility.Hidden;
            }
            else
            {
                btnAdd.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
                btnEdit.Visibility = Visibility.Visible;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var remove = dgEqui.SelectedItems.Cast<Equipment>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                context.Equipment.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                dgEqui.ItemsSource = context.Equipment.ToList();

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
            AddEditEquiPage addEditEqui = new AddEditEquiPage();
            mainFrame.Navigate(addEditEqui);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditEquiPage addEditEqui = new AddEditEquiPage();
            mainFrame.Navigate(addEditEqui);
        }

        private void dgEqui_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TextBlock a = dgEqui.Columns[0].GetCellContent(dgEqui.Items[dgEqui.SelectedIndex]) as TextBlock;
                IdChange = Convert.ToInt32(a?.Text);
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSearch.Text))
            {
                dgEqui.ItemsSource = context.Equipment.ToList();
                return;
            }
            dgEqui.ItemsSource = context.Equipment.ToList().Where(i => i.Title.Contains(tbSearch.Text));
        }
    }
}
