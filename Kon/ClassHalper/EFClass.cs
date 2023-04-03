using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Kon.DB;

namespace Kon.ClassHalper
{
    public class EFClass
    {
        public static Entitie context { get; } = new Entitie();
        public static Frame mainFrame { get; set; }
        public static int IdChange = 0;
        public static bool Change=false;
        public static DateTime Date;
        public static TimeSpan Login;
        public static int IdAuthorization;
        public static int post;
    }
}
