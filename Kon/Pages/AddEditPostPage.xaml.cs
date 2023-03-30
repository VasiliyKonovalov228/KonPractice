using Kon.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Kon.ClassHalper.EFClass;

namespace Kon.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPostPage.xaml
    /// </summary>
    public partial class AddEditPostPage : Page
    {
        private Post post = new Post();
        public AddEditPostPage()
        {
            InitializeComponent();
            if (Change == true)
            {
                Change = false;

                post.Id = context.Post.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Id;
                tbTitle.Text = context.Post.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Title.ToString();
                tbDisc.Text = context.Post.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Discription.ToString();
                tbSalary.Text = context.Post.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Salary.ToString();
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                MessageBox.Show("Название не может быть пустым");
                return;
            }


            post.Title = tbTitle.Text;
            post.Discription = tbDisc.Text;
            post.Salary = Convert.ToDecimal(tbSalary.Text);


            context.Post.AddOrUpdate(post);
            context.SaveChanges();
            MessageBox.Show("Успешно");


            PostPage postPage = new PostPage();
            mainFrame.Navigate(postPage);
        }
    }
}
