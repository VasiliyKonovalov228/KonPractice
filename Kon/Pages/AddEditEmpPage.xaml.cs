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
    /// Логика взаимодействия для AddEditEmpPage.xaml
    /// </summary>
    public partial class AddEditEmpPage : Page
    {
        private Employee employee = new Employee();
        public AddEditEmpPage()
        {
            InitializeComponent();
            cmbPost.ItemsSource=context.Post.ToList();
            cmbPost.SelectedIndex=0;
            cmbPost.DisplayMemberPath = "Title";
            if (Change == true)
            {
                Change = false;

                employee.Id = context.Employee.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Id;
                tbFName.Text = context.Employee.ToList().Where(i => i.Id == IdChange).FirstOrDefault().FirstName.ToString();
                tbLName.Text = context.Employee.ToList().Where(i => i.Id == IdChange).FirstOrDefault().LastName.ToString();
                tbPatr.Text = context.Employee.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Patronymic.ToString();
                dpBirthDay.SelectedDate = context.Employee.ToList().Where(i => i.Id == IdChange).FirstOrDefault().BirthDay;
                tbEmail.Text = context.Employee.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Email.ToString();
                tbPhone.Text = context.Employee.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Phone.ToString();
                cmbPost.SelectedIndex = context.Employee.ToList().Where(i => i.Id == IdChange).FirstOrDefault().IdPost;
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

            employee.FirstName = tbFName.Text;
            employee.LastName = tbLName.Text;
            employee.Patronymic = tbPatr.Text;
            employee.BirthDay = dpBirthDay.SelectedDate.Value;
            employee.Email = tbEmail.Text;
            employee.Phone = tbPhone.Text;
            employee.IdPost=(cmbPost.SelectedItem as Post).Id;
            employee.IdAuthorization = null;

            context.Employee.AddOrUpdate(employee);
            context.SaveChanges();
            MessageBox.Show("Успешно");


            EmpPage emp = new EmpPage();
            mainFrame.Navigate(emp);
        }
    }
}
