using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ExplosionFactory : Factory
    {
        private ExplosionFactory()
            : base()
        { }

        private static ExplosionFactory getInstance()
        {
            if (instance == null)
            {
                instance = new ExplosionFactory();
            }
            return instance;
        }

        // loads explosions that will be needed during gameplay
        public static void loadExplosions()
        {
            // create all the expolsions

            _Explosion enemy0 = new EnemyExplosion(Index._0, 0.0f, 0.0f);
            _Explosion enemy1 = new EnemyExplosion(Index._1, 0.0f, 0.0f);
            _Explosion enemy2 = new EnemyExplosion(Index._2, 0.0f, 0.0f);
            _Explosion enemy3 = new EnemyExplosion(Index._3, 0.0f, 0.0f);

            _Explosion player0 = new PlayerExplosion(Index._0, 0.0f, 0.0f);

            _Explosion missile0 = new MissileExplosion(Index._0, 0.0f, 0.0f);
            _Explosion missile1 = new MissileExplosion(Index._1, 0.0f, 0.0f);

            _Explosion bomb0 = new BombExplosion(Index._0, 0.0f, 0.0f);
            _Explosion bomb1 = new BombExplosion(Index._1, 0.0f, 0.0f);
            _Explosion bomb2 = new BombExplosion(Index._2, 0.0f, 0.0f);
            _Explosion bomb3 = new BombExplosion(Index._3, 0.0f, 0.0f);
            _Explosion bomb4 = new BombExplosion(Index._4, 0.0f, 0.0f);

            // add them to the temporary object manager

            TempObjMan.add(enemy0);
            TempObjMan.add(enemy1);
            TempObjMan.add(enemy2);
            TempObjMan.add(enemy3);
            TempObjMan.add(bomb0);
            TempObjMan.add(bomb1);
            TempObjMan.add(bomb2);
            TempObjMan.add(bomb3);
            TempObjMan.add(bomb4);
            TempObjMan.add(player0);
            TempObjMan.add(missile0);
            TempObjMan.add(missile1);
        }

        // creates explosion from an object source
        public static GameObj explode(GameObj pSource)
        {
            int j = 0;
            _Explosion boom = null;

            // pick correct explosion type, then find one on the temp obj manager
            if (pSource is PlayerRoot)
            {
                boom = TempObjMan.find(GameObj.Name.PlayerExplosion) as _Explosion;
            }
            else if (pSource is _Alien || pSource is _UFO)
            {
                while (boom == null && j < 4)
                {
                    boom = TempObjMan.find(GameObj.Name.EnemyExplosion, Index._0 + j) as _Explosion;
                    ++j;
                }
            }
            else if (pSource is _Bomb)
            {
                while (boom == null && j < 5)
                {
                    boom = TempObjMan.find(GameObj.Name.BombExplosion, Index._0 + j) as _Explosion;
                    ++j;
                }
            }
            else if (pSource is _Missile)
            {
                while (boom == null && j < 2)
                {
                    boom = TempObjMan.find(GameObj.Name.MissileExplosion, Index._0 + j) as _Explosion;
                    ++j;
                }
            }

            Debug.Assert(boom != null);

            // set explosion location
            boom.x = pSource.collision.x + pSource.collision.w / 2.0f;
            boom.y = pSource.collision.y + pSource.collision.h / 2.0f;
            boom.update();

            // add explosion to draw batch
            ExplosionFactory tmp = ExplosionFactory.getInstance();
            tmp.setBatch(SpriteBatch.Name.Projectiles);
            tmp.currBatch.add(boom.drawSprite);

            // remove from temporary object list
            TempObjMan.remove(boom.name, boom.index);

            // return explosion, to be put onto a timer for removal
            return boom;
        }


        //---------------------------------------
        private static ExplosionFactory instance;
    }
}
