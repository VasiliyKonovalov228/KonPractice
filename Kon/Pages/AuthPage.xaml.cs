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
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var remove = dgAuth.SelectedItems.Cast<Authorization>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы","Внимание",MessageBoxButton.YesNo,MessageBoxImage.Question)==MessageBoxResult.Yes)
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
    }
}
