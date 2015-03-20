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
            EventMan.create();
            ColMan.create(12);
            TempObjMan.create();
            Randomizer.create();
            SceneMan.create();
            ScoreMan.create();
            InputManager.create();
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

            pGame.loadScenes();
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
            EventMan.printStats();
            EventMan.destroy();
            ColMan.printStats();
            ColMan.destroy();
            TempObjMan.printStats();
            TempObjMan.destroy();

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
            ImgMan.add(Image.Name.Player_Ship, Texture.Name.ArcadeQuality, 136, 60, 52, 32);
            ImgMan.add(Image.Name.Ship_Base, Texture.Name.ArcadeQuality, 136, 72, 52, 20);
            ImgMan.add(Image.Name.Ship_Blaster, Texture.Name.ArcadeQuality, 156, 60, 12, 32);
            ImgMan.add(Image.Name.Alien_Explosion, Texture.Name.ArcadeQuality, 400, 0, 52, 32);
            ImgMan.add(Image.Name.Ship_Explosion_0, Texture.Name.ArcadeQuality, 204, 60, 60, 32);
            ImgMan.add(Image.Name.Ship_Explosion_1, Texture.Name.ArcadeQuality, 268, 60, 64, 32);
            ImgMan.add(Image.Name.Missile, Texture.Name.ArcadeQuality, 116, 72, 4, 16);
            ImgMan.add(Image.Name.UFO, Texture.Name.ArcadeQuality, 0, 4, 64, 28);
            ImgMan.add(Image.Name.Shield_Block, Texture.Name.ArcadeQuality, 16, 104, 8, 8);
            ImgMan.add(Image.Name.Shield_Corner, Texture.Name.ArcadeQuality, 72, 96, 8, 8);
            ImgMan.add(Image.Name.Shield_SmallBlock, Texture.Name.ArcadeQuality, 16, 104, 4, 4);
            ImgMan.add(Image.Name.BombA_0, Texture.Name.ArcadeQuality, 366, 68, 12, 24);
            ImgMan.add(Image.Name.BombA_1, Texture.Name.ArcadeQuality, 352, 68, 12, 24);
            ImgMan.add(Image.Name.BombA_2, Texture.Name.ArcadeQuality, 380, 68, 12, 24);
            ImgMan.add(Image.Name.BombA_3, Texture.Name.ArcadeQuality, 338, 68, 12, 24);
            ImgMan.add(Image.Name.BombB_0, Texture.Name.ArcadeQuality, 392, 64, 12, 28);
            ImgMan.add(Image.Name.BombB_1, Texture.Name.ArcadeQuality, 392, 34, 12, 28);
            ImgMan.add(Image.Name.BombB_2, Texture.Name.ArcadeQuality, 412, 64, 12, 28);
            ImgMan.add(Image.Name.BombC_0, Texture.Name.ArcadeQuality, 428, 64, 12, 28);
            ImgMan.add(Image.Name.BombC_1, Texture.Name.ArcadeQuality, 440, 64, 12, 28);
            ImgMan.add(Image.Name.BombC_2, Texture.Name.ArcadeQuality, 428, 34, 12, 28);

            ImgMan.add(Image.Name.Projectile_vs_Wall, Texture.Name.Explosions, 2, 2, 32, 32);
            ImgMan.add(Image.Name.Bomb_vs_Missile, Texture.Name.Explosions, 36, 0, 24, 32);
        }

        private void loadSprites()
        {
            SpriteMan.add(BSprite.Name.Squid, ImgMan.find(Image.Name.Squid_0), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Crab, ImgMan.find(Image.Name.Crab_0), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Octopus, ImgMan.find(Image.Name.Octopus_0), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Player_Ship, ImgMan.find(Image.Name.Player_Ship), 0.0f, 0.0f).setColor(0.0f, 250.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Ship_Base, ImgMan.find(Image.Name.Ship_Base), 0.0f, 0.0f).setColor(0.0f, 250.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Ship_Blaster, ImgMan.find(Image.Name.Ship_Blaster), 0.0f, 0.0f).setColor(0.0f, 250.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Missile, ImgMan.find(Image.Name.Missile), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.BombA, ImgMan.find(Image.Name.BombA_0), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.BombB, ImgMan.find(Image.Name.BombB_0), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.BombC, ImgMan.find(Image.Name.BombC_0), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.UFO, ImgMan.find(Image.Name.UFO), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Shield_Block, ImgMan.find(Image.Name.Shield_Block), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Shield_UpperRight, ImgMan.find(Image.Name.Shield_Corner), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.Shield_UpperLeft, ImgMan.find(Image.Name.Shield_Corner), 0.0f, 0.0f, -1.0f);
            SpriteMan.add(BSprite.Name.Shield_SmallBlock, ImgMan.find(Image.Name.Shield_SmallBlock), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.EnemyExplosion, ImgMan.find(Image.Name.Alien_Explosion), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.PlayerExplosion, ImgMan.find(Image.Name.Ship_Explosion_0), 0.0f, 0.0f).setColor(0.0f, 250.0f, 0.0f);
            SpriteMan.add(BSprite.Name.MissileExplosion, ImgMan.find(Image.Name.Projectile_vs_Wall), 0.0f, 0.0f);
            SpriteMan.add(BSprite.Name.BombExplosion, ImgMan.find(Image.Name.Bomb_vs_Missile), 0.0f, 0.0f);
            
            SBatchMan.add(SpriteBatch.Name.Projectiles);
            SBatchMan.add(SpriteBatch.Name.Aliens);
            SBatchMan.add(SpriteBatch.Name.Midground);
            SBatchMan.add(SpriteBatch.Name.Collision);
            SBatchMan.add(SpriteBatch.Name.Background);

            SBatchMan.drawOff(SpriteBatch.Name.Collision);
        }

        private void loadTimeEvents()
        {
            // load animations
            AnimationEvent crab = EventMan.add(new AnimationEvent(Event.Name.Crab_Animation, true)) as AnimationEvent;
            AnimationEvent squid = EventMan.add(new AnimationEvent(Event.Name.Squid_Animation, true)) as AnimationEvent;
            AnimationEvent octopus = EventMan.add(new AnimationEvent(Event.Name.Octopus_Animation, true)) as AnimationEvent;
            AnimationEvent bombA = EventMan.add(new AnimationEvent(Event.Name.BombA_Animation)) as AnimationEvent;
            AnimationEvent bombB = EventMan.add(new AnimationEvent(Event.Name.BombB_Animation)) as AnimationEvent;
            AnimationEvent bombC = EventMan.add(new AnimationEvent(Event.Name.BombC_Animation)) as AnimationEvent;
            AnimationEvent death = EventMan.add(new AnimationEvent(Event.Name.Death_Animation)) as AnimationEvent;
            UFOEvent ufo = EventMan.add(new UFOEvent()) as UFOEvent;
            BombEvent bombSpawn = EventMan.add(new BombEvent()) as BombEvent;
            MoveEvent movement = EventMan.add(new MoveEvent(Event.Name.Grid_Movement,
                                                            GObjMan.find(GameObj.Type._Alien, GameObj.Name.AlienRoot),
                                                            8.0f, 0.0f)) as MoveEvent;

            // stop events for removing explosions, 4 explosions at once should be plenty
            EventMan.add(new StopEvent(Index._0));
            EventMan.add(new StopEvent(Index._1));
            EventMan.add(new StopEvent(Index._2));
            EventMan.add(new StopEvent(Index._3));
            EventMan.add(new StopEvent(Index._4));
            EventMan.add(new StopEvent(Index._5));

            EventMan.add(new SoundEvent(Event.Name.UFO_Sound));
            EventMan.add(new SoundEvent(Event.Name.UFODeath_Sound));
            EventMan.add(new SoundEvent(Event.Name.Shoot_Sound));
            EventMan.add(new SoundEvent(Event.Name.Explosion_Sound));
            EventMan.add(new SoundEvent(Event.Name.Death_Sound));
            EventMan.add(new SpawnPlayerEvent());
            EventMan.add(new SpawnAlienEvent());
            SoundEvent alienA = EventMan.add(new SoundEvent(Event.Name.Alien_SoundA)) as SoundEvent;
            SoundEvent alienB = EventMan.add(new SoundEvent(Event.Name.Alien_SoundB)) as SoundEvent;
            SoundEvent alienC = EventMan.add(new SoundEvent(Event.Name.Alien_SoundC)) as SoundEvent;
            SoundEvent alienD = EventMan.add(new SoundEvent(Event.Name.Alien_SoundD)) as SoundEvent;


            // set animation images
            crab.attach(Image.Name.Crab_1);
            crab.attach(Image.Name.Crab_0);
            squid.attach(Image.Name.Squid_1);
            squid.attach(Image.Name.Squid_0);
            octopus.attach(Image.Name.Octopus_1);
            octopus.attach(Image.Name.Octopus_0);

            bombA.attach(Image.Name.BombA_0);
            bombA.attach(Image.Name.BombA_1);
            bombA.attach(Image.Name.BombA_2);
            bombA.attach(Image.Name.BombA_3);
            bombA.attach(Image.Name.BombA_2);
            bombA.attach(Image.Name.BombA_1);

            bombB.attach(Image.Name.BombB_0);
            bombB.attach(Image.Name.BombB_1);
            bombB.attach(Image.Name.BombB_2);
            
            bombC.attach(Image.Name.BombC_0);
            bombC.attach(Image.Name.BombC_1);
            bombC.attach(Image.Name.BombC_2);

            death.attach(Image.Name.Ship_Explosion_0);
            death.attach(Image.Name.Ship_Explosion_1);

            // set startup animations
            TimerMan.add(Timer.Name.AlienAnimationTimer, crab, Constants.ALIEN_START_RATE);
            TimerMan.add(Timer.Name.AlienAnimationTimer, squid, Constants.ALIEN_START_RATE);
            TimerMan.add(Timer.Name.AlienAnimationTimer, octopus, Constants.ALIEN_START_RATE);
            TimerMan.add(Timer.Name.AlienAnimationTimer, movement, Constants.ALIEN_START_RATE);
            TimerMan.add(Timer.Name.BombAnimationTimer, bombA, 0.1f);
            TimerMan.add(Timer.Name.BombAnimationTimer, bombB, 0.1f);
            TimerMan.add(Timer.Name.BombAnimationTimer, bombC, 0.1f);
            TimerMan.add(Timer.Name.AlienAnimationTimer, alienA, Constants.ALIEN_START_RATE);
            TimerMan.add(Timer.Name.UFOTimer, ufo, Randomizer.randInt(10, 30));
            TimerMan.add(Timer.Name.BombTimer, bombSpawn, GObjMan.alienCount() * Randomizer.randFloat() / 20.0f);
        }

        private void loadCollisions()
        {
            ColPair tmp;

            tmp = ColMan.add(ColPair.Name.Alien_Missile,
                             GObjMan.find(GameObj.Type._Alien, GameObj.Name.AlienRoot),
                             GObjMan.find(GameObj.Type._Missile, GameObj.Name.MissileRoot));
            tmp.sub.attach(new NewWaveObserver());
            tmp.sub.attach(new DestroyMissileObserver());
            tmp.sub.attach(new DestroyAlienObserver());
            tmp.sub.attach(new AlienExplosionObserver());
            tmp.sub.attach(new ScoreObserver());

            tmp = ColMan.add(ColPair.Name.Alien_Wall,
                             GObjMan.find(GameObj.Type._Alien, GameObj.Name.AlienRoot),
                             GObjMan.find(GameObj.Type._Wall, GameObj.Name.WallRoot));
            tmp.sub.attach(new AlienTurnObserver());

            tmp = ColMan.add(ColPair.Name.Missile_Wall,
                             GObjMan.find(GameObj.Type._Missile, GameObj.Name.MissileRoot),
                             GObjMan.find(GameObj.Type._Wall, GameObj.Name.WallRoot));
            tmp.sub.attach(new DestroyMissileObserver());
            tmp.sub.attach(new MissileExplosionObserver());

            tmp = ColMan.add(ColPair.Name.Alien_Shield,
                             GObjMan.find(GameObj.Type._Alien, GameObj.Name.AlienRoot),
                             GObjMan.find(GameObj.Type._Shield, GameObj.Name.ShieldRoot));
            tmp.sub.attach(new DestroyShieldObserver());

            tmp = ColMan.add(ColPair.Name.Alien_Player,
                             GObjMan.find(GameObj.Type._Alien, GameObj.Name.AlienRoot),
                             GObjMan.find(GameObj.Type._Player, GameObj.Name.PlayerRoot));
            tmp.sub.attach(new DestroyPlayerObserver());
            tmp.sub.attach(new PlayerDeathObserver());

            tmp = ColMan.add(ColPair.Name.Player_Wall,
                             GObjMan.find(GameObj.Type._Player, GameObj.Name.PlayerRoot),
                             GObjMan.find(GameObj.Type._Wall, GameObj.Name.WallRoot));
            tmp.sub.attach(new PlayerWallObserver());

            tmp = ColMan.add(ColPair.Name.Shield_Missile,
                             GObjMan.find(GameObj.Type._Shield, GameObj.Name.ShieldRoot),
                             GObjMan.find(GameObj.Type._Missile, GameObj.Name.MissileRoot));
            tmp.sub.attach(new DestroyShieldObserver());
            tmp.sub.attach(new DestroyMissileObserver());
            
            tmp = ColMan.add(ColPair.Name.Player_Bomb,
                       GObjMan.find(GameObj.Type._Player, GameObj.Name.PlayerRoot),
                       GObjMan.find(GameObj.Type._Bomb, GameObj.Name.BombRoot));
            tmp.sub.attach(new DestroyBombObserver());
            tmp.sub.attach(new DestroyPlayerObserver());
            tmp.sub.attach(new BombExplosionObserver());
            tmp.sub.attach(new PlayerDeathObserver());

            tmp = ColMan.add(ColPair.Name.UFO_Missile,
                       GObjMan.find(GameObj.Type._UFO, GameObj.Name.UFORoot),
                       GObjMan.find(GameObj.Type._Missile, GameObj.Name.MissileRoot));
            tmp.sub.attach(new DestroyUFOObserver());
            tmp.sub.attach(new DestroyMissileObserver());
            tmp.sub.attach(new UFOExplosionObserver());
            tmp.sub.attach(new ScoreObserver());

            tmp = ColMan.add(ColPair.Name.Shield_Bomb,
                       GObjMan.find(GameObj.Type._Shield, GameObj.Name.ShieldRoot),
                       GObjMan.find(GameObj.Type._Bomb, GameObj.Name.BombRoot));
            tmp.sub.attach(new DestroyShieldObserver());
            tmp.sub.attach(new DestroyBombObserver());
            tmp.sub.attach(new BombExplosionObserver());

            tmp = ColMan.add(ColPair.Name.Bomb_Wall,
                       GObjMan.find(GameObj.Type._Bomb, GameObj.Name.BombRoot),
                       GObjMan.find(GameObj.Type._Wall, GameObj.Name.WallRoot));
            tmp.sub.attach(new DestroyBombObserver());
            tmp.sub.attach(new BombExplosionObserver());

            tmp = ColMan.add(ColPair.Name.Missile_Bomb,
                             GObjMan.find(GameObj.Type._Missile, GameObj.Name.MissileRoot),
                             GObjMan.find(GameObj.Type._Bomb, GameObj.Name.BombRoot));
            tmp.sub.attach(new DestroyBombObserver());
            tmp.sub.attach(new DestroyMissileObserver());
            tmp.sub.attach(new BombExplosionObserver());
        }

        private void buildObjects()
        {
            WallFactory.makeWalls();

            AlienFactory.makeAlienRoot();
            AlienFactory.spawnAliens(Constants.GRID_START_X, Constants.GRID_START_Y,
                                       Constants.GRID_SPACING, Constants.GRID_SPACING);

            MissileFactory.makeMissileRoot();
            MissileFactory.loadMissiles();
            
            ShieldFactory.makeShields();

            PlayerFactory.makePlayerRoot();
            PlayerFactory.spawnPlayer();
            
            BombFactory.makeBombRoot();
            BombFactory.loadBombs();
            
            UFOFactory.makeUFORoot();
            UFOFactory.loadUFOs();

            ExplosionFactory.loadExplosions();
        }

        private void loadScenes()
        {
            GameScene p1 = SceneMan.add(new GameScene(Scene.Name.Player1_Game)) as GameScene;
            SceneMan.add(new GameScene(Scene.Name.Player2_Game));
            SceneMan.add(new SplashScene());
            SceneMan.add(new AttractScene());
            SceneMan.setScene(Scene.Name.Player1_Game);

            ScoreMan.setPlayer(p1.getPlayer());
            ScoreMan.loadMessages();

            InputManager.setState(new SceneState_Game());
        }

        //----------------------
        private static GameManager instance;
    }
}
