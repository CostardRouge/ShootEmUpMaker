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
using System.IO;

namespace ShootEmUpMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MakerWindow : Window
    {
        private ShootEmUpGame game { get; set; }

        public MakerWindow(ShootEmUpGame _game = null)
        {
            // Inits
            InitializeComponent();

            // Default actions
            this.game = _game != null ? _game : new ShootEmUpGame();
            this.LoadGameObject();

            // Init events
            this.gameNameTextBox.TextChanged += gameNameTextBoxTextChanged;
            this.GeneralSettingsTextBlock.MouseDown += GeneralSettingsTextBlockMouseDown;
            this.MenuAndPlayerTextBlock.MouseDown += MenuAndPlayerPanelMouseDown;
            this.CreateNewLevelButton.MouseDown += CreateNewLevel;
        }

        void LoadGameObject()
        {
            // Basics
            if (this.game._name != null)
            {
                this.HomePageTextBlock.Visibility = Visibility.Hidden;
                this.GeneralSettingsTextBlockMouseDown(null, null);
            }
            this.UpdateGameNameTextBlock();

            // Load levels data
            this.game._levels.ForEach(l => this.AddLevelObject(l));
            if (this.game._levels.Count > 0)
                this.CreateNewLevelButton.Text = "Add another level...";
        }

        void LevelTextBlockMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Hide all the panels
            foreach (UIElement x in this.Panels.Children)
                x.Visibility = Visibility.Hidden;

            // Show the concerned panel
            this.LevelPanel.Visibility = Visibility.Visible;
            
            // Bind level object content to the panel
            TextBlock LevelTextBlock = (TextBlock)sender;
           
            ShootEmUpMaker.Level lvl = this.game._levels.Find(l => l._name.Equals(LevelTextBlock.Text));
            this.LevelPanel.DataContext = lvl;
        }

        void MenuAndPlayerPanelMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Hide all the panels
            foreach (UIElement x in this.Panels.Children)
                x.Visibility = Visibility.Hidden;

            // Show the concerned panel
            this.MenuAndPlayerPanel.Visibility = Visibility.Visible;

            // Bind date to view
            this.MenuAndPlayerPanel.DataContext = this.game;
        }

        void GeneralSettingsTextBlockMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Hide all the panels
            foreach (UIElement x in this.Panels.Children)
                x.Visibility = Visibility.Hidden;

            // Show the concerned panel
            this.GeneralSettingsPanel.Visibility = Visibility.Visible;

            // Bind date to view
            this.GeneralSettingsPanel.DataContext = this.game;
        }

        void AddLevelObject(ShootEmUpMaker.Level Level)
        {
            // Add a the level to the panel switcher
            TextBlock NewLevelTextBlock = new TextBlock() { Height = 160, FontSize = 18 };
            NewLevelTextBlock.Text = Level._name;
            NewLevelTextBlock.ToolTip = String.Format("Click here to edit level #{0}", Level._number);
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
        }

        void CreateNewLevel(object sender, MouseButtonEventArgs e)
        {
            // 
            int LevelsCount = this.game._levels.Count;
            ShootEmUpMaker.Level NewLevel = new ShootEmUpMaker.Level() { _number = LevelsCount + 1 };
            NewLevel._name = String.Format("Level #{0}", NewLevel._number);
            this.game._levels.Add(NewLevel);

            // Add level item to the view
            this.AddLevelObject(NewLevel);

            // Update create level button and game name text
            this.UpdateGameNameTextBlock();
            if (this.game._levels.Count > 0)
                this.CreateNewLevelButton.Text = "Add another level...";

            // Scroll down the PanelSwitcherViewer
            this.PanelSwitcherViewer.ScrollToBottom();
        }

        void gameNameTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            this.UpdateGameNameTextBlock();
        }

        void UpdateGameNameTextBlock()
        {
            String tmp = this.game._levels.Count() > 1 ? "s" : null;
            String LevelsText = String.Format("{0} level{1}", this.game._levels.Count(), tmp);
            this.GameNameTexBlock.Text = String.Format("{0} ({1})", this.game._name, LevelsText);
        }

        private void ExportGameMouseDown(object sender, MouseButtonEventArgs e)
        {
            Serialization.ExportGame(this.game);
            MessageBox.Show("Exportation done !", "Export feedback");
        }

        private void browsePlayerSprite(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Title = "Select a file";

            if (dlg.ShowDialog() == true)
            {
                this.game._player._shipSprite = dlg.FileName;
                this.playerSpriteTextBox.Text = dlg.FileName;
            }
        }

        private void browseWeaponSprite(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Title = "Select a file";

            if (dlg.ShowDialog() == true)
            {
                this.game._player._weaponSprite = dlg.FileName;
                this.weaponSpriteTextbox.Text = dlg.FileName;
            }
        }

        private void browseMenuWallSprite(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Title = "Select a file";

            if (dlg.ShowDialog() == true)
            {
                this.game._wallpaper = dlg.FileName;
                this.menuWallSpriteTextBox.Text = dlg.FileName;
            }
        }

        private void BrowseLevelWall(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Title = "Select a file";

            if (dlg.ShowDialog() == true)
            {
                this.wally.Text = dlg.FileName;
            }
        }

        private void BrowseLevelMusic(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Title = "Select a file";

            if (dlg.ShowDialog() == true)
            {
                this.music.Text = dlg.FileName;
            }
        }
    }
}
