using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUpMaker
{
    public class ShootEmUpGame
    {
        public string Name { get; set; }
        public string _author { get; set; }
        public string _description { get; set; }
        public string _wallpaper { get; set; }

        public UserShip _player { get; set; }
        public List<Level> _levels { get; set; }
        public ShootEmUp.Enumrations.eOrientation _orientation { get; set; }

        public ShootEmUpGame()
        {
            this._levels = new List<Level>();
        }

        public string _name { get; set; }
    }
}
