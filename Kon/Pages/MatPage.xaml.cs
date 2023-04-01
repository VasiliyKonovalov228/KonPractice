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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Kon.ClassHalper.EFClass;


namespace Kon.Pages
{
    /// <summary>
    /// Логика взаимодействия для MatPage.xaml
    /// </summary>
    public partial class MatPage : Page
    {
        public MatPage()
        {
            InitializeComponent();
            dgMat.ItemsSource = context.Material.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var remove = dgMat.SelectedItems.Cast<Material>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                context.Material.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                dgMat.ItemsSource = context.Material.ToList();

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
            AddEditMatPage addEditMat = new AddEditMatPage();
            mainFrame.Navigate(addEditMat);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           AddEditMatPage addEditMat = new AddEditMatPage();
            mainFrame.Navigate(addEditMat);
        }

       

        private void dgMat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TextBlock a = dgMat.Columns[0].GetCellContent(dgMat.Items[dgMat.SelectedIndex]) as TextBlock;
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
                dgMat.ItemsSource = context.Material.ToList();
                return;
            }
            dgMat.ItemsSource = context.Material.ToList().Where(i => i.Title.Contains(tbSearch.Text));
        }
    }
}
