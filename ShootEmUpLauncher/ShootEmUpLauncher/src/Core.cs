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
    class Core
    {
        private string          _name;
        private string          _author;
        private string          _description;
        private int             _orientation;
        private uint            _x;
        private uint            _y;
        private List<IObject>   _objects;

        private UserShipSprite  _player;
        private List<Level>     _levels;

        public Core()
        {
            // récupération du XML ?
            _name = "nom du jeu";
            _author = "auteur du jeu";
            _description = "blablabla";
            _orientation = 0;
            _x = 600;
            _y = 800;
        }

        static void Main()
        {
            Core game = new Core();
            SFML.Window.VideoMode vmode = new VideoMode(game._x, game._y, 32);
            SFML.Graphics.RenderWindow window = new RenderWindow(vmode, game._name);

            window.Closed += new EventHandler(OnClose);
            window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            /* Test à effacer */
            UserShip user = new UserShip();
            user._shipSprite = "ship.png";
            UserShipSprite ship = new UserShipSprite(user);
            /**/
            
            game._objects = new List<IObject>();

            while (window.IsOpen())
            {
                window.DispatchEvents();

                ship.update();

                window.Clear();
                window.Draw(ship._shipSprite);
                window.Display();
                // 
                //game._objects.Select(item => item.update());
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
