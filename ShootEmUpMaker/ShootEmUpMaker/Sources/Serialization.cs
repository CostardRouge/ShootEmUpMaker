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
            Directory.CreateDirectory(docPath + "\\ShootEmUpMaker\\" + myGame.Name);

            //Create xml file in game folder    
            XmlSerializer xs = new XmlSerializer(typeof(ShootEmUpGame));
            using (StreamWriter wr = new StreamWriter(docPath +
                "\\ShootEmUpMaker\\" + 
                myGame.Name + 
                "\\" +
                myGame.Name + ".xml"))
            {
                xs.Serialize(wr, myGame);
            }
        }

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
