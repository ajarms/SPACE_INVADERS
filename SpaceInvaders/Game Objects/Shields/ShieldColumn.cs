using System;

namespace SpaceInvaders
{
    class ShieldColumn: _Shield
    {
        // union of a column of blocks in a shield, collision only
        public ShieldColumn( Index index, float _x = 0.0f, float _y = 0.0f)
            : base(GameObj.Name.ShieldColumn, index, BSprite.Name.NullSprite, new Azul.Color(250.0f, 250.0f, 0.0f))
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
            that.visitShieldColumn(this);
        }

        public override void visitMissileRoot(GameObj other)
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

        public override void visitBomb(GameObj other)
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

        public override void visitAlien(GameObj other)
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
