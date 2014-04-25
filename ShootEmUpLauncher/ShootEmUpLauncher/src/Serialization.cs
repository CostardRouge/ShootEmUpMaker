using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUpLauncher
{
    public static class Serialization
    {
        public static ShootEmUpGame ImportGame(string path)
        {
            ShootEmUpGame myGame;
            XmlSerializer xs = new XmlSerializer(typeof(ShootEmUpGame));
            using (TextReader tr = new StringReader(path))
            {
                myGame = (ShootEmUpGame)xs.Deserialize(tr);
            }
            return myGame;
        }
    }
}
