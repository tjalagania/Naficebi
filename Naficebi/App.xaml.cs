using NaficebiLib.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Naficebi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsRunning = false;
        public static Clerk Clerk { get; set; } = new Clerk();
        public static CourtCase CourtCase { get; set; } = new CourtCase();
    }
}
