using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUpLauncher
{
    public interface IObject
    {
        void show(SFML.Graphics.RenderWindow window);
        void update();
    }
}
