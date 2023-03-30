using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using Kon.ClassHalper;
using static System.Net.Mime.MediaTypeNames;
using static Kon.ClassHalper.EFClass;

namespace Kon.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegWindoow.xaml
    /// </summary>
    public partial class RegWindoow : Window
    {
        public RegWindoow()
        {
            InitializeComponent();
        }

        private void tblReg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }
        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(tbFname.Text))
            {
                MessageBox.Show("Имя не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbLname.Text))
            {
                MessageBox.Show("Фамилия не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым");
                return;
            }
            
            if (string.IsNullOrWhiteSpace(pbPass.Password))
            {
                MessageBox.Show("Пароль не может быть пустым");

                return;
            }
            if (string.IsNullOrWhiteSpace(dpBirthDay.Text))
            {

                MessageBox.Show("Дата не может быть пустой");
                return;
            }

            var authUser = context.Authorization.ToList()
                .Where(i => i.Login == tbLogin.Text && i.Password == pbPass.Password)
                .FirstOrDefault();
            if (authUser != null)
            {
                MessageBox.Show("Логин занят");
                return;
            }
            DB.Authorization auth = new DB.Authorization();
            auth.Login = tbLogin.Text;
            auth.Password = pbPass.Password;
            DB.Client client = new DB.Client();
            client.FirstName = tbFname.Text;
            client.LastName = tbLname.Text;
            client.Phone = tbPhone.Text;
            client.Email = tbEmail.Text;
            client.Patronymic = tbPatronymic.Text;
            client.BirthDay = dpBirthDay.SelectedDate.Value;
            context.Authorization.Add(auth);
            context.Client.Add(client);
            context.SaveChanges();
            MessageBox.Show("Ok");
        }

        private void tbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
