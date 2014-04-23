using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShootEmUpMaker
{
    public static class Serialization
    {
        public static void SerializeClass(ShootEmUpGame myGame)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ShootEmUpGame));
            using (StreamWriter wr = new StreamWriter("MyGame.xml"))
            {
                xs.Serialize(wr, myGame);
            }
        }
    }
}
