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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Kon.DB;
using Kon.Pages;
using static Kon.ClassHalper.EFClass;



namespace Kon.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
           
        }

        private void btnItemSorce_Click(object sender, RoutedEventArgs e)
        {
            Button but = (Button)sender;
            switch (but.Name) 
            {
                case "btnMat":
                    Hidd();
                    MatPage matPage = new MatPage();
                   mainFrame.Navigate(matPage);
                    break;
                case "btnEqui":
                    Hidd();
                    EquiPage equiPage = new EquiPage();
                    mainFrame.Navigate(equiPage);
                    break;
                case "btnEmp":
                    Hidd();
                    EmpPage empPage = new EmpPage();
                    mainFrame.Navigate(empPage);
                    break;
                case "btnPost":
                    Hidd();
                    PostPage postPage = new PostPage();
                    mainFrame.Navigate(postPage);
                    break;
                case "btnDraw":
                    Hidd();
                   DrawPage drawPage = new DrawPage();
                    mainFrame.Navigate(drawPage);
                    break;
                case "btnClient":
                    Hidd();
                    ClientPage cliePage = new ClientPage();
                    mainFrame.Navigate(cliePage);
                    break;
                case "btnOrder":
                    Hidd();
                    OrderPage ordePage = new OrderPage();
                    mainFrame.Navigate(ordePage);
                    break;
                case "btnAuth":
                    Hidd();
                    AuthPage authPage = new AuthPage();
                    mainFrame.Navigate(authPage);
                    break;
                case "btnSup":
                    Hidd();
                    SupPage supPage = new SupPage();
                    mainFrame.Navigate(supPage);
                    break;
            }
        }
        public void Hidd()
        {
            btnMat.Visibility = Visibility.Hidden;
            btnEqui.Visibility = Visibility.Hidden;
            btnPost.Visibility = Visibility.Hidden;
            btnDraw.Visibility = Visibility.Hidden;
            btnClient.Visibility = Visibility.Hidden;
            btnOrder.Visibility = Visibility.Hidden;
            btnAuth.Visibility = Visibility.Hidden;
            btnEmp.Visibility = Visibility.Hidden;
            btnSup.Visibility = Visibility.Hidden;
            mainFrame.Visibility = Visibility.Visible;
            btnBack.Visibility = Visibility.Visible;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            btnMat.Visibility = Visibility.Visible;
            btnEqui.Visibility = Visibility.Visible;
            btnPost.Visibility = Visibility.Visible;
            btnDraw.Visibility = Visibility.Visible;
            btnClient.Visibility = Visibility.Visible;
            btnOrder.Visibility = Visibility.Visible;
            btnEmp.Visibility = Visibility.Visible;
            btnAuth.Visibility = Visibility.Visible;
            btnSup.Visibility = Visibility.Visible;
            mainFrame.Visibility = Visibility.Hidden;
            btnBack.Visibility = Visibility.Hidden;
        }
    }
}
