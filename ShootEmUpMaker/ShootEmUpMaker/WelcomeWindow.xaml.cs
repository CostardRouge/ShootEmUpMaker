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

        public ImageBrush getGameBackground(string gamePath)
        {
            ShootEmUpGame game = Serialization.ImportGame(gamePath);

            //ImageBrush ret = new ImageBrush(new BitmapImage(new Uri(@"pack://application:" + gamePath)));
            //ImageBrush ret = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), game._wallpaper)));
            ImageBrush ret = new ImageBrush(new BitmapImage(new Uri(game._wallpaper, UriKind.Relative)));

            //System.Console.WriteLine(BaseUriHelper.GetBaseUri(this).ToString());
            return ret;
        }


        public void AddCreatedGames(String[] CreatedGamesFiles)
        {
            int i = 1;
            foreach (String filePath in CreatedGamesFiles)
            {
                var border = new Border() { Width = 140, Height = 260 };
                var text = new TextBlock() { FontSize = 14 };

                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.VerticalAlignment = VerticalAlignment.Center;
                text.TextWrapping = TextWrapping.Wrap;
                text.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                text.FontWeight = FontWeights.Thin;
                text.Text = System.IO.Path.GetFileNameWithoutExtension(filePath);

                border.Child = text;
                border.Name = "Game" + i.ToString();
                border.Cursor = Cursors.Hand;
                border.Background = getGameBackground(filePath);
               // border.Background = new SolidColorBrush(Color.FromRgb(194, 32, 38));
                border.Margin = new Thickness(5, 5, 5, 5);
                border.MouseDown += OpenCreatedGame;
                
                this.Games.Children.Insert(0, border);
                this.CreatedGamesFound.Add(new Tuple<String, String>(text.Text, filePath));
            }
        }

        public void LoadCreatedGames()
        {
            String UserDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            String CreatedGamePath = UserDocumentPath + "\\" + PROJECT_NAME;
            try
            {
                // List and load created games
                String[] CreatedGamesFiles = Directory.GetFiles(@CreatedGamePath, "*.xml", SearchOption.AllDirectories);
                this.AddCreatedGames(CreatedGamesFiles);

                // Updated created games information text
                int FileCount = CreatedGamesFiles.Length;
                this.gamesCreatedTextBlock.Text = String.Format("{0} game{1} already created.", FileCount, FileCount > 1 ? "s" : null);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        void OpenCreatedGame(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show(Application.Current.Windows.Count.ToString());

            String UserDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            String CreatedGamePath = UserDocumentPath + "\\" + PROJECT_NAME;

            // List and load created games
            String[] CreatedGamesFiles = Directory.GetFiles(@CreatedGamePath, "*.xml", SearchOption.AllDirectories);

            // Get created games path
            Border b = (Border)sender;
            TextBlock t = (TextBlock)b.Child;
            String gamePath = CreatedGamesFound.Find(x => x.Item1.Equals(t.Text)).Item2;

            //MessageBox.Show(gamePath);
            // WAY 1 : var win =  Application.Current.Properties["makerWindow"];

            App MyApplication = ((App)Application.Current);
            MyApplication.makerWindow = new MakerWindow();

            MyApplication.makerWindow.game = Serialization.ImportGame(gamePath);
            MyApplication.makerWindow.Closed += MyApplication.makerWindowClosed;
            MyApplication.makerWindow.Show();

            this.Hide();
        }

        public WelcomeWindow()
        {
            // Inits
            InitializeComponent();

            // Init events
            // export
            // impport
            // close (save or cancel dialog)

            // Default actions
            LoadCreatedGames();

<<<<<<< HEAD
            //Enemy Ship
=======
            ////Enemy Ship
>>>>>>> 1edd821d6bf0d4efb4696f5918f66249d33d4891
            EnemyShip enemy = new EnemyShip();
            enemy._weaponSprite = "here";
            enemy._shipSprite = "here";
            enemy._damage = 1;
            enemy._fireRate = 1;
            enemy._point = 10;

<<<<<<< HEAD
            //UserShip
=======
            ////UserShip
>>>>>>> 1edd821d6bf0d4efb4696f5918f66249d33d4891
            UserShip player = new UserShip();
            player._weaponSprite = "here";
            player._shipSprite = "here";
            player._damage = 1;
            player._fireRate = 1;
            player._life = 3;

<<<<<<< HEAD
            //Level
=======
            ////Level
>>>>>>> 1edd821d6bf0d4efb4696f5918f66249d33d4891
            Level lvl = new Level();
            lvl._wallpaper = "Here";
            lvl._music = "Here";
            lvl._enemy.Add(enemy);
            lvl._enemy.Add(enemy);

            ShootEmUpGame myGame = new ShootEmUpGame();
            myGame._name = "Best game ever";
            myGame._description = "This is my game";
            myGame._author = "Alex";
<<<<<<< HEAD
=======
            myGame._wallpaper = "17.png";
>>>>>>> 1edd821d6bf0d4efb4696f5918f66249d33d4891
            myGame._orientation = 0;
            myGame._player = player;
            myGame._levels.Add(lvl);
            myGame._levels.Add(lvl);

<<<<<<< HEAD
            //Serialization
=======
            ////Serialization
>>>>>>> 1edd821d6bf0d4efb4696f5918f66249d33d4891
            Serialization.ExportGame(myGame);
        }
    }
}
