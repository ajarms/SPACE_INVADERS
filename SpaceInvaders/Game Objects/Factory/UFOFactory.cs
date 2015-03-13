using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFOFactory : Factory
    {
        private UFOFactory()
            : base()
        { }

        private static UFOFactory getInstance()
        {
            if (instance == null)
            {
                instance = new UFOFactory();
            }
            return instance;
        }

        public static PCSTree getTree()
        {
            UFOFactory tmp = UFOFactory.getInstance();

            return tmp.tree;
        }

        // makes missile tree
        public static void makeUFORoot()
        {
            // make a test missle
            UFOFactory tmp = UFOFactory.getInstance();

            // set batches
            tmp.setBatch(SpriteBatch.Name.Midground);
            tmp.setColBatch(SpriteBatch.Name.Collision);

            // set PCSTree
            tmp.setPCSTree();

            // make missile root
            _UFO UFOGroup = new UFORoot();
            GObjMan.add(UFOGroup);
            tmp.colBatch.add(UFOGroup.collision.drawSprite);
            tmp.tree.insert(UFOGroup, tmp.parent);
        }

        // boolean sets ufo's travel direction
        public static void spawnUFO()
        {

            GameObj mRoot = GObjMan.find(GameObj.Type._UFO, GameObj.Name.UFORoot);

            // cannot spawn a missile if one is in flight
            if (mRoot.child != null)
            {
                return;
            }

            _UFO saucer = new UFO();
            UFOFactory tmp = UFOFactory.getInstance();

            tmp.setParent(mRoot);
            tmp.setBatch(SpriteBatch.Name.Midground);
            tmp.setColBatch(SpriteBatch.Name.Collision);

            tmp.currBatch.add(saucer.drawSprite);
            tmp.colBatch.add(saucer.collision.drawSprite);
            tmp.tree.insert(saucer, tmp.parent);
        }


        //---------------------------------------
        private static UFOFactory instance;
    }
}
