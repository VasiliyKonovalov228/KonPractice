using Kon.DB;
using Kon.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
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
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSearch.Text))
            {
                dgClient.ItemsSource = context.Client.ToList();
                return;
            }
            dgClient.ItemsSource = context.Client.ToList().Where(i => i.LastName.Contains(tbSearch.Text));
        }

        private void tbSearchPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSearchPhone.Text))
            {
                dgClient.ItemsSource = context.Client.ToList();
                return;
            }
            dgClient.ItemsSource = context.Client.ToList().Where(i => i.Phone.Contains(tbSearchPhone.Text));
        }
        private void chb_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            switch (cb.Name)
            {


                case "chbFst":
                    if (chbFst.IsChecked == false) colFname.Visibility = Visibility.Hidden;
                    else colFname.Visibility = Visibility.Visible; break;

                case "chbLst":
                    if (chbLst.IsChecked == false) colLname.Visibility = Visibility.Hidden;
                    else colLname.Visibility = Visibility.Visible; break;

                case "chbPtr":
                    if (chbPtr.IsChecked == false) colPatronymic.Visibility = Visibility.Hidden;
                    else colPatronymic.Visibility = Visibility.Visible; break;

                case "chbBrt":
                    if (chbBrt.IsChecked == false) colBirthday.Visibility = Visibility.Hidden;
                    else colBirthday.Visibility = Visibility.Visible; break;

                case "chbPhn":
                    if (chbPhn.IsChecked == false) colPhone.Visibility = Visibility.Hidden;
                    else colPhone.Visibility = Visibility.Visible; break;

                case "chbEml":
                    if (chbEml.IsChecked == false) colEmail.Visibility = Visibility.Hidden;
                    else colEmail.Visibility = Visibility.Visible; break;
                case "chbAcc":
                    if (chbAcc.IsChecked == false) colAcc.Visibility = Visibility.Hidden;
                    else colAcc.Visibility = Visibility.Visible; break;
                case "chbId":
                    if (chbId.IsChecked == false) colId.Visibility = Visibility.Hidden;
                    else colId.Visibility = Visibility.Visible; break;
            }
        }
    }
}
