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

        // loads bombs that will be needed during gameplay
        public static void loadBombs()
        {
            // build 3 of each bomb type
            _Bomb bombA0 = new BombA(Index._0, 0.0f, 0.0f);
            _Bomb bombA1 = new BombA(Index._1, 0.0f, 0.0f);
            _Bomb bombA2 = new BombA(Index._2, 0.0f, 0.0f);

            _Bomb bombB0 = new BombB(Index._0, 0.0f, 0.0f);
            _Bomb bombB1 = new BombB(Index._1, 0.0f, 0.0f);
            _Bomb bombB2 = new BombB(Index._2, 0.0f, 0.0f);

            _Bomb bombC0 = new BombC(Index._0, 0.0f, 0.0f);
            _Bomb bombC1 = new BombC(Index._1, 0.0f, 0.0f);
            _Bomb bombC2 = new BombC(Index._2, 0.0f, 0.0f);

            // put them onto the Temporary Object manager for later
            TempObjMan.add(bombA0);
            TempObjMan.add(bombA1);
            TempObjMan.add(bombA2);

            TempObjMan.add(bombB0);
            TempObjMan.add(bombB1);
            TempObjMan.add(bombB2);

            TempObjMan.add(bombC0);
            TempObjMan.add(bombC1);
            TempObjMan.add(bombC2);
        }

        // grabs loaded bomb and adds it to collision and draw structures
        public static void spawnBomb()//(float xPos, float yPos)
        {
            AlienRoot pGrid = GObjMan.find(GameObj.Type._Alien, GameObj.Name.AlienRoot) as AlienRoot;

            // get a random column
            int j = Randomizer.randInt(0, pGrid.getColumnCount());
            AlienColumn bomber = pGrid.child as AlienColumn;

            if (bomber == null) { return; }

            if (j != 0)
            {
                for (int i = 0; i < j; ++i)
                {
                    if (bomber.sibling == null) { break; }

                    bomber = bomber.sibling as AlienColumn;
                }
            }
            
            bomber.dropBomb();
            
        }

        // drops a bomb from an object source
        public static void dropBomb(GameObj pSource)
        {
            // index to pick random bomb type
            int i = Randomizer.randInt(0, 3);
            int j = 0;
            _Bomb kaboom = null;

            // search for an available bomb of that type
            while (kaboom == null && j < 3)
            {
                kaboom = TempObjMan.find(GameObj.Name.BombA + i, Index._0 + j) as _Bomb;
                ++j;
            }

            if (kaboom != null)
            {
                GameObj mRoot = GObjMan.find(GameObj.Type._Bomb, GameObj.Name.BombRoot);

                kaboom.x = pSource.collision.x + pSource.collision.w/2;
                kaboom.y = pSource.collision.y;
                kaboom.pSource = pSource as AlienColumn;

                BombFactory tmp = BombFactory.getInstance();

                tmp.setParent(mRoot);
                tmp.setBatch(SpriteBatch.Name.Projectiles);
                tmp.setColBatch(SpriteBatch.Name.Collision);

                tmp.currBatch.add(kaboom.drawSprite);
                tmp.colBatch.add(kaboom.collision.drawSprite);
                tmp.tree.insert(kaboom, tmp.parent);

                TempObjMan.remove(kaboom.name, kaboom.index);
            }
        }


        //---------------------------------------
        private static BombFactory instance;
    }
}

