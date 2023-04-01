using Kon.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для AddEditAuthPage.xaml
    /// </summary>
    public partial class AddEditAuthPage : Page
    {
        private Authorization authorization = new Authorization();
        public AddEditAuthPage()
        {
          
            InitializeComponent();
            cmbActive.SelectedIndex= 0;
            if (Change==true)
            {
                Change = false;
                
                   authorization.Id = context.Authorization.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Id;
                   tbLogin.Text = context.Authorization.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Login.ToString();
                   tbPass.Text = context.Authorization.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Password.ToString();
                if (context.Authorization.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Active==true)
                {
                    cmbActive.SelectedIndex = 0;
                }
                else if (context.Authorization.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Active == false)
                {
                    cmbActive.SelectedIndex = 1;
                }
                
                 
            }
        }
       

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPass.Text))
            {
                MessageBox.Show("Пароль не может быть пустым");
                return;
            }
            
            authorization.Login = tbLogin.Text;
            authorization.Password= tbPass.Text;
            if (cmbActive.SelectedIndex==0)
            {
                authorization.Active = true;
            }
            else
            {
                authorization.Active = false;
            }
            
            context.Authorization.AddOrUpdate(authorization);
            context.SaveChanges();
            MessageBox.Show("Успешно");
            AuthPage authPage = new AuthPage();
            mainFrame.Navigate(authPage);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AuthPage authPage = new AuthPage();
            mainFrame.Navigate(authPage);
        }
    }
}
