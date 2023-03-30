using Kon.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
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
    /// Логика взаимодействия для AEditSupPage.xaml
    /// </summary>
    public partial class AEditSupPage : Page
    {
        private Supplier supplier = new Supplier();
        public AEditSupPage()
        {
            InitializeComponent();
            if (Change == true)
            {
                Change = false;

                supplier.Id = context.Supplier.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Id;
                tbTitle.Text = context.Supplier.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Title.ToString();
                tbAddress.Text = context.Supplier.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Address.ToString();
                tbINN.Text = context.Supplier.ToList().Where(i => i.Id == IdChange).FirstOrDefault().INN.ToString();
                tbPhone.Text = context.Supplier.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Phone;
               
            }

        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                MessageBox.Show("Название не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                MessageBox.Show("Адрес не может быть пустым");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbINN.Text))
            {
                MessageBox.Show("ИНН не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Телефон не может быть пустым");
                return;
            }

            supplier.Title = tbTitle.Text;
            supplier.Address = tbAddress.Text;
            supplier.INN = tbINN.Text;
            supplier.Phone = tbPhone.Text;

            context.Supplier.AddOrUpdate(supplier);
            context.SaveChanges();
            MessageBox.Show("Успешно");


            SupPage supPage = new SupPage();
            mainFrame.Navigate(supPage);
        }
    }
}
