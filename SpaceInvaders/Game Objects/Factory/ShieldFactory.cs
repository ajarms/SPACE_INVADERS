using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldFactory: Factory
    {
        private ShieldFactory()
            :base()
        {}

        private static ShieldFactory getInstance()
        {
            if (instance == null)
            {
                instance = new ShieldFactory();
            }
            return instance;
        }

        public static PCSTree getTree()
        {
            ShieldFactory tmp = ShieldFactory.getInstance();

            return tmp.tree;
        }

        
        public static void makeShields()
        {
            ShieldFactory tmp = ShieldFactory.getInstance();

            // set batches
            tmp.setBatch(SpriteBatch.Name.Midground);
            tmp.setColBatch(SpriteBatch.Name.Collision);

            // set PCSTree
            tmp.setPCSTree();

            _Shield group = new ShieldRoot();
            GObjMan.add(group);
            tmp.colBatch.add(group.collision.drawSprite);
            tmp.tree.insert(group, tmp.parent);

            float startX = 128.0f + 4.0f;
            float startY = 128.0f + 4.0f;
            float spacing = 200.0f;

            // make 4 shields
            for (int i = 0; i < 4; ++i)
            {
                tmp.makeShield(Index._0 + i, startX + spacing * i, startY, group);
            }
        }

        private void makeShield(Index index, float xPos, float yPos, _Shield parent)
        {
            this.setParent(parent);
            _Shield curr;

            // make a shield
            curr = new Shield(index, xPos, yPos);
            // add to collision batch
            this.colBatch.add(curr.collision.drawSprite);
            // insert into tree
            this.tree.insert(curr, this.parent);

            this.setParent(curr);

            // make 11 columns
            // add to collision batch
            // insert into tree
            for (int i = 0; i < 11; ++i)
            {
                curr = new ShieldColumn(Index._0 + i);
                colBatch.add(curr.collision.drawSprite);
                tree.insert(curr, this.parent);
            }

            // COLUMN BY COLUMN

            // COLUMN 0
            this.setParent(curr.parent.child);
            int col = 0;
            int lvl = 0;
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col + 2.0f, yPos + 8.0f * lvl++ - 2.0f, BSprite.Name.Shield_SmallBlock);

            // COLUMN 1
            Debug.Assert(this.parent.sibling != null);
            this.setParent(this.parent.sibling);
            col++;
            lvl = 0;
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col + 2.0f, yPos + 8.0f * lvl++ - 2.0f, BSprite.Name.Shield_SmallBlock);

            // COLUMN 2
            Debug.Assert(this.parent.sibling != null);
            this.setParent(this.parent.sibling);
            col++;
            lvl = 0;
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);

            // COLUMN 3
            Debug.Assert(this.parent.sibling != null);
            this.setParent(this.parent.sibling);
            col++;
            lvl = 1;
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_UpperLeft);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);

            // COLUMN 4
            Debug.Assert(this.parent.sibling != null);
            this.setParent(this.parent.sibling);
            col++;
            lvl = 2;
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);

            // COLUMN 5
            Debug.Assert(this.parent.sibling != null);
            this.setParent(this.parent.sibling);
            col++;
            lvl = 2;
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);

            // COLUMN 6
            Debug.Assert(this.parent.sibling != null);
            this.setParent(this.parent.sibling);
            col++;
            lvl = 2;
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);

            // COLUMN 7
            Debug.Assert(this.parent.sibling != null);
            this.setParent(this.parent.sibling);
            col++;
            lvl = 1;
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_UpperRight);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);

            // COLUMN 8
            Debug.Assert(this.parent.sibling != null);
            this.setParent(this.parent.sibling);
            col++;
            lvl = 0;
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);

            // COLUMN 9
            Debug.Assert(this.parent.sibling != null);
            this.setParent(this.parent.sibling);
            col++;
            lvl = 0;
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col - 2.0f, yPos + 8.0f * lvl++ - 2.0f, BSprite.Name.Shield_SmallBlock);
            
            // COLUMN 10
            Debug.Assert(this.parent.sibling != null);
            this.setParent(this.parent.sibling);
            col++;
            lvl = 0;
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col, yPos + 8.0f * lvl++, BSprite.Name.Shield_Block);
            this.makeBlock(Index._0 + lvl, xPos + 8.0f * col - 2.0f, yPos + 8.0f * lvl++ - 2.0f, BSprite.Name.Shield_SmallBlock);
            
        }

        private void makeBlock(Index _index, float xPos, float yPos, BSprite.Name _name)
        {
            _Shield block;
            block = new ShieldBlock(_index, xPos, yPos, _name);
            this.currBatch.add(block.drawSprite);
            this.colBatch.add(block.collision.drawSprite);
            this.tree.insert(block, this.parent);
        }


        //---------------------------------------
        private static ShieldFactory instance;
    }
}
