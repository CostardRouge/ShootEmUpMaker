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
    class Shot : IObject
    {
        public bool _appartenance { get; set; } // si true joueur, si false
        public string _weaponSprite { get; set; }
        public int _damage { get; set; }
        public int _fireRate { get; set; }

        public Shot(int appartenance, SFML.Window.Vector2f pos)
        {
            
        }

        public void show(SFML.Graphics.RenderWindow window)
        {
        }

        public void update()
        {
        }
    }
}
