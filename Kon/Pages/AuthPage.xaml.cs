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
using Kon.Windows;
using Kon.ClassHalper;
using Kon.DB;
using System.Runtime.CompilerServices;

namespace Kon.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            dgAuth.ItemsSource = context.Authorization.ToList();
            if (post==0)
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
            
                var remove = dgAuth.SelectedItems.Cast<Authorization>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                context.Authorization.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                dgAuth.ItemsSource = context.Authorization.ToList();

            }
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            
                Change = true;
                AddEditAuthPage addEditAuthPage = new AddEditAuthPage();
                mainFrame.Navigate(addEditAuthPage);
            
            
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditAuthPage addEditAuthPage = new AddEditAuthPage();
            mainFrame.Navigate(addEditAuthPage);
        }

        private void dgAuth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TextBlock a = dgAuth.Columns[0].GetCellContent(dgAuth.Items[dgAuth.SelectedIndex]) as TextBlock;
                IdChange = Convert.ToInt32(a?.Text);
            }
            catch(ArgumentOutOfRangeException)
            {

            }
            
            
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSearch.Text))
            {
                dgAuth.ItemsSource = context.Authorization.ToList();
                return;
            }
            dgAuth.ItemsSource=context.Authorization.ToList().Where(i=> i.Login.Contains(tbSearch.Text));
        }

        private void dgAuth_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var Reason = true;

            if (e.Row.GetIndex() <= context.Authorization.ToList().Count() - 1) Reason = Convert.ToBoolean(context.Authorization.ToList().ElementAtOrDefault(e.Row.GetIndex()).Active);

            if (Reason == false) e.Row.Background = new SolidColorBrush(Colors.Red);
            else e.Row.Background = new SolidColorBrush(Colors.White);
        }
    }
}
