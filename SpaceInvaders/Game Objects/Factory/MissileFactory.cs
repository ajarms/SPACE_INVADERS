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

        public static void spawnMissile(float xPos, float yPos)
        {
            
            GameObj mRoot = GObjMan.find(GameObj.Type._Missile, GameObj.Name.MissileRoot);

            // cannot spawn a missile if one is in flight
            if (mRoot.child != null)
            {
                return;
            }

            yPos -= 16.0f;

            _Missile boom = new ShipMissile(xPos, yPos);
            MissileFactory tmp = MissileFactory.getInstance();
            
            tmp.setParent(mRoot);
            tmp.setBatch(SpriteBatch.Name.Projectiles);
            tmp.setColBatch(SpriteBatch.Name.Collision);

            tmp.currBatch.add(boom.drawSprite);
            tmp.colBatch.add(boom.collision.drawSprite);
            tmp.tree.insert(boom, tmp.parent);
        }


        //---------------------------------------
        private static MissileFactory instance;
    }
}
