using System;

namespace SpaceInvaders
{
    class AlienColumn: _Alien
    {
        public AlienColumn( Index index, float _x, float _y)
            : base(GameObj.Name.AlienColumn, index, BSprite.Name.NullSprite, new Azul.Color(250.0f, 250.0f, 0.0f))
        {
            this.x = _x;
            this.y = _y;
            this.State = new ColumnState_CanFire();
        }

        public override void update()
        {
            base.unionUpdate();
        }

        public void dropBomb()
        {
            fireState.handle(this);
        }

        public State State
        {
            set { fireState = value; }
        }
        private State fireState;

        //-----------------------------------
        // visitor handlers
        //-----------------------------------

        public override void accept(GameObj that)
        {
            that.visitAlienColumn(this);
        }

        public override void visitMissileRoot(GameObj that)
        {
            // drop one level
            GameObj curr = this.child as GameObj;

            // collide against everything at this level
            while (curr != null)
            {
                if (ColPair.collide(curr, that))
                {
                    return;
                }

                curr = curr.sibling as GameObj;
            }
        }

        public override void visitShieldColumn(GameObj other)
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
    }
}
