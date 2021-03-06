﻿using System;
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
        public static void ExportGame(ShootEmUpGame game)
        {
            //Create game folder
            String ExportPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            ExportPath += "\\ShootEmUpMaker\\";
            String GameFolderPath = ExportPath + game._name;
            String GameFilePath = GameFolderPath + "\\" + game._name + ".xml";
            Directory.CreateDirectory(GameFolderPath);

            //Copy ressources to game folder
            try
            {
                Serialization.copyRessources(game);
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }

            //Create xml file in game folder    
            XmlSerializer xs = new XmlSerializer(typeof(ShootEmUpGame));
            using (StreamWriter wr = new StreamWriter(GameFilePath))
            {
                xs.Serialize(wr, game);
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

            ////Copying ressources to folder
            foreach (Level x in myGame._levels)
            {
                //General
                string wallName = Path.GetFileName(x._wallpaper);
                string musicName = Path.GetFileName(x._music);
                //File.Copy(x._wallpaper, CreatedGamePath + "\\general\\" + wallName);
                //    File.Copy(x._music, CreatedGamePath + "\\general\\" + musicName);
                x._wallpaper = wallName;
                x._music = musicName;

            //    //Enemy
                foreach (EnemyShip z in x._enemy)
                {
                    string EshipSprite = Path.GetFileName(z._shipSprite);
                    string EweaponSprite = Path.GetFileName(z._weaponSprite);
                 //   File.Copy(z._shipSprite, CreatedGamePath + "\\enemy\\" + EshipSprite);
                 //   File.Copy(z._weaponSprite, CreatedGamePath + "\\enemy\\" + EweaponSprite);
                    z._shipSprite = EshipSprite;
                    z._weaponSprite = EweaponSprite;
                }
            }

            ////Player
            string UshipSprite = Path.GetFileName(myGame._player._shipSprite);
            string UweaponSprite = Path.GetFileName(myGame._player._weaponSprite);
            //File.Copy(myGame._player._shipSprite, CreatedGamePath + "\\player\\" + UshipSprite);
            //File.Copy(myGame._player._weaponSprite, CreatedGamePath + "\\player\\" + UweaponSprite);
            myGame._player._shipSprite = UshipSprite;
            myGame._player._weaponSprite = UweaponSprite;

            string thumbName = Path.GetFileName(myGame._wallpaper);
            File.Copy(myGame._wallpaper, CreatedGamePath + "\\general\\" + thumbName);
            myGame._wallpaper = thumbName;
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
