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
        static void Main()
        {
            SFML.Window.Window window = new SFML.Window.Window(new VideoMode(800, 600), "ABCD");
        }
    }
}
