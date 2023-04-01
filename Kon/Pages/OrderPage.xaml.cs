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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            dgOrder.ItemsSource = context.Order.ToList();
            cmbClient.ItemsSource = context.Client.ToList();
            cmbClient.DisplayMemberPath = "LastName";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var remove = dgOrder.SelectedItems.Cast<Order>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                context.Order.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                dgOrder.ItemsSource = context.Order.ToList();

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
            AddEditOrderPage addEditOrder = new AddEditOrderPage();
            mainFrame.Navigate(addEditOrder);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditOrderPage addEditOrder = new AddEditOrderPage();
            mainFrame.Navigate(addEditOrder);
        }

        private void dgOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TextBlock a = dgOrder.Columns[0].GetCellContent(dgOrder.Items[dgOrder.SelectedIndex]) as TextBlock;
                IdChange = Convert.ToInt32(a?.Text);
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        private void cmbClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgOrder.ItemsSource = context.Order.ToList().Where(i => i.IdClient == (cmbClient.SelectedItem as Client).Id);
        }
    }
}
