using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienFactory:Factory
    {
        private AlienFactory()
            :base()
        {}

        private static AlienFactory getInstance()
        {
            if (instance == null)
            {
                instance = new AlienFactory();
            }
            return instance;
        }

        public static PCSTree getTree()
        {
            AlienFactory tmp = AlienFactory.getInstance();

            return tmp.tree;
        }

        
        // makes new aliens and adds them to the GObjMan and SpriteBatch
        public static _Alien makeAlien(_Alien.AlienType alienType, Index index, float x, float y)
        {
            AlienFactory pFactory = AlienFactory.getInstance();

            _Alien newAlien = null;

            switch (alienType)
            {
                case _Alien.AlienType.Crab:
                    newAlien = new Crab(index, x, y);
                    break;
                case _Alien.AlienType.Octopus:
                    newAlien = new Octopus(index, x, y);
                    break;
                case _Alien.AlienType.Squid:
                    newAlien = new Squid(index, x, y);
                    break;
                case _Alien.AlienType.Column:
                    newAlien = new AlienColumn(index, x, y);
                    break;
                case _Alien.AlienType.Grid:
                    newAlien = new AlienRoot(x, y);
                    break;
            }
            
            pFactory.currBatch.add(newAlien.drawSprite);
            pFactory.colBatch.add(newAlien.collision.drawSprite);

            pFactory.tree.insert(newAlien, pFactory.parent);

            return newAlien;
        }

        // makes entire alien grid given a starting corner and grid spacing, automatically uses alien spritebatch
        public static void makeAlienGrid(float x_start, float y_start, float x_space, float y_space)
        {
            AlienFactory tmp = AlienFactory.getInstance();

            // set batches
            tmp.setBatch(SpriteBatch.Name.Aliens);
            tmp.setColBatch(SpriteBatch.Name.Collision);

            // set PCSTree
            tmp.setPCSTree();
            
            _Alien grid = new AlienRoot(x_start, y_start);
            GObjMan.add(grid);
            tmp.colBatch.add(grid.collision.drawSprite);
            tmp.tree.insert(grid, tmp.parent);
            

            // make 11 columns
            for (int i = 0; i < 11; ++i)
            {
                tmp.setParent(grid);

                _Alien column = AlienFactory.makeAlien(_Alien.AlienType.Column, Index._0 + i, x_start + i * x_space, y_start);
                // make 5 aliens per column
                tmp.setParent(column);

                AlienFactory.makeAlien(_Alien.AlienType.Octopus, Index._0 + i, x_start + i * x_space, y_start);
                AlienFactory.makeAlien(_Alien.AlienType.Octopus, Index._0 + i, x_start + i * x_space, y_start + y_space);
                AlienFactory.makeAlien(_Alien.AlienType.Crab, Index._0 + i + 11, x_start + i * x_space, y_start + 2 * y_space);
                AlienFactory.makeAlien(_Alien.AlienType.Crab, Index._0 + i, x_start + i * x_space, y_start + 3 * y_space);
                AlienFactory.makeAlien(_Alien.AlienType.Squid, Index._0 + i + 11, x_start + i * x_space, y_start + 4 * y_space);
            }

            // set alien count for speed calculations
            GObjMan.resetAlienCount();
        }

        
        //---------------------------------------
        private static AlienFactory instance;
    }
}
