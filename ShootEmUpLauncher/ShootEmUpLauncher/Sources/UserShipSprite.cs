﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ShootEmUpLauncher
{
    class UserShipDrawable : AObject
    {
        ShootEmUpMaker.UserShip _userShipData;
        public int _life { get; set; }
        public SFML.Graphics.Sprite _sprite { get; set; }

        public UserShipDrawable(UserShip data)
        {
            _sprite = new SFML.Graphics.Sprite();
            _userShipData = data;
            _life = data._life;
            _sprite.Texture = new SFML.Graphics.Texture(data._shipSprite, new SFML.Graphics.IntRect(10, 10, 32, 32));
            _sprite.Position = new SFML.Window.Vector2f(50, 50);
        }

        public void Show(SFML.Graphics.RenderWindow window)
        {
            window.Draw(_sprite);
        }

        public void Update(SFML.Graphics.RenderWindow window, orientation orientation, List<IObject> list, Stopwatch touch, Stopwatch shot)
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
                if (touch.ElapsedMilliseconds >= 200)
                {
                    list.Add(new Shot(_sprite.Position, _userShipData._weaponSprite, _userShipData._damage, _userShipData._fireRate));
                    touch.Restart();
                }
            }

            for (var x = 0; x < list.Count; x++)
            {
                if (list[x].isEnemy())
                {
                    if (list[x]._sprite.Position.X <= _sprite.Position.X
                    && _sprite.Position.X <= list[x]._sprite.Position.X + 32
                    && list[x]._sprite.Position.Y <= _sprite.Position.Y
                    && _sprite.Position.Y <= list[x]._sprite.Position.Y + 32)
                    {
                        if (shot.ElapsedMilliseconds >= 200)
                        {
                            _life--;
                            if (_life <= 0)
                                list.Remove(this);
                            shot.Restart();
                        }
                    }  
                }
            }
        }

        public bool isEnemy()
        {
            return false;
        }
    }
}
