using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUpLauncher
{
    public interface Section
    {
        #region Members
        public List<ShootEmUpLauncher.AObject> Objects { set; get; }
        public ShootEmUp.Enumrations.eSection Section { set; get; }
        public ShootEmUp.Enumrations.eType Type { set; get; }

        protected void Display();
        protected void Update();
        #endregion
    }
}
