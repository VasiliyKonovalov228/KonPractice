using Kon.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для DrawPage.xaml
    /// </summary>
    public partial class DrawPage : Page
    {
        public DrawPage()
        {
            InitializeComponent();
            dgDraw.ItemsSource = context.Drawing.ToList();
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
            var remove = dgDraw.SelectedItems.Cast<DB.Drawing>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                context.Drawing.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                dgDraw.ItemsSource = context.Drawing.ToList();

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
            AddEditDrawingPage addEditDrawing = new AddEditDrawingPage();
            mainFrame.Navigate(addEditDrawing);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditDrawingPage addEditDrawing = new AddEditDrawingPage();
            mainFrame.Navigate(addEditDrawing);
        }

        private void dgDraw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TextBlock a = dgDraw.Columns[0].GetCellContent(dgDraw.Items[dgDraw.SelectedIndex]) as TextBlock;
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
                dgDraw.ItemsSource = context.Drawing.ToList();
                return;
            }
            dgDraw.ItemsSource = context.Drawing.ToList().Where(i => i.Title.Contains(tbSearch.Text));
        }
    }
}
