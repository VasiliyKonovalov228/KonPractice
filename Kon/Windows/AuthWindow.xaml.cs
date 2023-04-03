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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
            Date=DateTime.Now;
            GenerateCaptcha();
            
        }
        public void GenerateCaptcha() 
        {
            Random rnd = new Random();
            string text = "";
            string alf = "1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            for (int i = 0; i < 5; ++i)
            {
                text += alf[rnd.Next(alf.Length)];
            }
            tblCaptcha.Text = text;
        }
        private void tblReg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegWindoow reg = new RegWindoow();
            this.Close();
            reg.Show();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
                var authUser = context.Authorization.ToList()
                .Where(i => i.Login == tbLogin.Text && i.Password == pbPass.Password)
                .FirstOrDefault();
            if (tbCaptcha.Text == tblCaptcha.Text)
            {

                if (authUser != null)
                {
                    if (authUser.Active!=false)
                    {


                        string connectionString = @"Data Source=224-10\SQLEXPRESS;Initial Catalog=KonVas;Integrated Security=True";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string sqlExpression = "SELECT Id FROM Client WHERE IdAuthorization = (SELECT Id FROM [Authorization] WHERE Login='" + tbLogin.Text + "')";
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            if (command.ExecuteScalar() != null)
                            {
                                MainWindow main = new MainWindow();
                                main.Show();
                                post = 0;
                                Login=DateTime.Now.TimeOfDay;
                                IdAuthorization = authUser.Id;
                                this.Close();
                            }
                            
                            string sqlExpression2 = "SELECT Id FROM Employee WHERE IdAuthorization = (SELECT Id FROM [Authorization] WHERE Login='" + tbLogin.Text + "')";
                            SqlCommand command2 = new SqlCommand(sqlExpression2, connection);
                            if (command2.ExecuteScalar() != null)
                            {
                                AdminWindow admin = new AdminWindow();
                                admin.Show();
                                post= 1;
                                Login = DateTime.Now.TimeOfDay;
                                IdAuthorization = authUser.Id;
                                this.Close();
                            }
                            

                        }
                    }
                    else
                    {
                        MessageBox.Show("Вам запретили вход в систему");
                    }
                    
                }
                else
                {
                    GenerateCaptcha();
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            else 
            {
                GenerateCaptcha();
                MessageBox.Show("Неправельно введена капча");
                tbCaptcha.Text = "";
            }
        }

        private void btnCap_Click(object sender, RoutedEventArgs e)
        {
            GenerateCaptcha();
        }

        private void tbCaptcha_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
