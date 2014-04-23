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
        public SFML.Graphics.Sprite _weaponSprite { get; set; }
        public int _damage { get; set; }
        public int _fireRate { get; set; }

        public Shot(SFML.Window.Vector2f pos)
        {
            _weaponSprite = new SFML.Graphics.Sprite();

            // _weaponSprite.Texture = new SFML.Graphics.Texture(data._shipSprite, new SFML.Graphics.IntRect(10, 10, 32, 32));
            // _weaponSprite.Texture = new SFML.Graphics.Texture(data._weaponSprite);
            _weaponSprite.Position = pos;
        }

        public void show(SFML.Graphics.RenderWindow window)
        {
        }

        public void update()
        {
        }
    }
}
