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
        private bool            _quit = false;
        private List<IObject>   _objects;

        private UserShipSprite  _player;
        private List<Level>     _levels;

        public Core()
        {
            _name = "nom du jeu";
            _author = "auteur du jeu";
            _description = "blablabla";
            _orientation = 0;
            _x = 600;
            _y = 800;
            // récupération du XML ?
        }

        static void Main()
        {
            Core game = new Core();

            /* Test à effacer */
            /*
            SFML.Graphics.Sprite sprt = new Sprite();
            sprt.Texture = new Texture("ship.png", new SFML.Graphics.IntRect(10, 10, 32, 32));
            */

            UserShip user = new UserShip();
            user._shipSprite = "ship.png";
            UserShipSprite ship = new UserShipSprite(user);


            SFML.Window.VideoMode vmode = new VideoMode(game._y, game._x, 32);
            SFML.Graphics.RenderWindow win = new RenderWindow(vmode, game._name);

            game._objects = new List<IObject>();
            // Set X et Y de la fenêtre (ici random..)
            while (!game._quit)
            {
                ship.update();
                win.Clear();
                win.Draw(ship._shipSprite);
                win.Display();

                game.game_exit();
                
                // 
                //game._objects.Select(item => item.update());
                //game._objects.Select(item => item.show());
            }
        }

        void game_exit()
        {
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Escape))
                this._quit = true;
        }

    }
}
