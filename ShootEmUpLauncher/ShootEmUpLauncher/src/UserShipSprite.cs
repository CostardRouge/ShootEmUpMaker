using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ShootEmUpLauncher
{
    class UserShipSprite : IObject
    {
        UserShip _userShipData;
        public int _life { get; set; }
        public SFML.Graphics.Sprite _sprite { get; set; }

        public UserShipSprite(UserShip data)
        {
            _sprite = new SFML.Graphics.Sprite();
            _userShipData = data;
            _life = data._life;
            _sprite.Texture = new SFML.Graphics.Texture(data._shipSprite, new SFML.Graphics.IntRect(10, 10, 32, 32));
            _sprite.Position = new SFML.Window.Vector2f(50, 50);
        }


        public void show(SFML.Graphics.RenderWindow window)
        {
            window.Draw(_sprite);
        }

        public void update(SFML.Graphics.RenderWindow window, orientation orientation, List<IObject> list, Stopwatch t)
        {
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Left) && (_sprite.Position.X - 0.1f > 0))
                _sprite.Position = new SFML.Window.Vector2f(_sprite.Position.X - 0.1f, _sprite.Position.Y);
            else if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Right) && (_sprite.Position.X + 0.1f < window.Size.X - 32)) // !!! Moins la taille du sprite
                _sprite.Position = new SFML.Window.Vector2f(_sprite.Position.X + 0.1f, _sprite.Position.Y);
            else if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Up) && (_sprite.Position.Y - 0.1f > 0))
                _sprite.Position = new SFML.Window.Vector2f(_sprite.Position.X, _sprite.Position.Y - 0.1f);
            else if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Down) && (_sprite.Position.Y + 0.1f < window.Size.Y - 32))
                _sprite.Position = new SFML.Window.Vector2f(_sprite.Position.X, _sprite.Position.Y + 0.1f);
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Space))
            {
                if (t.ElapsedMilliseconds >= 200)
                {
                    list.Add(new Shot(_sprite.Position, _userShipData._weaponSprite, _userShipData._damage, _userShipData._fireRate));
                    t.Restart();
                }

            }
        }

        public bool isEnemy()
        {
            return false;
        }
    }
}
