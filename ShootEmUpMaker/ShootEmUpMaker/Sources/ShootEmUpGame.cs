using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ShootEmUpMaker
{
    public class ShootEmUpGame
    {
        public string Name { get; set; }
        public string _author { get; set; }
        public string _description { get; set; }
        public string _wallpaper { get; set; }
        public enum E_orientation
        {
            Horizontal = 0,
            Vertical = 1
        };
        public UserShip _player { get; set; }
        public List<Level> _levels { get; set; }
        public E_orientation _orientation { get; set; }

        public ShootEmUpGame()
        {
            this._levels = new List<Level>();
            this._player = new UserShip();
        }

        public string _name { get; set; }
    }
}
