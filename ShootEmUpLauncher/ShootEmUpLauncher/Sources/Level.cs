using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUpLauncher
{
    class Level
    {
        public string _wallpaper { get; set; }
        public string _music { get; set; }
        public UserShip _player;
        public List<EnemyShip> _enemy;
    }

}
