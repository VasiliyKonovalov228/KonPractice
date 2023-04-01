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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Kon.ClassHalper.EFClass;

namespace Kon.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditDrawingPage.xaml
    /// </summary>
    public partial class AddEditDrawingPage : Page
    {
        private DB.Drawing drawing = new DB.Drawing();
        public AddEditDrawingPage()
        {
            InitializeComponent();
            if (Change == true)
            {
                Change = false;

                drawing.Id = context.Drawing.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Id;
                tbTitle.Text = context.Drawing.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Title.ToString();
                tbPhoto.Text = context.Drawing.ToList().Where(i => i.Id == IdChange).FirstOrDefault().PhotoPath.ToString();
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                MessageBox.Show("Название не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPhoto.Text))
            {
                MessageBox.Show("Ссылка не может быть пустой");
                return;
            }

            drawing.Title = tbTitle.Text;
            drawing.PhotoPath = tbPhoto.Text;
            

            context.Drawing.AddOrUpdate(drawing);
            context.SaveChanges();
            MessageBox.Show("Успешно");


            DrawPage drawPage = new DrawPage();
            mainFrame.Navigate(drawPage);
        }
         
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            DrawPage drawPage = new DrawPage();
            mainFrame.Navigate(drawPage);
        }
    }
}
