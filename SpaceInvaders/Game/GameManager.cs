using System;

namespace SpaceInvaders
{
    class GameManager
    {
        private GameManager()
        {
        }

        ~GameManager()
        {
        }

        private static GameManager getInstance()
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }

        // launch main systems
        public static void start()
        {
            TextMan.create(2);
            ImgMan.create(22);
            SBatchMan.create(5);
            SpriteMan.create(14);
            GObjMan.create(7);
            TimerMan.create();
            AnimationMan.create(3);
            ColMan.create(12);
            ProjectileMan.create();
            SoundMan.create();
        }

        // load all content
        public static void load()
        {
            GameManager pGame = GameManager.getInstance();

            pGame.loadImages();

            pGame.loadSprites();

            pGame.buildObjects();

            pGame.loadCollisions();

            pGame.loadTimeEvents();
        }

        // main game update loop 
        public static void update(float totalTime)
        {
            TimerMan.update(totalTime);
            ColMan.update();
            GObjMan.update();
        }

        // free all resources
        public static void close()
        {
            ImgMan.printStats();
            ImgMan.destroy();
            TextMan.printStats();
            TextMan.destroy();
            SBatchMan.printStats();
            SBatchMan.destroy();
            GObjMan.printStats();
            GObjMan.destroy();
            SpriteMan.printStats();
            SpriteMan.destroy();
            TimerMan.printStats();
            TimerMan.destroy();
            AnimationMan.printStats();
            AnimationMan.destroy();
            ColMan.printStats();
            ColMan.destroy();
            ProjectileMan.printStats();
            ProjectileMan.destroy();
            SoundMan.printStats();
            SoundMan.destroy();

            instance = null;
        }

        
        //------------------------
        // system-specific loaders
        //------------------------
        private void loadImages()
        {
            TextMan.add(Texture.Name.ArcadeQuality, "ArcadeQuality.tga");
            TextMan.add(Texture.Name.Explosions, "Explosions.tga");

            ImgMan.add(Image.Name.Crab_0, Texture.Name.ArcadeQuality, 196, 0, 44, 32);
            ImgMan.add(Image.Name.Crab_1, Texture.Name.ArcadeQuality, 252, 0, 44, 32);
            ImgMan.add(Image.Name.Squid_0, Texture.Name.ArcadeQuality, 356, 0, 32, 32);
            ImgMan.add(Image.Name.Squid_1, Texture.Name.ArcadeQuality, 308, 0, 32, 32);
            ImgMan.add(Image.Name.Octopus_0, Texture.Name.ArcadeQuality, 76, 0, 48, 32);
            ImgMan.add(Image.Name.Octopus_1, Texture.Name.ArcadeQuality, 136, 0, 48, 32);
            ImgMan.add(Image.Name.Ship_Base, Texture.Name.ArcadeQuality, 136, 72, 52, 20);
            ImgMan.add(Image.Name.Ship_Blaster, Texture.Name.ArcadeQuality, 156, 60, 12, 32);
            ImgMan.add(Image.Name.Ship_Explosion_0, Texture.Name.ArcadeQuality, 204, 60, 60, 32);
            ImgMan.add(Image.Name.Ship_Explosion_1, Texture.Name.ArcadeQuality, 268, 60, 64, 32);
            ImgMan.add(Image.Name.Missile, Texture.Name.ArcadeQuality, 116, 72, 4, 16);
            ImgMan.add(Image.Name.UFO, Texture.Name.ArcadeQuality, 0, 4, 64, 28);
            ImgMan.add(Image.Name.Shield_Block, Texture.Name.ArcadeQuality, 16, 104, 8, 8);
            ImgMan.add(Image.Name.Shield_Corner, Texture.Name.ArcadeQuality, 72, 96, 8, 8);
            ImgMan.add(Image.Name.Shield_SmallBlock, Texture.Name.ArcadeQuality, 16, 104, 4, 4);
            ImgMan.add(Image.Name.BombA_0, Texture.Name.ArcadeQuality, 352, 68, 12, 24);
            ImgMan.add(Image.Name.BombA_1, Texture.Name.ArcadeQuality, 368, 68, 12, 24);
            ImgMan.add(Image.Name.BombB_0, Texture.Name.ArcadeQuality, 392, 64, 12, 28);
            ImgMan.add(Image.Name.BombC_0, Texture.Name.ArcadeQuality, 428, 64, 12, 28);
            ImgMan.add(Image.Name.BombC_1, Texture.Name.ArcadeQuality, 444, 64, 4, 28);

            ImgMan.add(Image.Name.Projectile_vs_Wall, Texture.Name.Explosions, 2, 2, 32, 32);
            ImgMan.add(Image.Name.Bomb_vs_Missile, Texture.Name.Explosions, 36, 0, 24, 32);

        }

