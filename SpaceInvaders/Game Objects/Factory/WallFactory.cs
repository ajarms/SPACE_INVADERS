using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class WallFactory : Factory
    {
        private WallFactory()
            : base()
        { }

        private static WallFactory getInstance()
        {
            if (instance == null)
            {
                instance = new WallFactory();
            }
            return instance;
        }

        public static PCSTree getTree()
        {
            WallFactory tmp = WallFactory.getInstance();

            return tmp.tree;
        }
        
        // makes wall objects for collision
        public static void makeWalls()
        {
            WallFactory tmp = WallFactory.getInstance();

            // set batches
            tmp.setBatch(SpriteBatch.Name.Background);
            tmp.setColBatch(SpriteBatch.Name.Collision);

            // set PCSTree
            tmp.setPCSTree();

            _Wall wallGroup = new WallRoot();

            GObjMan.add(wallGroup);

            tmp.tree.insert(wallGroup, tmp.parent);
            tmp.setParent(wallGroup);

            // make each wall
            _Wall right = new WallRight();
            tmp.colBatch.add(right.collision.drawSprite);
            tmp.tree.insert(right, tmp.parent);

            _Wall left = new WallLeft();
            tmp.colBatch.add(left.collision.drawSprite);
            tmp.tree.insert(left, tmp.parent);

            _Wall top = new WallTop();
            tmp.colBatch.add(top.collision.drawSprite);
            tmp.tree.insert(top, tmp.parent);

            _Wall bottom = new WallBottom();
            tmp.colBatch.add(bottom.collision.drawSprite);
            tmp.tree.insert(bottom, tmp.parent);

        }

        //---------------------------------------
        private static WallFactory instance;
    }
}
