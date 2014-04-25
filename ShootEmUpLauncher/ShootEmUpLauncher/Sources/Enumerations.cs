using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp.Enumrations
{
    #region Type definitions
    public enum eType
    {
        TEXT,
        MENU,
        IMAGE,
        ENEMY,
        BULLET,
        PLAYER,
        MISSILE,
        LEVEL = 256
    };

    public enum eSection
    {
        MAIN_MENU,
        PAUSE_MENU,
        LEVEL_SECTION
    };

    public enum eOrientation
    {
        VERTICAL,
        HORIZONTAL
    };

    public enum eDirection
    {
        UP,
        LEFT,
        DOWN,
        RIGHT
    };
    #endregion
}
