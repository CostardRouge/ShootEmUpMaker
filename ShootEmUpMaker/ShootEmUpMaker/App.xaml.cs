using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShootEmUpMaker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region All begin here
        private void AppStartup(object sender, StartupEventArgs e)
        {
            // Init attributes
            this.welcomeWindow = new ShootEmUpMaker.WelcomeWindow();
            this.makerWindow = new ShootEmUpMaker.MakerWindow();
            this.welcomeWindow.Show();


            // Init events
            this.welcomeWindow.CreateButton.MouseDown += CreateButton_MouseDown;
            //this.welcomeWindow.Closed+=welcomeWindow_Closed;
            
        }

        void CreateButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.welcomeWindow.Visibility = Visibility.Hidden;
            this.makerWindow.Show();
        }
        #endregion

        #region Attributes
        private ShootEmUpMaker.WelcomeWindow    welcomeWindow;
        private ShootEmUpMaker.MakerWindow      makerWindow;
        #endregion
    }
}
