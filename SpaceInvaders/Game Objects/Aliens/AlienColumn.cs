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
        }

        public override void update()
        {
            base.unionUpdate();
        }

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
                ColPair.collide(curr, other);

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
                ColPair.collide(curr, other);

                curr = curr.sibling as GameObj;
            }
        }
    }
}
