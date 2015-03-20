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

        // loads UFOs that will be needed during gameplay
        public static void loadUFOs()
        {
            _UFO pUFO = new UFO();
            pUFO.drawSprite.setColor(250.0f, 0.0f, 0.0f);
            TempObjMan.add(pUFO);
        }

        // grabs loaded UFO and adds it to collison and draw structures
        public static void spawnUFO()
        {
            // grab loaded UFO if available
            UFO saucer = TempObjMan.find(GameObj.Name.UFO) as UFO;
            if (saucer != null)
            {
                GameObj mRoot = GObjMan.find(GameObj.Type._UFO, GameObj.Name.UFORoot);

                // pick random direction
                bool right = Randomizer.randBool();

                // set UFO
                saucer.y = Constants.SCREEN_HEIGHT - 128.0f - saucer.collision.h * 2;
                if (right){
                    saucer.x = 0.0f;
                    saucer.direction = 1.0f;
                }
                else{
                    saucer.x = Constants.SCREEN_WIDTH;
                    saucer.direction = -1.0f;
                }

                // add UFO to draw and collision structures
                UFOFactory tmp = UFOFactory.getInstance();

                tmp.setParent(mRoot);
                tmp.setBatch(SpriteBatch.Name.Midground);
                tmp.setColBatch(SpriteBatch.Name.Collision);

                tmp.currBatch.add(saucer.drawSprite);
                tmp.colBatch.add(saucer.collision.drawSprite);
                tmp.tree.insert(saucer, tmp.parent);

                // remove from temporary object list
                TempObjMan.remove(saucer.name, saucer.index);
            }
        }


        //---------------------------------------
        private static UFOFactory instance;
    }
}
