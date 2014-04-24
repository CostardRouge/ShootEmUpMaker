using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using SFML;
using SFML.Graphics;
using SFML.Window;

namespace ShootEmUpLauncher
{
    public enum orientation {vertical, horizontal};

    class Core
    {
        private Stopwatch       _timer;
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
            _timer = new Stopwatch();
            _timer.Start();

            // récupération du XML ?
            _name = "nom du jeu";
            _author = "auteur du jeu";
            _description = "blablabla";
            _orientation = orientation.vertical;
            _x = 600;
            _y = 800;
        }

        static void Main() // string[] args
        {
            Core game = new Core("toto");
            SFML.Window.VideoMode vmode = new VideoMode(game._x, game._y, 32);
            SFML.Graphics.RenderWindow window = new RenderWindow(vmode, game._name);
            

            window.Closed += new EventHandler(OnClose);
            window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);

            /* Test à effacer */
            EnemyShip enemy = new EnemyShip();
            enemy._shipSprite = "ship.png";
            EnemyShipSprite enship = new EnemyShipSprite(enemy);

            UserShip user = new UserShip();
            user._fireRate = 1;
            user._shipSprite = "ship.png";
            user._weaponSprite = "ship.png";
            UserShipSprite ship = new UserShipSprite(user);
            /**/
            
            game._objects = new List<IObject>();
            game._objects.Add(enship);
            game._objects.Add(ship);

            while (window.IsOpen())
            {
                window.DispatchEvents();
                window.Clear();
                for (var x = 0; x < game._objects.Count; x++)
                {
                    game._objects[x].show(window);
                    game._objects[x].update(window, game._orientation, game._objects, game._timer);
                }
                window.Display();
            }
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
