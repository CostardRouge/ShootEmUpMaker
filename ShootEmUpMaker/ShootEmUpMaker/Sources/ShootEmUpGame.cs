using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUpMaker
{
    public class ShootEmUpGame
    {
        public string _gameName { get; set; }
        public string _author { get; set; }
        public string _descrption { get; set; }
        public enum E_orientation
        {
            Horizontal = 0,
            Vertical = 1
        };
        public UserShip _player { get; set; }
        public List<Level> _level { get; set; }
        public E_orientation _orientation { get; set; }

        public ShootEmUpGame()
        {
            this._level = new List<Level>();
        }
    }
}
