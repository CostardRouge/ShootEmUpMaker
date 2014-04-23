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
    public interface IObject
    {
        SFML.Graphics.Sprite _sprite { get; set; } // pour le shot

        void show(SFML.Graphics.RenderWindow window);
        List<IObject> update(SFML.Graphics.RenderWindow window, orientation orientation, List<IObject> list);
        bool isEnemy();
    }
}
