using System;
using System.Collections.Generic;
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
using Kon.Windows;
using Kon.DB;
using Kon.Pages;

namespace Kon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lbDate.Content = DateTime.Now.ToString().Substring(0, 10);
            lbTime.Content = DateTime.Now.ToShortTimeString();
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, t) => { lbDate.Content = DateTime.Now.ToString().Substring(0, 10); };
            timer.Tick += (o, t) => { lbTime.Content = DateTime.Now.ToShortTimeString(); };
            timer.Start();
        }
        private void btnItemSorce_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            switch (item.Header)
            {
                case "Материал":
                    MatPage matPage = new MatPage();
                    mainFrame.Navigate(matPage);
                    break;
                case "Оборудование":
                    EquiPage equiPage = new EquiPage();
                    mainFrame.Navigate(equiPage);
                    break;
                case "Сотрудник":
                    EmpPage empPage = new EmpPage();
                    mainFrame.Navigate(empPage);
                    break;
                case "Должность":
                    PostPage postPage = new PostPage();
                    mainFrame.Navigate(postPage);
                    break;
                case "Чертёж":
                    DrawPage drawPage = new DrawPage();
                    mainFrame.Navigate(drawPage);
                    break;
                case "Клиент":
                    ClientPage cliePage = new ClientPage();
                    mainFrame.Navigate(cliePage);
                    break;
                case "Заказ":
                    OrderPage ordePage = new OrderPage();
                    mainFrame.Navigate(ordePage);
                    break;
                case "Авторизация":
                    AuthPage authPage = new AuthPage();
                    mainFrame.Navigate(authPage);
                    break;
                case "Поставщик":
                    SupPage supPage = new SupPage();
                    mainFrame.Navigate(supPage);
                    break;
                case "Статистика":
                    StatisticPage statisticPage = new StatisticPage();
                    mainFrame.Navigate(statisticPage);
                    break;
                case "Выход":
                    this.Close();
                    break;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Log log = new Log();
                log.Date = Date.ToString("d");
                log.LoginTime = Login.ToString().Substring(0, 8);
                log.LogoutTime = DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
                log.TimeSpentOnSystem = (DateTime.Now.TimeOfDay - Login).ToString().Substring(1, 7);
                log.IdAthorization = IdAuthorization;
                context.Log.Add(log);
                context.SaveChanges();
            }
            catch
            {

            }
        }
    }
}
