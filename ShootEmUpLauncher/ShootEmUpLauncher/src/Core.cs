using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Graphics;
using SFML.Window;

namespace ShootEmUpLauncher
{
    public enum orientation {vertical, horizontal};

    class Core
    {
        private string          _name;
        private string          _author;
        private string          _description;
        private orientation     _orientation;
        private uint            _x;
        private uint            _y;
        private List<IObject>   _objects;

        private UserShipSprite  _player;
        private List<Level>     _levels;

        public Core(string path)
        {
            // récupération du XML ?
            _name = "nom du jeu";
            _author = "auteur du jeu";
            _description = "blablabla";
            _orientation = 0;
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
            EnemyShipSprite enship = new EnemyShipSprite(enemy, game._orientation);

            UserShip user = new UserShip();
            user._shipSprite = "ship.png";
            UserShipSprite ship = new UserShipSprite(user, game._orientation);
            /**/
            
            game._objects = new List<IObject>();

            while (window.IsOpen())
            {
                window.DispatchEvents();

                ship.update();
                enship.update();

                window.Clear();
                window.Draw(ship._shipSprite);
                window.Draw(enship._shipSprite);
                window.Display();
                // 
                //game._objects.Select(item => item.update(_orientation));
                //game._objects.Select(item => item.show(window));
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
