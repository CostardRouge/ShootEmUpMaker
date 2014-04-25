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
        public ShootEmUpGame game { get; set; }

        public MakerWindow()
        {
            // Inits
            InitializeComponent();
            this.game = new ShootEmUpGame();

            // test
            this.game.Name = "totot";


            // affect
            this.gameNameTextBox.Text = this.game.Name;


            // Init events
            this.GeneralSettingsTextBlock.MouseDown += GeneralSettingsTextBlockMouseDown;
            this.MenuAndPlayerTextBlock.MouseDown += MenuAndPlayerPanelMouseDown;
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

            Binding myBinding = new Binding("GameProperty");


            myBinding.Source = this.game;
            this.gameNameTextBox.SetBinding(TextBlock.TextProperty, myBinding);
        }

        void CreateNewLevel(object sender, MouseButtonEventArgs e)
        {
            // 
            int LevelsCount = this.game._levels.Count;
            ShootEmUpMaker.Level NewLevel = new ShootEmUpMaker.Level() { _number=LevelsCount + 1};
            NewLevel._name = String.Format("Level #{0}", NewLevel._number);
            this.game._levels.Add(NewLevel);

            // Add a the level to the panel switcher
            TextBlock NewLevelTextBlock = new TextBlock() { Height=160, FontSize=18};
            NewLevelTextBlock.Text = NewLevel._name;
            NewLevelTextBlock.ToolTip = "LOL";
            NewLevelTextBlock.Cursor = Cursors.Hand;
            NewLevelTextBlock.FontWeight = FontWeights.Thin;
            NewLevelTextBlock.TextWrapping = TextWrapping.Wrap;
            NewLevelTextBlock.Margin = new Thickness(5, 5, 5, 5);
            NewLevelTextBlock.Padding = new Thickness(10, 20, 10, 20);
            NewLevelTextBlock.VerticalAlignment = VerticalAlignment.Center;
            NewLevelTextBlock.Background = new SolidColorBrush(Color.FromRgb(65, 65, 65));
            NewLevelTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            this.PanelSwitcher.Children.Insert(this.PanelSwitcher.Children.Count - 1, NewLevelTextBlock);
            NewLevelTextBlock.MouseDown += LevelTextBlockMouseDown;


            // Update create level button
            this.CreateNewLevelButton.Text = "Add another level...";


            // Scroll down the PanelSwitcherViewer
            this.PanelSwitcherViewer.ScrollToBottom();


            MessageBox.Show(this.game.Name);
        }
    }
}
