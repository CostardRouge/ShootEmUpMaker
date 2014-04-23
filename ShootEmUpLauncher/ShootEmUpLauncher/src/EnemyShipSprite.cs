using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUpLauncher
{
    class EnemyShipSprite : IObject
    {
        EnemyShip _enemyShipData;
        public SFML.Graphics.Sprite _shipSprite { get; set; }
        public SFML.Graphics.Sprite _weaponSprite { get; set; }
        public orientation _orientation;

        public EnemyShipSprite(EnemyShip data, orientation orientation)
        {
            _shipSprite = new SFML.Graphics.Sprite();
            _enemyShipData = data;

            _shipSprite.Texture = new SFML.Graphics.Texture(data._shipSprite, new SFML.Graphics.IntRect(10, 10, 32, 32));
            // _weaponSprite.Texture = new SFML.Graphics.Texture(data._weaponSprite);
            _shipSprite.Position = new SFML.Window.Vector2f(50, 50);
        }


        public void show(SFML.Graphics.RenderWindow window)
        {
            window.Draw(_shipSprite);
            // window.Draw(_weaponSprite);
        }

        public void update()
        {
            // ajout de timer & collision
            if (_orientation == orientation.vertical)
                _shipSprite.Position = new SFML.Window.Vector2f(_shipSprite.Position.X, _shipSprite.Position.Y + 0.05f);
            else if (_orientation == orientation.horizontal)
                _shipSprite.Position = new SFML.Window.Vector2f(_shipSprite.Position.X + 0.05f, _shipSprite.Position.Y);
        }
    }
}
