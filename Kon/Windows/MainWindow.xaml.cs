﻿using System;
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
            GetDrawing();
        }
        private void GetDrawing()
        {
            List<DB.Drawing> DrawList = new List<DB.Drawing>();
            DrawList = context.Drawing.ToList();
            LvDrawingList.ItemsSource = DrawList;
        }
    }
}
