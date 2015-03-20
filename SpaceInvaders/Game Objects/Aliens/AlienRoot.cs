using System;

namespace SpaceInvaders
{
    class AlienRoot: _Alien
    {
        public AlienRoot(float _x, float _y)
            : base(GameObj.Name.AlienRoot, Index._0, BSprite.Name.NullSprite, new Azul.Color(0.0f, 0.0f, 250.0f))
        {
            this.x = _x;
            this.y = _y;
        }

        public override void move(float deltaX, float deltaY)
        {
            GameObj pChild = this.child as GameObj;

            if (pChild != null)
            {
                pChild.move(deltaX * this.direction, deltaY);
                this.x += deltaX * this.direction;
                this.y += deltaY;
            }
        }

        public override void update()
        {
            // add union updating
            base.unionUpdate();
        }

        public void changeDirection()
        {
            this.direction *= -1.0f;
        }

        public void resetColumnCount()
        {
            this.columnCount = 11;
        }

        public void updateColumnCount()
        {
            this.columnCount--;
        }

        public int getColumnCount()
        {
            return this.columnCount;
        }

        //------------------------------
        private int columnCount;

        //-----------------------------------
        // visitor handlers
        //-----------------------------------

        public override void accept(GameObj that)
        {
            that.visitAlienRoot(this);
        }

        public override void visitMissileRoot(GameObj other)
        {
            // drop one level
            GameObj curr = this.child as GameObj;

            // collide against everything at this level
            while (curr != null)
            {
                if (ColPair.collide(curr, other))
                {
                    return;
                }

                curr = curr.sibling as GameObj;
            }
        }

        public override void visitWallRoot(GameObj other)
        {
            other.visitAlienRoot(this);
        }

        public override void visitWallSides(GameObj other)
        {
            Subject tmp = ColMan.getActivePair().sub;

            tmp.set(this, other);
            tmp.notify();
        }

        public override void visitShield(GameObj other)
        {
            // drop one level
            GameObj curr = this.child as GameObj;

            // collide against everything at this level
            while (curr != null)
            {
                if (ColPair.collide(curr, other))
                {
                    return;
                }
                curr = curr.sibling as GameObj;
            }
        }

        public override void visitPlayerRoot(GameObj other)
        {
            // drop one level
            GameObj curr = this.child as GameObj;

            // collide against everything at this level
            while (curr != null)
            {
                if (ColPair.collide(curr, other))
                {
                    return;
                }
                curr = curr.sibling as GameObj;
            }
        }

        private float direction = 1.0f;
    }
}
