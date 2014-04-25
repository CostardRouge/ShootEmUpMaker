using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Timers;

using SFML;
using SFML.Graphics;
using SFML.Window;

namespace ShootEmUpLauncher
{
    class Core
    {
        #region Members
        public Boolean Quit { set; get; }
        public List<Section> Sections { set; get; }
        private List<AObject> Objects { set; get; }
        private ShootEmUpMaker.ShootEmUpGame Game { set; get; }
        private ShootEmUp.Enumrations.eSection CurrentSection { set; get; }

        // SFML Members
        private SFML.Window.VideoMode VideoMode { set; get; }
        private SFML.Graphics.RenderWindow Window { set; get; }

        private Stopwatch _timer;
        private Stopwatch _lastTouch;
        private Stopwatch _lastShot;
        private Sprite _background;
        private UserShipSprite _player;
        #endregion

        #region Methodss
        public Core(string path)
        {
            // Load Game from file path
            this.Game = ShootEmUpMaker.Serialization.ImportGame(path);

            // Inits
            this.Quit = false;
            this.CurrentSection = ShootEmUp.Enumrations.eSection.MAIN_MENU;

            //Sprite text = new Sprite();
            this.VideoMode = new VideoMode(1024, 600, 32);
            this.Window = new RenderWindow(this.VideoMode, this.Game._name);

            // Init events
            this.Window.Closed += new EventHandler(OnClose);
            this.Window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);

            //_lastTouch = new Stopwatch();
            //_lastTouch.Start();

            //_lastShot = new Stopwatch();
            //_lastShot.Start();

            //_timer = new Stopwatch();
            //_timer.Start();
            //_background = new Sprite();
        }

        public void Run()
        {
            while (!this.Quit || this.Window.IsOpen())
            {
                this.Update();
                this.Display();
            }
        }

        public void Update()
        {
            // Update corrects sections
            ShootEmUpLauncher.Section Section = this.Sections.Find(s => s.Section == this.CurrentSection);

            if (Section != null)
                Section.Update();

            // Core Update
            this.Objects.Select(o => o.Update());
        }

        public void Display()
        {
            ShootEmUpLauncher.Section Section = this.Sections.Find(s => s.Section == this.CurrentSection);

            if (Section != null)
                Section.Display();

            // Core Display
            this.Objects.Select(o => o.Display());
        }

        static void Main(string[] args)
        {
            ShootEmUpLauncher.Core Core = new Core(args[0]);
            Core.Run();
          

            EnemyShip enemy = new EnemyShip();
            enemy._shipSprite = "ship.png";

            UserShip user = new UserShip();
            user._fireRate = 1;
            user._life = 3;
            user._shipSprite = "ship.png";
            user._weaponSprite = "ship.png";
            UserShipSprite ship = new UserShipSprite(user);

            game._levels = new List<Level>();

            Level lvl = new Level();

            lvl._wallpaper = "17.png";
            lvl._music = "music.ogg";
            lvl._enemy = new List<EnemyShip>();
            lvl._enemy.Add(enemy);
            lvl._enemy.Add(enemy);
            lvl._enemy.Add(enemy);

            game._levels.Add(lvl);

            game._objects = new List<IObject>();
            game._objects.Add(ship);
                        
            //while ()
            //{
            //    foreach (var item in game._levels)
            //    {
            //        if (game._objects.OfType<UserShipSprite>().Count() == 0)
            //            break;
            //        game.displayLevel(game, window, item);
                    
            //    }
            //    if (game._objects.OfType<UserShipSprite>().Count() > 0)
            //        game.displayText(text, "gamefinished.png", game, window);
            //}
        }

        // Display functions

        void displayLevel(Core game, SFML.Graphics.RenderWindow window, Level item)
        {
            int count = 0;
            Sprite text = new Sprite();
            SFML.Audio.Music music = new SFML.Audio.Music(item._music);

            music.Play();
            game._background.Texture = new SFML.Graphics.Texture(item._wallpaper, new SFML.Graphics.IntRect(0, 0, (int)game._x, (int)game._y));
            game.displayText(text, "start.png", game, window);
            while (item._enemy.Count > count || game._objects.OfType<EnemyShipSprite>().Count() > 0)
            {
                if (game._timer.ElapsedMilliseconds >= 3000 && item._enemy.Count > count)
                {
                    game._objects.Add(new EnemyShipSprite(item._enemy[count++]));
                    game._timer.Restart();
                }
                window.DispatchEvents();
                window.Clear();
                window.Draw(game._background);
                for (var x = 0; x < game._objects.Count; x++)
                {
                    game._objects[x].show(window);
                    game._objects[x].update(window, game._orientation, game._objects, game._lastTouch, game._lastShot);
                }
                if (game._objects.OfType<UserShipSprite>().Count() == 0)
                    return;
                window.Display();
            }
            game.displayText(text, "levelcomplete.png", game, window);
            music.Stop();
        }

        void displayText(Sprite text, string file, Core game, SFML.Graphics.RenderWindow window)
        {
            window.Clear();
            text.Texture = new SFML.Graphics.Texture(file, new SFML.Graphics.IntRect(0, 0, (int)game._x, (int)game._y));
            window.Draw(text);
            window.Display();
            Thread.Sleep(2000);
        }

        // Events Handler functions

        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void OnKeyPressed(object sender, KeyEventArgs key)
        {
            Window window = (Window)sender;
            if (key.Code == Keyboard.Key.Escape)
                window.Close();
        }
    }
    #endregion
}