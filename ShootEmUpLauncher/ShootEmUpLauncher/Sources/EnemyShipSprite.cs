﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ShootEmUpLauncher
{
    class EnemyShipSprite : IObject
    {
        EnemyShip _enemyShipData;
        public SFML.Graphics.Sprite _sprite { get; set; }

        public EnemyShipSprite(EnemyShip data)
        {
            _sprite = new SFML.Graphics.Sprite();
            _enemyShipData = data;

            _sprite.Texture = new SFML.Graphics.Texture(data._shipSprite, new SFML.Graphics.IntRect(10, 10, 32, 32));
            _sprite.Position = new SFML.Window.Vector2f(100, 0);
        }

        public void show(SFML.Graphics.RenderWindow window)
        {
            window.Draw(_sprite);
        }

        public void update(SFML.Graphics.RenderWindow window, orientation orientation, List<IObject> list, Stopwatch touch, Stopwatch shot)
        {
            if (orientation == orientation.vertical)
                _sprite.Position = new SFML.Window.Vector2f(_sprite.Position.X, _sprite.Position.Y + 0.03f);
            else if (orientation == orientation.horizontal)
                _sprite.Position = new SFML.Window.Vector2f(_sprite.Position.X + 0.03f, _sprite.Position.Y);
            
            if (_sprite.Position.X > window.Size.X || _sprite.Position.Y > window.Size.Y)
                list.Remove(this);
 
        }

        public bool isEnemy()
        {
            return true;
        }
    }
}
