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
            Directory.CreateDirectory(docPath + "\\ShootEmUpMaker\\" + myGame._name);

            //Create xml file in game folder    
            XmlSerializer xs = new XmlSerializer(typeof(ShootEmUpGame));
            using (StreamWriter wr = new StreamWriter(docPath +
                "\\ShootEmUpMaker\\" + 
                myGame._name + 
                "\\" +
                myGame._name + ".xml"))
            {
                xs.Serialize(wr, myGame);
            }
        }

        public static ShootEmUpGame ImportGame(string path)
        {
            ShootEmUpGame myGame = new ShootEmUpGame();
            XmlSerializer xs = new XmlSerializer(typeof(ShootEmUpGame));
            using (StreamReader tr = new StreamReader(path))
            {
                try
                {
                    myGame = (ShootEmUpGame)xs.Deserialize(tr);
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.ToString());  
                }
            }
            return myGame;
        }

        //public static List<Media> readMediaList(string path)
        //{
        //    List<Media> ret;
        //    XmlSerializer reader = new XmlSerializer(typeof(List<Media>));

        //    ret = new List<Media>();
        //    using (StreamReader file = new StreamReader(path))
        //    {
        //        ret = (List<Media>)reader.Deserialize(file);
        //    }
        //    return (ret);
        //}

        //public static void writeMediaList(string path, object medias)
        //{
        //    XmlSerializer writer = new XmlSerializer(medias.GetType());

        //    using (StreamWriter file = new StreamWriter(path))
        //    {
        //        writer.Serialize(file, medias);
        //    }
        //}
        //#endregion Serialization
    }
}
