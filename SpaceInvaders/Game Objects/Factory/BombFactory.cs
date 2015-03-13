using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombFactory : Factory
    {
        private BombFactory()
            : base()
        { }

        private static BombFactory getInstance()
        {
            if (instance == null)
            {
                instance = new BombFactory();
            }
            return instance;
        }

        public static PCSTree getTree()
        {
            BombFactory tmp = BombFactory.getInstance();

            return tmp.tree;
        }

        // makes missile tree
        public static void makeBombRoot()
        {
            // make a test missle
            BombFactory tmp = BombFactory.getInstance();

            // set batches
            tmp.setBatch(SpriteBatch.Name.Projectiles);
            tmp.setColBatch(SpriteBatch.Name.Collision);

            // set PCSTree
            tmp.setPCSTree();

            // make missile root
            _Bomb UFOGroup = new BombRoot();
            GObjMan.add(UFOGroup);
            tmp.colBatch.add(UFOGroup.collision.drawSprite);
            tmp.tree.insert(UFOGroup, tmp.parent);
        }

        public static void spawnBomb(float xPos, float yPos)
        {

            GameObj mRoot = GObjMan.find(GameObj.Type._Bomb, GameObj.Name.BombRoot);

            _Bomb kaboom;
            
            kaboom = new BombA(Index._0, xPos, yPos);
            BombFactory tmp = BombFactory.getInstance();

            tmp.setParent(mRoot);
            tmp.setBatch(SpriteBatch.Name.Projectiles);
            tmp.setColBatch(SpriteBatch.Name.Collision);

            tmp.currBatch.add(kaboom.drawSprite);
            tmp.colBatch.add(kaboom.collision.drawSprite);
            tmp.tree.insert(kaboom, tmp.parent);
        }


        //---------------------------------------
        private static BombFactory instance;
    }
}

