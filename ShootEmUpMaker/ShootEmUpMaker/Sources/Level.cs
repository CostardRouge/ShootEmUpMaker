using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUpMaker
{
    public class Level
    {
        public int _number { get; set; }
        public string _name { get; set; }
        public string _description { get; set; }

        public string _wallpaper { get; set; }
        public string _music { get; set; }
        public List<EnemyShip> _enemy;

        public Level()
        {
            this._enemy = new List<EnemyShip>();
        }
    }   
}