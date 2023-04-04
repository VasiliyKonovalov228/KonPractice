using Kon.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
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
        private string pathPhoto = null;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public AddEditDrawingPage()
        {
            InitializeComponent();
            if (Change == true)
            {
                Change = false;

                drawing.Id = context.Drawing.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Id;
                tbTitle.Text = context.Drawing.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Title.ToString();
                if (context.Drawing.ToList().Where(i => i.Id == IdChange).FirstOrDefault().PhotoPath is null)
                {

                }
                else {
                         ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
                        imgProduct.Source = (ImageSource)imageSourceConverter.ConvertFrom(context.Drawing.ToList().Where(i => i.Id == IdChange).FirstOrDefault().PhotoPath);
                   }
              }
         }
        
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                MessageBox.Show("Название не может быть пустым");
                return;
            }

            drawing.Title = tbTitle.Text;
            drawing.PhotoPath = File.ReadAllBytes(pathPhoto) ;
            

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

        private void btnChooseImage_Click(object sender, RoutedEventArgs e)
        {
           
            if (openFileDialog.ShowDialog() == true)
            {
                imgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathPhoto = openFileDialog.FileName;
            }
        }
    }
}
