using Kon.DB;
using Kon.Windows;
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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            dgClient.ItemsSource = context.Client.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var remove = dgClient.SelectedItems.Cast<Client>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                context.Client.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                dgClient.ItemsSource = context.Client.ToList();

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
            AddEditClient addEditClient = new AddEditClient();
            mainFrame.Navigate(addEditClient);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditClient addEditClient = new AddEditClient();
            mainFrame.Navigate(addEditClient);
        }

        private void dgClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TextBlock a = dgClient.Columns[0].GetCellContent(dgClient.Items[dgClient.SelectedIndex]) as TextBlock;
                IdChange = Convert.ToInt32(a?.Text);
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }
    }
}
