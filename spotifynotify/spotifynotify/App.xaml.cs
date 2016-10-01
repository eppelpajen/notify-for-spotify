using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace spotifynotify
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            App.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            var scraper = new SpotifyScraper();
            var tray = new TrayIcon();
        }
    }
}
