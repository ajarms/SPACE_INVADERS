using System;

namespace SpaceInvaders
{
    class Shield: _Shield
    {
        // union of elements in one shield, collision only
        public Shield( Index index, float _x, float _y)
            : base(GameObj.Name.Shield, index, BSprite.Name.NullSprite, new Azul.Color(250.0f, 250.0f, 0.0f))
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
            that.visitShield(this);
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

        public override void visitBomb(GameObj other)
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

        public override void visitAlienColumn(GameObj other)
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
