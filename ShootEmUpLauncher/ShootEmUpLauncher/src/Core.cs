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
        private string      _name = "abc";
        private string      _author = "auteur";
        private string      _description = "blablabla";
        private int         _orientation = 0;
        private UserShip    _player;
        private List<Level> _levels;

        static void Main()
        {
            // Récupérer données du jeu
            Core game = new Core();
            // Set X et Y de la fenêtre (ici random..)
            uint x = 600;
            uint y = 800;

            if (game._orientation == 0) // 0 = Vertical
            {
                x = 500;
                y = 800;
            }

            SFML.Window.Window window = new SFML.Window.Window(new VideoMode(y, x), game._name);

        }
    }
}
