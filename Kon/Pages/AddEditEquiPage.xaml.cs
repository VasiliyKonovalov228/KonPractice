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
    /// Логика взаимодействия для AddEditEquiPage.xaml
    /// </summary>
    public partial class AddEditEquiPage : Page
    {
        private Equipment equipment = new Equipment();
        public AddEditEquiPage()
        {
            
            InitializeComponent();
            if (Change == true)
            {
                Change = false;

                equipment.Id = context.Equipment.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Id;
                tbTitle.Text = context.Equipment.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Title.ToString();
                tbDisc.Text = context.Equipment.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Discription.ToString();
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                MessageBox.Show("Название не может быть пустым");
                return;
            }
            

            equipment.Title = tbTitle.Text;
            equipment.Discription = tbDisc.Text;


            context.Equipment.AddOrUpdate(equipment);
            context.SaveChanges();
            MessageBox.Show("Успешно");


            EquiPage equiPage = new EquiPage();
            mainFrame.Navigate(equiPage);
        }
         
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AuthPage authPage = new AuthPage();
            mainFrame.Navigate(authPage);
        }
    }
}
