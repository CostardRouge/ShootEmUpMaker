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
            this.makerWindow = null;

            // Showing default windows
            this.welcomeWindow.Show();

            // Init events
            this.welcomeWindow.CreateButton.MouseDown += CreateNewGame;
            this.welcomeWindow.Closed += welcomeWindowClosed;
        }


        void welcomeWindowClosed(object sender, EventArgs e)
        {
            App.Current.Shutdown(0);
        }

        void makerWindowClosed(object sender, EventArgs e)
        {
            this.makerWindow = null;
            this.welcomeWindow.Show();
            //this.makerWindow.Hide();
        }

        void CreateNewGame(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.welcomeWindow.Hide();
            if (this.makerWindow == null)
            {
                this.makerWindow = new ShootEmUpMaker.MakerWindow();
                this.makerWindow.Closed += makerWindowClosed;
                this.makerWindow.Show();
            }
        }
        #endregion

        #region Attributes
        private ShootEmUpMaker.WelcomeWindow    welcomeWindow;
        public ShootEmUpMaker.MakerWindow      makerWindow;
        #endregion
    }
}
