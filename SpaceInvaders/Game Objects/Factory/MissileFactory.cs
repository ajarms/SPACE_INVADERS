using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MissileFactory : Factory
    {
        private MissileFactory()
            : base()
        { }

        private static MissileFactory getInstance()
        {
            if (instance == null)
            {
                instance = new MissileFactory();
            }
            return instance;
        }

        public static PCSTree getTree()
        {
            MissileFactory tmp = MissileFactory.getInstance();

            return tmp.tree;
        }

        // makes missile tree
        public static void makeMissileRoot()
        {
            // make a test missle
            MissileFactory tmp = MissileFactory.getInstance();

            // set batches
            tmp.setBatch(SpriteBatch.Name.Projectiles);
            tmp.setColBatch(SpriteBatch.Name.Collision);

            // set PCSTree
            tmp.setPCSTree();

            // make missile root
            _Missile missileGroup = new MissileRoot();
            GObjMan.add(missileGroup);
            tmp.colBatch.add(missileGroup.collision.drawSprite);
            tmp.tree.insert(missileGroup, tmp.parent);
        }

        // loads missiles that will be needed during gameplay
        public static void loadMissiles()
        {
            _Missile pMissile = new ShipMissile(0.0f, 0.0f);

            TempObjMan.add(pMissile);
        }

        // fires missile from an object source
        public static void fireMissile(GameObj pSource)
        {
            // grab loaded missile if available
            _Missile boom = TempObjMan.find(GameObj.Name.Missile) as _Missile;
            if (boom != null)
            {
                GameObj mRoot = GObjMan.find(GameObj.Type._Missile, GameObj.Name.MissileRoot);

                // set missile
                boom.x = pSource.collision.x + pSource.collision.w / 2.0f;
                boom.y = pSource.collision.y + pSource.collision.h;

                // add missile to draw and collision structures
                MissileFactory tmp = MissileFactory.getInstance();

                tmp.setParent(mRoot);
                tmp.setBatch(SpriteBatch.Name.Projectiles);
                tmp.setColBatch(SpriteBatch.Name.Collision);

                tmp.currBatch.add(boom.drawSprite);
                tmp.colBatch.add(boom.collision.drawSprite);
                tmp.tree.insert(boom, tmp.parent);

                // remove from temporary object list
                TempObjMan.remove(boom.name, boom.index);
            }
        }


        //---------------------------------------
        private static MissileFactory instance;
    }
}
