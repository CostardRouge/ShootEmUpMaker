using System;
using System.Collections.Generic;
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

namespace ShootEmUpMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MakerWindow : Window
    {
        public MakerWindow()
        {
            InitializeComponent();

            // Init events
            this.GeneralSettingsTextBlock.MouseDown += GeneralSettingsTextBlockMouseDown;
            this.MenuAndPlayerTextBlock.MouseDown += MenuAndPlayerPanelMouseDown;
            this.LevelTextBlock.MouseDown += LevelTextBlockMouseDown;
            this.CreateNewLevelButton.MouseDown += CreateNewLevel;
        }

        void LevelTextBlockMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Hide all the panels
            foreach (UIElement x in this.Panels.Children)
                x.Visibility = Visibility.Hidden;

            // Show the concerned panel
            this.LevelPanel.Visibility = Visibility.Visible;
        }

        void MenuAndPlayerPanelMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Hide all the panels
            foreach (UIElement x in this.Panels.Children)
                x.Visibility = Visibility.Hidden;

            // Show the concerned panel
            this.MenuAndPlayerPanel.Visibility = Visibility.Visible;
        }

        void GeneralSettingsTextBlockMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Hide all the panels
            foreach (UIElement x in this.Panels.Children)
                x.Visibility = Visibility.Hidden;

            // Show the concerned panel
            this.GeneralSettingsPanel.Visibility = Visibility.Visible;
        }

        void CreateNewLevel(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("lol");
        }
    }
}
