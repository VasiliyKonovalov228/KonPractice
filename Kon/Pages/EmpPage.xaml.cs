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
    /// Логика взаимодействия для EmpPage.xaml
    /// </summary>
    public partial class EmpPage : Page
    {
        public EmpPage()
        {
            InitializeComponent();
            dgEmp.ItemsSource = context.Employee.ToList();
            cmbPost.ItemsSource= context.Post.ToList();
            cmbPost.DisplayMemberPath = "Title";
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var remove = dgEmp.SelectedItems.Cast<Employee>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                context.Employee.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                dgEmp.ItemsSource = context.Employee.ToList();

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
            AddEditEmpPage addEditEmpPage = new AddEditEmpPage();
            mainFrame.Navigate(addEditEmpPage);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditEmpPage addEditEmpPage = new AddEditEmpPage();
            mainFrame.Navigate(addEditEmpPage);
        }

        private void dgEmp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TextBlock a = dgEmp.Columns[0].GetCellContent(dgEmp.Items[dgEmp.SelectedIndex]) as TextBlock;
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
                dgEmp.ItemsSource = context.Employee.ToList();
                return;
            }
            dgEmp.ItemsSource = context.Employee.ToList().Where(i => i.LastName.Contains(tbSearch.Text));
        }

        private void tbSearchPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSearchPhone.Text))
            {
                dgEmp.ItemsSource = context.Employee.ToList();
                return;
            }
            dgEmp.ItemsSource = context.Employee.ToList().Where(i => i.Phone.Contains(tbSearchPhone.Text));
        }

        private void cmbPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgEmp.ItemsSource=context.Employee.ToList().Where(i=> i.IdPost==(cmbPost.SelectedItem as Post).Id);
        }
    }
}
