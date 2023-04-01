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
    /// Логика взаимодействия для AddEditMatPage.xaml
    /// </summary>
    public partial class AddEditMatPage : Page
    {
        private Material material = new Material();
        public AddEditMatPage()
        {
            InitializeComponent();
            if (Change == true)
            {
                Change = false;

                material.Id = context.Material.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Id;
                tbTitle.Text = context.Material.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Title.ToString();
                tbDisc.Text = context.Material.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Discription.ToString();
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                MessageBox.Show("Название не может быть пустым");
                return;
            }


            material.Title = tbTitle.Text;
            material.Discription = tbDisc.Text;


            context.Material.AddOrUpdate(material);
            context.SaveChanges();
            MessageBox.Show("Успешно");


            MatPage matPage = new MatPage();
            mainFrame.Navigate(matPage);
        }
        
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
           MatPage matPage = new MatPage();
            mainFrame.Navigate(matPage);
        }
    }

}
