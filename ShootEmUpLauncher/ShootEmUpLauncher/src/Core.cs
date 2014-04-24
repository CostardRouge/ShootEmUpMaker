using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Timers;

using SFML;
using SFML.Graphics;
using SFML.Window;

namespace ShootEmUpLauncher
{
    public enum orientation {vertical, horizontal};

    class Core
    {
        private Stopwatch       _timer;
        private Stopwatch       _stopWatch;
        private string          _name;
        private string          _author;
        private string          _description;
        private uint            _x;
        private uint            _y;

        public orientation _orientation { get; set; }
        public List<IObject>   _objects { get; set; }

        private UserShipSprite  _player;
        private List<Level>     _levels;

        public Core(string path)
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();

            _timer = new Stopwatch();
            _timer.Start();
            // récupération du XML ?
            // vérification de l'existence des fichiers
            _name = "nom du jeu";
            _author = "auteur du jeu";
            _description = "blablabla";
            _orientation = orientation.vertical;
            if (_orientation == orientation.vertical)
            {
                _x = 600;
                _y = 800;
            }
            else
            {
                _x = 800;
                _y = 600;
            }
        }

        static void Main() // string[] args
        {
            int count = 0;
            Sprite background = new Sprite();
            Core game = new Core("toto");
            Sprite text = new Sprite();
            SFML.Window.VideoMode vmode = new VideoMode(game._x, game._y, 32);
            SFML.Graphics.RenderWindow window = new RenderWindow(vmode, game._name);

            window.Closed += new EventHandler(OnClose);
            window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);

            /* Test à effacer */
            EnemyShip enemy = new EnemyShip();
            enemy._shipSprite = "ship.png";
           // EnemyShipSprite enship = new EnemyShipSprite(enemy);

            UserShip user = new UserShip();
            user._fireRate = 1;
            user._shipSprite = "ship.png";
            user._weaponSprite = "ship.png";
            UserShipSprite ship = new UserShipSprite(user);

            game._levels = new List<Level>();

            Level lvl = new Level();

            lvl._wallpaper = "17.png";
            lvl._music = "wot.mp3";
            lvl._enemy = new List<EnemyShip>();
            lvl._enemy.Add(enemy);
            lvl._enemy.Add(enemy);
            lvl._enemy.Add(enemy);

            game._levels.Add(lvl);

            game._objects = new List<IObject>();
            game._objects.Add(ship);
            /**/
                        
            while (window.IsOpen())
            {
                foreach (var item in game._levels)
                {
                    /* Si quelqu'un arrive à lancer un fichier musique o.o'
                    SFML.Audio.Music music = new SFML.Audio.Music(item._music);
                    music.Play();
                    */
                    background.Texture = new SFML.Graphics.Texture(item._wallpaper, new SFML.Graphics.IntRect(0, 0, (int)game._x, (int)game._y));
                    background.Position = new SFML.Window.Vector2f(0, 0);
                    game.displayText(text, "start.png", game, window);
                    while (item._enemy.Count > count || game._objects.OfType<EnemyShipSprite>().Count() > 0)
                    {
                        if (game._timer.ElapsedMilliseconds >= 3000 && item._enemy.Count > count)
                        {
                            game._objects.Add(new EnemyShipSprite(item._enemy[count]));
                            game._timer.Restart();
                            count++;
                        }
                        window.DispatchEvents();
                        window.Clear();
                        window.Draw(background);
                        for (var x = 0; x < game._objects.Count; x++)
                        {
                            game._objects[x].show(window);
                            game._objects[x].update(window, game._orientation, game._objects, game._stopWatch);
                        }
                        window.Display();
                    }
                    game.displayText(text, "levelcomplete.png", game, window);
                }
                game.displayText(text, "gamefinished.png", game, window);
            }
        }

        void displayText(Sprite text, string file, Core game, SFML.Graphics.RenderWindow window)
        {
            window.Clear();
            text.Texture = new SFML.Graphics.Texture(file, new SFML.Graphics.IntRect(0, 0, (int)game._x, (int)game._y));
            if (game._orientation == orientation.vertical)
                text.Position = new SFML.Window.Vector2f(0, (int)game._y / 2); // bon positionnement du text
            else
                text.Position = new SFML.Window.Vector2f((int)game._x / 2, 0);
            window.Draw(text);
            window.Display();
            Thread.Sleep(2000);
        }

        // Events Handler

        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void OnKeyPressed(object sender, KeyEventArgs key)
        {
            Window window = (Window)sender;
            if (key.Code == Keyboard.Key.Escape)
                window.Close();
        }
    }
}
