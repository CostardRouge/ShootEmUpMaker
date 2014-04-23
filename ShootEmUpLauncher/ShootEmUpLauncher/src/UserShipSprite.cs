using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUpLauncher
{
    class UserShipSprite : IObject
    {
        UserShip _userShipData;
        public int _life { get; set; }
        public SFML.Graphics.Sprite _shipSprite { get; set; }
        public SFML.Graphics.Sprite _weaponSprite { get; set; }

        public UserShipSprite(UserShip data)
        {
            _shipSprite = new SFML.Graphics.Sprite();
            _userShipData = data;
            _life = data._life;

            _shipSprite.Texture = new SFML.Graphics.Texture(data._shipSprite, new SFML.Graphics.IntRect(10, 10, 32, 32));
            // _weaponSprite.Texture = new SFML.Graphics.Texture(data._weaponSprite);
            _shipSprite.Position = new SFML.Window.Vector2f(50, 50);
        }


        public void show()
        {

        }

        public void update()
        {
            // Check que ça ne dépasse pas la fenêtre et vérifier la valeur de déplacement
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Left))
                _shipSprite.Position = new SFML.Window.Vector2f(_shipSprite.Position.X - 10, _shipSprite.Position.Y);
            else if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Right))
                _shipSprite.Position = new SFML.Window.Vector2f(_shipSprite.Position.X + 10, _shipSprite.Position.Y);
            else if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Up))
                _shipSprite.Position = new SFML.Window.Vector2f(_shipSprite.Position.X, _shipSprite.Position.Y + 10);
            else if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Down))
                _shipSprite.Position = new SFML.Window.Vector2f(_shipSprite.Position.X, _shipSprite.Position.Y - 10);
            else if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Space))
            {
                // shot ? Création d'un objet de tir et thread ?
            }
        }
    }
}
