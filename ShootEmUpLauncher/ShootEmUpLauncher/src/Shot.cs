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
        public SFML.Graphics.Sprite _sprite { get; set; }
        public int _damage { get; set; }
        public int _fireRate { get; set; }

        public Shot(SFML.Window.Vector2f pos, string sprite, int dmg, int fireRate)
        {
            _damage = dmg;
            _fireRate = fireRate;
            _sprite = new SFML.Graphics.Sprite();
            _sprite.Texture = new SFML.Graphics.Texture(sprite, new SFML.Graphics.IntRect(10, 10, 5, 5));
            _sprite.Position = new SFML.Window.Vector2f(pos.X + 15, pos.Y + 32);
        }

        public void show(SFML.Graphics.RenderWindow window)
        {
            window.Draw(_sprite);
        }

        public List<IObject> update(SFML.Graphics.RenderWindow window, orientation orientation, List<IObject> list)
        {
            // fixer problème de lenteur (thread ?)
            // ajout timer
            if (orientation == orientation.vertical)
                _sprite.Position = new SFML.Window.Vector2f(_sprite.Position.X, _sprite.Position.Y + 0.05f + ( _fireRate /10));
            else if (orientation == orientation.horizontal)
                _sprite.Position = new SFML.Window.Vector2f(_sprite.Position.X + 0.05f + (_fireRate / 10), _sprite.Position.Y);
            for (var x = 0; x < list.Count; x++)
                {
                    if (list[x].isEnemy())
                    {
                        if ((orientation == orientation.vertical && list[x]._sprite.Position.Y > _sprite.Position.Y)
                            || (orientation == orientation.horizontal && list[x]._sprite.Position.X > _sprite.Position.X))
                        {
                            list.RemoveAt(x);
                        }
                    }
                }
            return list;
        }

        public bool isEnemy()
        {
            return false;
        }
    }
}
