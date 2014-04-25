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
            string GamePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\ShootEmUpMaker\\";
            Directory.CreateDirectory(GamePath + myGame._name);

            //Copy ressources to game folder
            copyRessources(myGame);

            //Create xml file in game folder    
            XmlSerializer xs = new XmlSerializer(typeof(ShootEmUpGame));
            using (StreamWriter wr = new StreamWriter(GamePath + 
                myGame._name + 
                "\\" +
                myGame._name + ".xml"))
            {
                xs.Serialize(wr, myGame);
            }
        }

        public static void copyRessources(ShootEmUpGame myGame)
        {
            String UserDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ShootEmUpMaker\\";
            String CreatedGamePath = UserDocumentPath + myGame._name + "\\res";

            //Creating ressource folder
            Directory.CreateDirectory(CreatedGamePath);
            Directory.CreateDirectory(CreatedGamePath + "\\general");
            Directory.CreateDirectory(CreatedGamePath + "\\player");
            Directory.CreateDirectory(CreatedGamePath + "\\enemy");

<<<<<<< HEAD
            ////Copying ressources to folder
            //foreach (Level x in myGame._levels)
            //{
            //    //General
            //    string wallName = Path.GetFileName(x._wallpaper);
            //    string musicName = Path.GetFileName(x._music);
            //    File.Copy(x._wallpaper, CreatedGamePath + "\\" + wallName);
            //    File.Copy(x._music, CreatedGamePath + "\\" + musicName);
            //    x._wallpaper = wallName;
            //    x._music = musicName;

            //    //Enemy
            //    foreach (EnemyShip z in x._enemy)
            //    {
            //        string EshipSprite = Path.GetFileName(z._shipSprite);
            //        string EweaponSprite = Path.GetFileName(z._weaponSprite);
            //        File.Copy(x._wallpaper, CreatedGamePath + "\\" + EshipSprite);
            //        File.Copy(x._music, CreatedGamePath + "\\" + EweaponSprite);
            //        z._shipSprite = EshipSprite;
            //        z._weaponSprite = EweaponSprite;
            //    }
            //}

            ////Player
            //string UshipSprite = Path.GetFileName(myGame._player._shipSprite);
            //string UweaponSprite = Path.GetFileName(myGame._player._weaponSprite);
            //File.Copy(myGame._player._shipSprite, CreatedGamePath + "\\" + UshipSprite);
            //File.Copy(myGame._player._weaponSprite, CreatedGamePath + "\\" + UweaponSprite);
            //myGame._player._shipSprite = UshipSprite;
            //myGame._player._weaponSprite = UweaponSprite;
=======
            //Copying ressources to folder
            foreach (Level x in myGame._levels)
            {
                //General
                string wallName = Path.GetFileName(x._wallpaper);
                string musicName = Path.GetFileName(x._music);
                File.Copy(x._wallpaper, CreatedGamePath + "\\" + wallName);
                File.Copy(x._music, CreatedGamePath + "\\" + musicName);
                x._wallpaper = wallName;
                x._music = musicName;

                //Enemy
                foreach (EnemyShip z in x._enemy)
                {
                    string EshipSprite = Path.GetFileName(z._shipSprite);
                    string EweaponSprite = Path.GetFileName(z._weaponSprite);
                    File.Copy(x._wallpaper, CreatedGamePath + "\\" + EshipSprite);
                    File.Copy(x._music, CreatedGamePath + "\\" + EweaponSprite);
                    z._shipSprite = EshipSprite;
                    z._weaponSprite = EweaponSprite;
                }
            }

            //Player
            string UshipSprite = Path.GetFileName(myGame._player._shipSprite);
            string UweaponSprite = Path.GetFileName(myGame._player._weaponSprite);
            File.Copy(myGame._player._shipSprite, CreatedGamePath + "\\" + UshipSprite);
            File.Copy(myGame._player._weaponSprite, CreatedGamePath + "\\" + UweaponSprite);
            myGame._player._shipSprite = UshipSprite;
            myGame._player._weaponSprite = UweaponSprite;
>>>>>>> 42aef0e93ccc0a5a98b0cf03c48874cb090d91c2
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
    }
}
