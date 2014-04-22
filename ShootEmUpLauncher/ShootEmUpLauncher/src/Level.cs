using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUpLauncher
{
    class Level
    {
        string _wallpaper { get; set; }
        string _music { get; set; }
        UserShip _player;
        List<EnemyShip> _enemy;
    }
}
