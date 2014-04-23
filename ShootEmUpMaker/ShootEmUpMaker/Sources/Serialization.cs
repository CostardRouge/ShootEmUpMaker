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
        public static void ExportGame(ShootEmUpGame myGame)
        {
            //Create game folder
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            Directory.CreateDirectory(docPath + "\\ShootEmUpMaker\\" + myGame._gameName);

            //Create xml file in game folder    
            XmlSerializer xs = new XmlSerializer(typeof(ShootEmUpGame));
            using (StreamWriter wr = new StreamWriter(docPath +
                "\\ShootEmUpMaker\\" + 
                myGame._gameName + 
                "\\" +
                myGame._gameName + ".xml"))
            {
                xs.Serialize(wr, myGame);
            }
        }
    }
}
