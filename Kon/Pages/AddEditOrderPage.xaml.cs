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
    /// Логика взаимодействия для AddEditOrderPage.xaml
    /// </summary>
    public partial class AddEditOrderPage : Page
    {
        private Order order = new Order();
        public AddEditOrderPage()
        {
            InitializeComponent();
            dpDate.SelectedDate= DateTime.Now;
            cmbClient.ItemsSource = context.Client.ToList();
            cmbClient.SelectedIndex = 0;
            cmbClient.DisplayMemberPath = "LastName";

            if (Change == true)
            {
                Change = false;

                order.Id = context.Order.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Id;
                dpDate.SelectedDate = context.Order.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Date;
                dpDateStart.SelectedDate = context.Order.ToList().Where(i => i.Id == IdChange).FirstOrDefault().DateStart;
                dpDateEnd.SelectedDate = context.Order.ToList().Where(i => i.Id == IdChange).FirstOrDefault().DateEnd;
                tbCost.Text= context.Order.ToList().Where(i => i.Id == IdChange).FirstOrDefault().Cost.ToString();
                cmbClient.SelectedIndex= Convert.ToInt32(context.Order.ToList().Where(i => i.Id == IdChange).FirstOrDefault().IdClient);

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dpDateStart.SelectedDate.Value==null)
            {
                MessageBox.Show("Дата начала не может быть пустым");
                return;
            }
            if (dpDateEnd.SelectedDate.Value == null)
            {
                MessageBox.Show("Дата окончания не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbCost.Text))
            {
                MessageBox.Show("Цена не может быть пустой");
                return;
            }


            order.Date = dpDate.SelectedDate.Value;
            order.DateStart = dpDateStart.SelectedDate.Value;
            order.DateEnd = dpDateEnd.SelectedDate.Value;
            order.Cost=Convert.ToDecimal(tbCost.Text);
            order.IdClient = (cmbClient.SelectedItem as Client).Id;


            context.Order.AddOrUpdate(order);
            context.SaveChanges();
            MessageBox.Show("Успешно");


            OrderPage orderPage = new OrderPage();
            mainFrame.Navigate(orderPage);
        }
         
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            OrderPage orderPage =new OrderPage();
            mainFrame.Navigate(orderPage);
        }
    }
}
