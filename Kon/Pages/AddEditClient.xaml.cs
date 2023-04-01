using Kon.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для AddEditClient.xaml
    /// </summary>
    public partial class AddEditClient : Page
    {
        private Client client = new Client();
        public AddEditClient()
        {
            InitializeComponent();
            if (Change == true)
            {
                Change = false;

                client.Id = context.Client.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Id;
                tbFName.Text = context.Client.ToList().Where(i => i.Id == IdChange).FirstOrDefault().FirstName.ToString();
                tbLName.Text = context.Client.ToList().Where(i => i.Id == IdChange).FirstOrDefault().LastName.ToString();
                tbPatr.Text = context.Client.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Patronymic.ToString();
                dpBirthDay.SelectedDate = context.Client.ToList().Where(i => i.Id == IdChange).FirstOrDefault().BirthDay;
                tbEmail.Text = context.Client.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Email.ToString();
                tbPhone.Text = context.Client.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Phone.ToString();
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFName.Text))
            {
                MessageBox.Show("Имя не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbLName.Text))
            {
                MessageBox.Show("Фамилия не может быть пустым");
                return;
            }
           
            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Email не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Телефон не может быть пустым");
                return;
            }

            client.FirstName = tbFName.Text;
            client.LastName = tbLName.Text;
            client.Patronymic= tbPatr.Text;
            client.BirthDay = dpBirthDay.SelectedDate.Value;
            client.Email = tbEmail.Text;    
            client.Phone = tbPhone.Text;

            context.Client.AddOrUpdate(client);
            context.SaveChanges();
            MessageBox.Show("Успешно");

            
            ClientPage clientPage = new ClientPage();
            mainFrame.Navigate(clientPage);
        }
        
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ClientPage clientPage = new ClientPage();
            mainFrame.Navigate(clientPage);
        }
    }
}
