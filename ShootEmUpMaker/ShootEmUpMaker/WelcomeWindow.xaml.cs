using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShootEmUpMaker
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        private static String PROJECT_NAME = "ShootEmUpMaker";
        private List<Tuple<String, String>> CreatedGamesFound = new List<Tuple<String, String>> ();

        private Brush getGameBackground(string gamePath)
        {
            Brush ret = null;
            ShootEmUpGame game = Serialization.ImportGame(gamePath);

            if (game != null && File.Exists(game._wallpaper))
            {
                try {
                    new Uri(game._wallpaper, UriKind.Relative);
                    ret = new ImageBrush(new BitmapImage());
                }
                catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }
            }
            else
                ret = new SolidColorBrush(Color.FromRgb(194, 32, 38));
            return ret;
        }

        private void AddCreatedGames(String[] CreatedGamesFiles)
        {
            int i = 1;
            foreach (String filePath in CreatedGamesFiles)
            {
                var border = new Border() { Width = 140, Height = 260 };
                var text = new TextBlock() { FontSize = 14 };

                text.FontWeight = FontWeights.Thin;
                text.TextWrapping = TextWrapping.Wrap;
                text.VerticalAlignment = VerticalAlignment.Center;
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.Text = System.IO.Path.GetFileNameWithoutExtension(filePath);
                text.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                border.Child = text;
                border.Cursor = Cursors.Hand;
                border.MouseDown += OpenCreatedGame;
                border.Name = "Game" + i.ToString();
                border.Margin = new Thickness(5, 5, 5, 5);
                border.Background = getGameBackground(filePath);
                
                this.Games.Children.Insert(0, border);
                this.CreatedGamesFound.Add(new Tuple<String, String>(text.Text, filePath));
            }
        }

        private String[] GetCreatedGames(String ExportFolderPath)
        {
            String[] ret = null;
            
            try {
                ret = Directory.GetDirectories(ExportFolderPath);
            }
            catch (Exception e) {
                Console.WriteLine("GetDirectories failed: {0}", e.ToString());
            }
            return (ret);
        }

        public void LoadCreatedGames()
        {
            String UserDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            String ExportFolderPath = UserDocumentPath + "\\" + PROJECT_NAME;

            try
            {
                // List and load created games
                String[] CreatedGames = Directory.GetFiles(@ExportFolderPath, "*.xml", SearchOption.AllDirectories);
                this.AddCreatedGames(CreatedGames);

                // Updated created games information text
                int GamesCount = CreatedGames.Length;
                if (GamesCount > 1)
                {
                    String tmp = String.Format("{0} game{1} already created.", GamesCount, GamesCount > 1 ? "s" : null);
                    this.infoTextBlock.Text = tmp;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        void OpenCreatedGame(object sender, MouseButtonEventArgs e)
        {
            String UserDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            String CreatedGamePath = UserDocumentPath + "\\" + PROJECT_NAME;

            // Get created games path
            Border b = (Border)sender;
            TextBlock t = (TextBlock)b.Child;
            String gamePath = CreatedGamesFound.Find(x => x.Item1.Equals(t.Text)).Item2;

            // WAY 1 : var win =  Application.Current.Properties["makerWindow"];
            // WAY 2 : I prefer this one
            App MyApplication = ((App)Application.Current);
            MyApplication.makerWindow = new MakerWindow(Serialization.ImportGame(gamePath));
            MyApplication.makerWindow.Closed += MyApplication.makerWindowClosed;
            MyApplication.makerWindow.Show();

            this.Hide();
        }

        public WelcomeWindow()
        {
            // Inits
            InitializeComponent();

            // Default actions
            LoadCreatedGames();

        //    //Enemy Ship
        //    EnemyShip enemy = new EnemyShip();
        //    enemy._weaponSprite = "here";
        //    enemy._shipSprite = "here";
        //    enemy._damage = 1;
        //    enemy._fireRate = 1;
        //    enemy._point = 10;

        //    //UserShip
        //    UserShip player = new UserShip();
        //    player._weaponSprite = "here";
        //    player._shipSprite = "here";
        //    player._damage = 1;
        //    player._fireRate = 1;
        //    player._life = 3;

        //    //Level
        //    Level lvl = new Level();
        //    lvl._wallpaper = "Here";
        //    lvl._music = "Here";
        //    lvl._enemy.Add(enemy);
        //    lvl._enemy.Add(enemy);

        //    ShootEmUpGame myGame = new ShootEmUpGame();
        //    myGame._name = "Best game ever";
        //    myGame._description = "This is my game";
        //    myGame._author = "Alex";
        //    myGame._wallpaper = "17.png";
        //    myGame._orientation = 0;
        //    myGame._player = player;
        //    myGame._levels.Add(lvl);
        //    myGame._levels.Add(lvl);

        //    //Serialization
        //    Serialization.ExportGame(myGame);
        //
        }
    }
}