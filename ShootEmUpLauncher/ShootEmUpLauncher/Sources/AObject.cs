using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;

namespace ShootEmUpLauncher
{
    public interface AObject
    {
        #region Methods
        protected void  Show(RenderWindow w);
        protected void  Update(RenderWindow w, Stopwatch touch, Stopwatch shot);
        #endregion

        #region Members
        public List<Section> Sections { set; get; }
        public List<AObject> Objects { set; get; }
        public SFML.Graphics.Sprite Sprite { get; set; }
        public ShootEmUp.Enumrations.eType Types { set; get; }
        public ShootEmUp.Enumrations.eOrientation Orientation { set; get; }
        #endregion
    }
}
