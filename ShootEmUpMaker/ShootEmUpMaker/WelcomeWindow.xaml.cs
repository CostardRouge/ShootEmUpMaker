using System;
using System.IO;
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
using System.Windows.Shapes;
using System.IO;

namespace ShootEmUpMaker
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();
<<<<<<< HEAD

            try
            {
                int i = 1;
                string Docpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string finalpath = Docpath + "\\" + "ShootEmUpMaker";
                string[] filePaths = Directory.GetFiles(@finalpath, "*.xml");
                foreach (string x in filePaths)
                {
                    var border = new Border();
                    var text = new TextBlock();
                    text.HorizontalAlignment = HorizontalAlignment.Center;
                    text.VerticalAlignment = VerticalAlignment.Center;
                    text.FontSize = 36;
                    text.Foreground = new SolidColorBrush(Color.FromRgb(255,255,255));
                    //text.FontWeight = FontWeight;
                    text.Text = x;
                    //<TextBlock x:Name="CreateButton" Text="+" HorizontalAlignment="Center"
                    //VerticalAlignment="Center" ToolTip="Click here to create a new game" FontSize="36" Foreground="White" FontWeight="Thin" />

                    border.Child = text;
                    border.Name = "Game"  + i.ToString();
                    border.Width = 140;
                    border.Height = 260;
                    border.Background = new SolidColorBrush(Color.FromRgb(0, 111, 111));
                    border.Margin = new Thickness(5,5,5,5);

                    this.Games.Children.Add(border);
                    i++;
                    MessageBox.Show(x);
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            

           

           // var toto = new Label();
            //toto.Content = "toto";
            //this.Games.Children.Add(toto);
        }    
=======
            
            //Enemy Ship
            EnemyShip enemy = new EnemyShip();
            enemy._weaponSprite = "here";
            enemy._shipSprite = "here";
            enemy._damage = 1;
            enemy._fireRate = 1;
            enemy._point = 10;

            //UserShip
            UserShip player = new UserShip();
            player._weaponSprite = "here";
            player._shipSprite = "here";
            player._damage = 1;
            player._fireRate = 1;
            player._life = 3;

            //Level
            Level lvl = new Level();
            lvl._wallpaper = "Here";
            lvl._music = "Here";
            lvl._enemy.Add(enemy);
            lvl._enemy.Add(enemy);

            ShootEmUpGame myGame = new ShootEmUpGame();

            myGame._author = "Alex";
            myGame._descrption = "This is my game";
            myGame._gameName = "Best game ever";
            myGame._orientation = 0;
            myGame._player = player;
            myGame._level.Add(lvl);
            myGame._level.Add(lvl);

            //Serialization
            Serialization.ExportGame(myGame);
        }
>>>>>>> ae0e5d66b1acb74a0353c82fd19da4af0c4a38a5
    }
}
