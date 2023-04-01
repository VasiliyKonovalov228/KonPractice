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
    /// Логика взаимодействия для PostPage.xaml
    /// </summary>
    public partial class PostPage : Page
    {
        public PostPage()
        {
            InitializeComponent();
            dgPost.ItemsSource = context.Post.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var remove = dgPost.SelectedItems.Cast<Post>().ToList();
            if (MessageBox.Show("Вы точно хотите удалить выбранные элемениы", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                context.Post.RemoveRange(remove);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                dgPost.ItemsSource = context.Post.ToList();

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
            AddEditPostPage AddEditPost = new AddEditPostPage();
            mainFrame.Navigate(AddEditPost);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditPostPage AddEditPost = new AddEditPostPage();
            mainFrame.Navigate(AddEditPost);
        }

        private void dgPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TextBlock a = dgPost.Columns[0].GetCellContent(dgPost.Items[dgPost.SelectedIndex]) as TextBlock;
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
                dgPost.ItemsSource = context.Post.ToList();
                return;
            }
            dgPost.ItemsSource = context.Post.ToList().Where(i => i.Title.Contains(tbSearch.Text));
        }
    }
}
