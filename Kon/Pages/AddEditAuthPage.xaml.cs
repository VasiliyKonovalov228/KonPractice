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
            if (Change==true)
            {
                Change = false;
                
                   authorization.Id = context.Authorization.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Id;
                   tbLogin.Text = context.Authorization.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Login.ToString();
                   tbPass.Text = context.Authorization.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Password.ToString();
                 
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
          
            context.Authorization.AddOrUpdate(authorization);
            context.SaveChanges();
            MessageBox.Show("Успешно");
            AuthPage authPage = new AuthPage();
            mainFrame.Navigate(authPage);
        }
    }
}