        private void loadSprites()
        {
            SpriteMan.add(BSprite.Name.Squid, ImgMan.find(Image.Name.Squid_0), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Crab, ImgMan.find(Image.Name.Crab_0), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Octopus, ImgMan.find(Image.Name.Octopus_0), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Ship_Base, ImgMan.find(Image.Name.Ship_Base), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Ship_Blaster, ImgMan.find(Image.Name.Ship_Blaster), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Missile, ImgMan.find(Image.Name.Missile), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.BombA, ImgMan.find(Image.Name.BombA_0), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.BombB, ImgMan.find(Image.Name.BombB_0), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.BombC, ImgMan.find(Image.Name.BombC_0), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.UFO, ImgMan.find(Image.Name.UFO), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Shield_Block, ImgMan.find(Image.Name.Shield_Block), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Shield_UpperRight, ImgMan.find(Image.Name.Shield_Corner), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Shield_UpperLeft, ImgMan.find(Image.Name.Shield_Corner), 0.0f, 0.0f, -1.0f);
            SpriteMan.add(BSprite.Name.Shield_SmallBlock, ImgMan.find(Image.Name.Shield_SmallBlock), 0.0f, 0.0f);
            
            SBatchMan.add(SpriteBatch.Name.Projectiles);
            SBatchMan.add(SpriteBatch.Name.Aliens);
            SBatchMan.add(SpriteBatch.Name.Midground);
            SBatchMan.add(SpriteBatch.Name.Collision);
            SBatchMan.add(SpriteBatch.Name.Background);
        }

        private void loadTimeEvents()
        {

            AnimationEvent crab = AnimationMan.add(AnimationEvent.Name.Crab_Animation, true,
                                               GObjMan.find(GameObj.Type._Alien, GameObj.Name.AlienRoot), 8.0f, -9.0f);
            AnimationEvent squid = AnimationMan.add(AnimationEvent.Name.Squid_Animation, true,
                                                GObjMan.find(GameObj.Type._Alien, GameObj.Name.AlienRoot), 8.0f, -9.0f);
            AnimationEvent octopus = AnimationMan.add(AnimationEvent.Name.Octopus_Animation, true,
                                                  GObjMan.find(GameObj.Type._Alien, GameObj.Name.AlienRoot), 8.0f, -9.0f);


            crab.attach(Image.Name.Crab_1);
            crab.attach(Image.Name.Crab_0);
            squid.attach(Image.Name.Squid_1);
            squid.attach(Image.Name.Squid_0);
            octopus.attach(Image.Name.Octopus_1);
            octopus.attach(Image.Name.Octopus_0);

            TimerMan.add(Timer.Name.AlienAnimationTimer, crab, Constants.ALIEN_START_RATE);
            TimerMan.add(Timer.Name.AlienAnimationTimer, squid, Constants.ALIEN_START_RATE);
            TimerMan.add(Timer.Name.AlienAnimationTimer, octopus, Constants.ALIEN_START_RATE);
        }

