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
    public interface IObject
    {
        SFML.Graphics.Sprite _sprite { get; set; } // pour le shot

        void show(SFML.Graphics.RenderWindow w);
        void update(SFML.Graphics.RenderWindow w, orientation o, List<IObject> l, Stopwatch touch, Stopwatch shot);
        bool isEnemy();
    }
}
