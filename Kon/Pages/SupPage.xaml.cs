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
    /// Логика взаимодействия для SupPage.xaml
    /// </summary>
    public partial class SupPage : Page
    {
        public SupPage()
        {
            InitializeComponent();
            dgSup.ItemsSource = context.Supplier.ToList();
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
            var remove = dgSup.SelectedItems.Cast<Supplier>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                context.Supplier.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                dgSup.ItemsSource = context.Supplier.ToList();

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
           AEditSupPage AEditSup = new AEditSupPage();
            mainFrame.Navigate(AEditSup);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AEditSupPage AEditSup = new AEditSupPage();
            mainFrame.Navigate(AEditSup);
        }

        private void dgSup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TextBlock a = dgSup.Columns[0].GetCellContent(dgSup.Items[dgSup.SelectedIndex]) as TextBlock;
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
                dgSup.ItemsSource = context.Supplier.ToList();
                return;
            }
            dgSup.ItemsSource = context.Supplier.ToList().Where(i => i.Title.Contains(tbSearch.Text));
        }

        private void tbSearchAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSearchAddress.Text))
            {
                dgSup.ItemsSource = context.Supplier.ToList();
                return;
            }
            dgSup.ItemsSource = context.Supplier.ToList().Where(i => i.Address.Contains(tbSearchAddress.Text));
        }
    }
}