        private void loadCollisions()
        {
            ColPair tmp;

            tmp = ColMan.add(ColPair.Name.Alien_Missile,
                             GObjMan.find(GameObj.Type._Alien, GameObj.Name.AlienRoot),
                             GObjMan.find(GameObj.Type._Missile, GameObj.Name.MissileRoot));
            tmp.sub.attach(new DestroyMissileObserver());
            tmp.sub.attach(new DestroyAlienObserver());
            
            tmp = ColMan.add(ColPair.Name.Alien_Wall,
                             GObjMan.find(GameObj.Type._Alien, GameObj.Name.AlienRoot),
                             GObjMan.find(GameObj.Type._Wall, GameObj.Name.WallRoot));
            tmp.sub.attach(new A_W_Observer());

            tmp = ColMan.add(ColPair.Name.Missile_Wall,
                             GObjMan.find(GameObj.Type._Missile, GameObj.Name.MissileRoot),
                             GObjMan.find(GameObj.Type._Wall, GameObj.Name.WallRoot));
            tmp.sub.attach(new M_W_Observer());
            tmp.sub.attach(new DestroyMissileObserver());

            tmp = ColMan.add(ColPair.Name.Alien_Shield,
                             GObjMan.find(GameObj.Type._Alien, GameObj.Name.AlienRoot),
                             GObjMan.find(GameObj.Type._Shield, GameObj.Name.ShieldRoot));
            tmp.sub.attach(new A_S_Observer());

            tmp = ColMan.add(ColPair.Name.Alien_Player,
                             GObjMan.find(GameObj.Type._Alien, GameObj.Name.AlienRoot),
                             GObjMan.find(GameObj.Type._Player, GameObj.Name.PlayerRoot));
            tmp.sub.attach(new A_P_Observer());

            tmp = ColMan.add(ColPair.Name.Player_Wall,
                             GObjMan.find(GameObj.Type._Player, GameObj.Name.PlayerRoot),
                             GObjMan.find(GameObj.Type._Wall, GameObj.Name.WallRoot));
            tmp.sub.attach(new P_W_Observer());

            tmp = ColMan.add(ColPair.Name.Shield_Missile,
                             GObjMan.find(GameObj.Type._Shield, GameObj.Name.ShieldRoot),
                             GObjMan.find(GameObj.Type._Missile, GameObj.Name.MissileRoot));
            tmp.sub.attach(new DestroyShieldObserver());
            tmp.sub.attach(new DestroyMissileObserver());
            
            tmp = ColMan.add(ColPair.Name.Player_Bomb,
                       GObjMan.find(GameObj.Type._Player, GameObj.Name.PlayerRoot),
                       GObjMan.find(GameObj.Type._Bomb, GameObj.Name.BombRoot));
            tmp.sub.attach(new P_B_Observer());

            tmp = ColMan.add(ColPair.Name.UFO_Missile,
                       GObjMan.find(GameObj.Type._UFO, GameObj.Name.UFORoot),
                       GObjMan.find(GameObj.Type._Missile, GameObj.Name.MissileRoot));
            tmp.sub.attach(new U_M_Observer());

            tmp = ColMan.add(ColPair.Name.UFO_Wall,
                       GObjMan.find(GameObj.Type._UFO, GameObj.Name.UFORoot),
                       GObjMan.find(GameObj.Type._Wall, GameObj.Name.WallRoot));
            tmp.sub.attach(new U_W_Observer());

            tmp = ColMan.add(ColPair.Name.Shield_Bomb,
                       GObjMan.find(GameObj.Type._Shield, GameObj.Name.ShieldRoot),
                       GObjMan.find(GameObj.Type._Bomb, GameObj.Name.BombRoot));
            tmp.sub.attach(new S_B_Observer());

            tmp = ColMan.add(ColPair.Name.Bomb_Wall,
                       GObjMan.find(GameObj.Type._Bomb, GameObj.Name.BombRoot),
                       GObjMan.find(GameObj.Type._Wall, GameObj.Name.WallRoot));
            tmp.sub.attach(new B_W_Observer());
        }

        private void buildObjects()
        {
            WallFactory.makeWalls();

            AlienFactory.makeAlienGrid(128.0f, 512.0f, 64.0f, 64.0f);

            MissileFactory.makeMissileRoot();
            
            ShieldFactory.makeShields();

            PlayerFactory.makePlayerRoot();

            PlayerFactory.spawnPlayer();
            
            BombFactory.makeBombRoot();
            
            UFOFactory.makeUFORoot();
        }


        //----------------------
        private static GameManager instance;
    }
}
